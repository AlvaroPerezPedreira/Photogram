using Es.Udc.DotNet.PracticaMaD.Model.UserService;
using Es.Udc.DotNet.PracticaMaD.Model.UserService.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Util;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.View.ApplicationObjects;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using System;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMaD.Model.ImageService;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.ExifDao;
using Es.Udc.DotNet.PracticaMaD.Model.UserProfileDao;
using Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao;

namespace Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session
{
    public class SessionManager
    {
        public static readonly String LOCALE_SESSION_ATTRIBUTE = "locale";

        public static readonly String USER_SESSION_ATTRIBUTE =
               "userSession";

        /* Servicios*/
        private static IUserService userService;
        private static IImageService imageService;

        /* DAOs */
        private static IUserProfileDao userProfileDao;
        private static ICategoryDao categoryDao;
        private static IExifDao exifDao;


        /* Servicios */
        public IUserService UserService
        {
            set { userService = value; }
        }

        public IImageService ImageService
        {
            set { imageService = value;  }
        }

        /* DAOs */

        public IUserProfileDao UserProfileDao
        {
            set { userProfileDao = value; }
        }

        public ICategoryDao CategoryDao
        {
            set { categoryDao = value; }
        }

        public IExifDao ExifDao
        {
            set { exifDao = value; }
        }

        static SessionManager()
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];

            userService = iocManager.Resolve<IUserService>();
            imageService = iocManager.Resolve<IImageService>();
            categoryDao = iocManager.Resolve<ICategoryDao>();
            exifDao = iocManager.Resolve<IExifDao>();
            userProfileDao = iocManager.Resolve<IUserProfileDao>();
        }


        /* User */

        public static void RegisterUser(HttpContext context,
            String loginName, String clearPassword,
            UserProfileDetails userProfileDetails)
        {
            /* Register user. */
            long usrId = userService.RegisterUser(loginName, clearPassword,
                userProfileDetails);

            /* Insert necessary objects in the session. */
            UserSession userSession = new UserSession();
            userSession.UserProfileId = usrId;
            userSession.FirstName = userProfileDetails.FirstName;

            Locale locale = new Locale(userProfileDetails.Language,
                userProfileDetails.Country);

            UpdateSessionForAuthenticatedUser(context, userSession, locale);

            FormsAuthentication.SetAuthCookie(loginName, false);
        }

        public static void Login(HttpContext context, String loginName,
           String clearPassword, Boolean rememberMyPassword)
        {
            /* Try to login, and if successful, update session with the necessary
             * objects for an authenticated user. */
            LoginResult loginResult = DoLogin(context, loginName,
                clearPassword, false, rememberMyPassword);

            /* Add cookies if requested. */
            if (rememberMyPassword)
            {
                CookiesManager.LeaveCookies(context, loginName,
                    loginResult.EncryptedPassword);
            }
        }

        private static LoginResult DoLogin(HttpContext context,
             String loginName, String password, Boolean passwordIsEncrypted,
             Boolean rememberMyPassword)
        {
            LoginResult loginResult =
                userService.Login(loginName, password,
                    passwordIsEncrypted);

            /* Insert necessary objects in the session. */

            UserSession userSession = new UserSession();
            userSession.UserProfileId = loginResult.UserProfileId;
            userSession.FirstName = loginResult.FirstName;

            Locale locale =
                new Locale(loginResult.Language, loginResult.Country);

            UpdateSessionForAuthenticatedUser(context, userSession, locale);

            return loginResult;
        }

        private static void UpdateSessionForAuthenticatedUser(
            HttpContext context, UserSession userSession, Locale locale)
        {
            /* Insert objects in session. */
            context.Session.Add(USER_SESSION_ATTRIBUTE, userSession);
            context.Session.Add(LOCALE_SESSION_ATTRIBUTE, locale);
        }
        public static Boolean IsUserAuthenticated(HttpContext context)
        {
            if (context.Session == null)
                return false;

            return (context.Session[USER_SESSION_ATTRIBUTE] != null);
        }

        public static Locale GetLocale(HttpContext context)
        {
            Locale locale =
                (Locale)context.Session[LOCALE_SESSION_ATTRIBUTE];

            return locale;
        }

        public static void UpdateUserProfileDetails(HttpContext context,
            UserProfileDetails userProfileDetails)
        {
            /* Update user's profile details. */

            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            userService.UpdateUserProfileDetails(userSession.UserProfileId,
                userProfileDetails);

            /* Update user's session objects. */

            Locale locale = new Locale(userProfileDetails.Language,
                userProfileDetails.Country);

            userSession.FirstName = userProfileDetails.FirstName;

            UpdateSessionForAuthenticatedUser(context, userSession, locale);
        }

        public static UserProfileDetails FindUserProfileDetails(HttpContext context)
        {
            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            UserProfileDetails userProfileDetails =
                userService.FindUserProfileDetails(userSession.UserProfileId);

            return userProfileDetails;
        }
        public static UserSession GetUserSession(HttpContext context)
        {
            if (IsUserAuthenticated(context))
                return (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            else
                return null;
        }

        public static void ChangePassword(HttpContext context,
               String oldClearPassword, String newClearPassword)
        {
            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            userService.ChangePassword(userSession.UserProfileId,
                oldClearPassword, newClearPassword);

            /* Remove cookies. */
            CookiesManager.RemoveCookies(context);
        }

        public static void Logout(HttpContext context)
        {
            /* Remove cookies. */
            CookiesManager.RemoveCookies(context);

            /* Invalidate session. */
            context.Session.Abandon();

            /* Invalidate Authentication Ticket */
            FormsAuthentication.SignOut();
        }

        public static void TouchSession(HttpContext context)
        {
            /* Check if "UserSession" object is in the session. */
            UserSession userSession = null;

            if (context.Session != null)
            {
                userSession =
                    (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

                // If userSession object is in the session, nothing should be doing.
                if (userSession != null)
                {
                    return;
                }
            }

            /*
             * The user had not been authenticated or his/her session has
             * expired. We need to check if the user has selected "remember my
             * password" in the last login (login name and password will come
             * as cookies). If so, we reconstruct user's session objects.
             */
            UpdateSessionFromCookies(context);
        }

        private static void UpdateSessionFromCookies(HttpContext context)
        {
            HttpRequest request = context.Request;
            if (request.Cookies == null)
            {
                return;
            }

            /*
             * Check if the login name and the encrypted password come as
             * cookies.
             */
            String loginName = CookiesManager.GetLoginName(context);
            String encryptedPassword = CookiesManager.GetEncryptedPassword(context);

            if ((loginName == null) || (encryptedPassword == null))
            {
                return;
            }

            /* If loginName and encryptedPassword have valid values (the user selected "remember
             * my password" option) try to login, and if successful, update session with the
             * necessary objects for an authenticated user.
             */
            try
            {
                DoLogin(context, loginName, encryptedPassword, true, true);

                /* Authentication Ticket. */
                FormsAuthentication.SetAuthCookie(loginName, true);
            }
            catch (Exception)
            { // Incorrect loginName or encryptedPassword
                return;
            }
        }

        public static UserProfile FindUser(String loginName)
        {
            UserProfile userProfile = userService.FindUserProfile(loginName);

            return userProfile;
        }

        public static UserProfile FindUserById(long userId)
        {
            UserProfile userProfile = userService.FindUserProfileById(userId);

            return userProfile;
        }

        public static Boolean IsUserTheAuthor(HttpContext context, long authorId)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            return userSession.UserProfileId == authorId;
        }

        public static Boolean UserExists(string loginName)
        {
            return (userService.UserExists(loginName));
        }

        public static Boolean UserFollowUser(HttpContext context, long userToCheckId)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            return userService.UserFollowUser(userSession.UserProfileId, userToCheckId);
        }



        /* Categoría */
        public static List<String> FindAllCategoryNames()
        {
            return imageService.FindAllCategoryNames();
        }

        /* Imagen */
        public static ImageSet CreateImage(HttpContext context, String title, String description, Byte[] url, String categoryName, String opening, String exposition, String iso, String wb)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            //Crear imagen
            UserProfile user = userProfileDao.Find(userSession.UserProfileId);
            Category cat = categoryDao.FindByName(categoryName);

            EXIF exif = new EXIF();
            exif.Apertura = opening;
            exif.TExposicion = exposition;
            exif.ISO = iso;
            exif.WB = wb;

            exifDao.Create(exif);
            //probar
            EXIF createdExif = exifDao.Find(exif.Id);

            ImageSet newImage = new ImageSet();
            newImage.usrId = userSession.UserProfileId;
            newImage.Titulo = title;
            newImage.Descripcion = description;
            newImage.Data = url;
            newImage.EXIFId = createdExif.Id;
            newImage.CategoríaId = cat.Id;
            newImage.UserProfile = user;
            newImage.Categoría = cat;

            return imageService.CreateImage(newImage, exif);
        }

        public static ImageSet FindImage(long imgId)
        {
            return imageService.FindImage(imgId);
        }

        public static ImageBlock FindImagesByUserIdentifier(long userIdentifier, string loginName, int startIndex, int count)
        {
            return imageService.FindImagesByUserIdentifier(userIdentifier, loginName, startIndex, count);
        }
            
        public static void Like(HttpContext context, long imgId)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            imageService.LikeImage(userSession.UserProfileId, imgId);
        }

        public static void Dislike(HttpContext context, long imgId)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            imageService.DislikeImage(userSession.UserProfileId, imgId);
        }

        public static bool UserLikeImage(HttpContext context, long imgId)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            return imageService.UserLikeImage(userSession.UserProfileId, imgId);
        }

        public static ImageBlock FilterImages(String keywords, String category, int startIndex, int count)
        {
            return imageService.FilterImages(keywords, category, startIndex, count);

        }
        public static ImageBlock FilterImagesNoCategory(String keywords, int startIndex, int count)
        {

            return imageService.FilterImagesNoCategory(keywords, startIndex, count);
        }

        public static void DeleteImage(long imgId)
        {
            imageService.DeleteImage(imgId);
        }

        /* Comentario */
        public static long Comment(HttpContext context, long id_image, String texto)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            return imageService.CommentImage(userSession.UserProfileId, id_image, texto);
        }

        public static ComentarioBlock ShowComments(long imgId, int startIndex, int count)
        {
            return imageService.ShowComments(imgId, startIndex, count);
        }

        public static bool CommentsExists(long id_image)
        {
            return imageService.CommentsExists(id_image);
        }

        public static void EditComment(HttpContext context, long id_comment, String texto)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            imageService.UpdateComment(userSession.UserProfileId, id_comment, texto);
        }

        public static bool IsCommentFromUser(HttpContext context, long id_comment)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            return imageService.IsCommentFromUser(userSession.UserProfileId, id_comment);
        }

        /* Seguidos/Seguidores */
        public static UsersBlock FindAllSeguidores(HttpContext context, string userName, int startIndex, int count)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            UserProfile userProfile;
            if (userName != null)
            {
                userProfile = FindUser(userName);
            } else
            {
                userProfile = userProfileDao.Find(userSession.UserProfileId);
            }
            return userService.FindAllSeguidores(userProfile, startIndex, count);
        }

        public static UsersBlock FindAllSeguidos(HttpContext context, string userName, int startIndex, int count)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            UserProfile userProfile;
            if (userName != null)
            {
                userProfile = FindUser(userName);
            } else
            {
                userProfile = userProfileDao.Find(userSession.UserProfileId);
            }
            return userService.FindAllSeguidos(userProfile, startIndex, count);
        }

        public static void followUser(HttpContext context, long userFollowedId)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            userService.SeguirUsuario(userFollowedId, userSession.UserProfileId);
        }

        public static void unfollowUser(HttpContext context, long userFollowedId)
        {
            UserSession userSession = (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            userService.Unfollow(userFollowedId, userSession.UserProfileId);
        }

        /* Tags */

        public static void AddTags(List<String> tagList, long imgId)
        {
            imageService.AddTags(tagList, imgId);
        }

        public static void RemoveTags(List<String> tagList, long imgId)
        {
            imageService.RemoveTags(tagList, imgId);
        }

        public static List<Tag> FindImageTags(long imgId)
        {
            return imageService.FindImageTags(imgId);
        }

        public static List<Tag> FindAllTags()
        {
            return imageService.FindAllTags();
        }

        public static ImageBlock FindTagImages(long tagId, int startIndex, int count)
        {
            return imageService.FindTagImages(tagId, startIndex, count);
        }

        public static Boolean ImageHasTags(long imageId)
        {
            return imageService.ImageHasTag(imageId);
        }
    }
}