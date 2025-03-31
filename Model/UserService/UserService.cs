using Es.Udc.DotNet.PracticaMaD.Model.UserProfileDao;
using Es.Udc.DotNet.PracticaMaD.Model.UserService.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.UserService.Util;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using System;
using System.Collections.Generic;


namespace Es.Udc.DotNet.PracticaMaD.Model.UserService
{
    public class UserService : IUserService
    {
        [Inject]
        public IUserProfileDao UserProfileDao { private get; set; }
        #region IUserService Members

        /// <exception cref="IncorrectPasswordException"/>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void ChangePassword(long userProfileId, string oldClearPassword,
            string newClearPassword)
        {
            UserProfile userProfile = UserProfileDao.Find(userProfileId);
            String storedPassword = userProfile.enPassword;

            if (!PasswordEncrypter.IsClearPasswordCorrect(oldClearPassword,
                 storedPassword))
            {
                throw new IncorrectPasswordException(userProfile.loginName);
            }

            userProfile.enPassword =
            PasswordEncrypter.Crypt(newClearPassword);

            UserProfileDao.Update(userProfile);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public UserProfileDetails FindUserProfileDetails(long userProfileId)
        {
            UserProfile userProfile = UserProfileDao.Find(userProfileId);

            UserProfileDetails userProfileDetails =
                new UserProfileDetails(userProfile.firstName,
                    userProfile.lastName, userProfile.email,
                    userProfile.language, userProfile.country);

            return userProfileDetails;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public UserProfile FindUserProfile(String loginName)
        {
            UserProfile userProfile = null;
            userProfile = UserProfileDao.FindByLoginName(loginName);

            return userProfile;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public UserProfile FindUserProfileById(long userId)
        {
            UserProfile userProfile = null;
            userProfile = UserProfileDao.Find(userId);

            return userProfile;
        }


        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="IncorrectPasswordException"/>
        [Transactional]
        public LoginResult Login(string loginName, string password, bool passwordIsEncrypted)
        {
            UserProfile userProfile =
                UserProfileDao.FindByLoginName(loginName);

            String storedPassword = userProfile.enPassword;

            if (passwordIsEncrypted)
            {
                if (!password.Equals(storedPassword))
                {
                    throw new IncorrectPasswordException(loginName);
                }
            }
            else
            {
                if (!PasswordEncrypter.IsClearPasswordCorrect(password,
                        storedPassword))
                {
                    throw new IncorrectPasswordException(loginName);
                }
            }

            return new LoginResult(userProfile.usrId, userProfile.firstName,
                storedPassword, userProfile.language, userProfile.country);
        }

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        public long RegisterUser(string loginName, string clearPassword,
            UserProfileDetails userProfileDetails)
        {
            try
            {
                UserProfileDao.FindByLoginName(loginName);

                throw new DuplicateInstanceException(loginName,
                    typeof(UserProfile).FullName);
            }
            catch (InstanceNotFoundException)
            {
                String encryptedPassword = PasswordEncrypter.Crypt(clearPassword);

                UserProfile userProfile = new UserProfile();

                userProfile.loginName = loginName;
                userProfile.enPassword = encryptedPassword;
                if (userProfileDetails.FirstName == null)
                {

                    userProfile.firstName = "google";
                    userProfile.lastName = "google";
                    userProfile.email = userProfileDetails.Email;
                    userProfile.language = "es";
                    userProfile.country = "es";

                }
                else
                {
                    userProfile.firstName = userProfileDetails.FirstName;
                    userProfile.lastName = userProfileDetails.Lastname;
                    userProfile.email = userProfileDetails.Email;
                    userProfile.language = userProfileDetails.Language;
                    userProfile.country = userProfileDetails.Country;
                }
                UserProfileDao.Create(userProfile);


                return userProfile.usrId;
            }
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateUserProfileDetails(long userProfileId,
            UserProfileDetails userProfileDetails)
        {
            UserProfile userProfile =
                UserProfileDao.Find(userProfileId);

            userProfile.firstName = userProfileDetails.FirstName;
            userProfile.lastName = userProfileDetails.Lastname;
            userProfile.email = userProfileDetails.Email;
            userProfile.language = userProfileDetails.Language;
            userProfile.country = userProfileDetails.Country;
            UserProfileDao.Update(userProfile);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public bool UserExists(string loginName)
        {

            try
            {
                UserProfile userProfile = UserProfileDao.FindByLoginName(loginName);
            }
            catch (InstanceNotFoundException e)
            {
                return false;
            }

            return true;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void SeguirUsuario(long seguidoId, long seguidorId)
        {
            UserProfile seguido = UserProfileDao.Find(seguidoId);
            UserProfile seguidor = UserProfileDao.Find(seguidorId);

            //seguidor.Seguido.Add(seguidor);
            seguidor.Seguido.Add(seguido);

            UserProfileDao.Update(seguido);
            UserProfileDao.Update(seguidor);

            //Comprobación de instance not found(?)
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void Unfollow(long seguidoId, long seguidorId)
        {
            UserProfile seguido = UserProfileDao.Find(seguidoId);
            UserProfile seguidor = UserProfileDao.Find(seguidorId);

            seguido.Seguidor.Remove(seguidor);
            seguidor.Seguido.Remove(seguido);

            //Comprobación de instance not found(?)
        }

        [Transactional]
        public UsersBlock FindAllSeguidores(UserProfile user, int startIndex, int count)
        {
            List<UserProfile> seguidores = UserProfileDao.findSeguidores(user, startIndex, count + 1);
            bool existMoreSeguidores = (seguidores.Count == count + 1);
            if (existMoreSeguidores)
            {
                seguidores.RemoveAt(count);
            }
            return new UsersBlock(seguidores, existMoreSeguidores);
        }

        [Transactional]
        public UsersBlock FindAllSeguidos(UserProfile user, int startIndex, int count)
        {

            List<UserProfile> seguidos = UserProfileDao.findSeguidos(user, startIndex, count + 1);
            bool existMoreSeguidos = (seguidos.Count == count + 1);
            if (existMoreSeguidos)
            {
                seguidos.RemoveAt(count);
            }
            return new UsersBlock(seguidos, existMoreSeguidos);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public Boolean UserFollowUser(long userId, long userToCheckId)
        {
            UserProfile user = UserProfileDao.Find(userId);
            UserProfile userToCheck = UserProfileDao.Find(userToCheckId);

            return UserProfileDao.isUserFollowingUser(user, userToCheck);
        }

        #endregion IUserService Members
    }
}