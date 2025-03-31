using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.PracticaMaD.Model.ImageDao;
using Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao;
using Es.Udc.DotNet.PracticaMaD.Model.TagDao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Cache;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.PracticaMaD.Model.UserProfileDao;
using Es.Udc.DotNet.PracticaMaD.Model.CategoryDao;
using System.Diagnostics;

namespace Es.Udc.DotNet.PracticaMaD.Model.ImageService
{
    public class ImageService : IImageService
    {

        public ImageService()
        {
        }


        [Inject]
        public IUserProfileDao UserDao { private get; set; }

        [Inject]
        public IImageDao ImageDao { private get; set; }

        [Inject]
        public IComentarioDao CommentDao { private get; set; }

        [Inject]
        public ITagDao TagDao { private get; set; }


        [Inject]
        public ICategoryDao CategoryDao
        {
            private get; set;
        }

        [Transactional]
        public ImageBlock FindImagesByUserIdentifier(long userIdentifier, string loginName,
            int startIndex, int count)
        {
            List<ImageSet> images = new List<ImageSet>();
            ImageBlock imgBlock;

            if (UsuarioCache.Exists(loginName + startIndex) )
            {
                imgBlock = UsuarioCache.Get(loginName + startIndex, startIndex, count);

                return imgBlock;
            }
            else
            {
                images = ImageDao.FindByUserId(userIdentifier, startIndex, count + 1);

                bool existMoreImages = (images.Count == count + 1);

                if (existMoreImages)
                    images.RemoveAt(count);

                UsuarioCache.Add(loginName + startIndex, images, existMoreImages, startIndex);

                return new ImageBlock(images, existMoreImages);
            }
        }


        [Transactional]
        public ImageSet CreateImage(ImageSet image, EXIF exif)
        {
            image.FechaDeSubida = DateTime.Now;
            image.numLikes = 0;
            image.author = image.UserProfile.loginName;
            image.EXIF = exif;
            ImageDao.Create(image);
            return image;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void DeleteImage(long imgId)
        {
            ImageSet image = ImageDao.Find(imgId);

            var tagNames = image.Tag.Select(tag => tag.title).ToList();

            var tags = image.Tag.ToList();
            foreach(var tag in tags)
            {
                image.Tag.Remove(tag);
                tag.usedTimes -= 1;
                if(tag.usedTimes == 0)
                {
                    TagDao.Remove(tag.TagId);
                }
                else
                {
                    TagDao.Update(tag);
                }
            }

            var likedUsers = image.UserProfile1.ToList();
            foreach(var user in likedUsers)
            {
                user.ImageSet.Remove(image);
                UserDao.Update(user);
            }

            image.UserProfile1.Clear();

            //RemoveTags(tagNames, imgId);

            //image.Tag.Clear();
            
            ImageDao.Update(image);
            
            ImageDao.Remove(imgId);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ImageBlock FilterImages(String keywords, String categoryName, int startIndex, int count)
        {

            Category category = CategoryDao.FindByName(categoryName);

            List<ImageSet> filteredImages = ImageDao.FindByKeywordsAndCategory(keywords, category.Id, startIndex, count + 1);


            bool existMoreImages = (filteredImages.Count == count + 1);

            if (existMoreImages)
                filteredImages.RemoveAt(count);

            return new ImageBlock(filteredImages, existMoreImages);
        }

        [Transactional]
        public ImageBlock FilterImagesNoCategory(String keywords, int startIndex, int count)
        {
            List<ImageSet> filteredImages = ImageDao.FindByKeywords(keywords, startIndex, count + 1);

            bool existMoreImages = (filteredImages.Count == count + 1);

            if (existMoreImages)
                filteredImages.RemoveAt(count);

            return new ImageBlock(filteredImages, existMoreImages);
        }


        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="AlreadyLikedException"/>
        [Transactional]
        public void LikeImage(long id_user, long id_image)
        {
            ImageSet image = ImageDao.Find(id_image);
            UserProfile user = UserDao.Find(id_user);

            if (image.UserProfile1.Contains(user))
            {
                throw new AlreadyLikedException(user.usrId, image.Id);
            }

            image.UserProfile1.Add(user);
            image.numLikes++;
            ImageDao.Update(image);
        }

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="NotLikedException"/>
        [Transactional]
        public void DislikeImage(long id_user, long id_image)
        {
            ImageSet image = ImageDao.Find(id_image);
            UserProfile user = UserDao.Find(id_user);
            if (image.UserProfile1.Contains(user))
            {
                image.UserProfile1.Remove(user);
                user.ImageSet.Remove(image);

                image.numLikes--;
                ImageDao.Update(image);
                UserDao.Update(user);
            }
            else
            {
                throw new NotLikedException(user.usrId, image.Id);
            }

        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public bool UserLikeImage(long id_user, long id_image)
        {
            ImageSet image = ImageDao.Find(id_image);
            UserProfile user = UserDao.Find(id_user);

            if (image.UserProfile1.Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ImageSet FindImage(long imageIdentifier)
        {
            ImageSet imagen = null;
            imagen = ImageDao.Find(imageIdentifier);

            return imagen;
        }


        //Comment

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public long CommentImage(long id_user, long id_image, String texto)
        {
            UserProfile user = UserDao.Find(id_user);
            Comment comentario = new Comment();
            comentario.ImagenSetId = id_image;
            comentario.UserProfile_usrId = id_user;
            comentario.Texto = texto;
            comentario.Date = DateTime.Now;
            comentario.author = user.loginName;


            CommentDao.Create(comentario);

            return comentario.comentarioId;
        }

        [Transactional]
        public ComentarioBlock ShowComments(long imgId, int startIndex, int count)
        {
            List<Comment> comentarios =
                CommentDao.FindByImgId(imgId, startIndex, count + 1);

            bool existMoreImages = (comentarios.Count == count + 1);

            if (existMoreImages)
                comentarios.RemoveAt(count);

            return new ComentarioBlock(comentarios, existMoreImages);
        }

        [Transactional]
        public bool CommentsExists(long imgId)
        {
            return (CommentDao.FindByImgId(imgId, 0, 2).Count == 0) ? false : true;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateComment(long userId, long commentId, string text)
        {
            Comment comment = CommentDao.Find(commentId);
            if (comment.UserProfile_usrId.Equals(userId))
            {
                comment.Texto = text;
                comment.Date = DateTime.Now;
                CommentDao.Update(comment);
            }
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void DeleteComment(long commentId)
        {
            CommentDao.Remove(commentId);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public bool IsCommentFromUser(long userId, long commentId)
        {
            Comment comment = CommentDao.Find(commentId);
            if (comment.UserProfile_usrId.Equals(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Category

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public Category FindCategoryName(String name)
        {
            Category category = null;
            category = CategoryDao.FindByName(name);

            return category;
        }

        [Transactional]
        public List<String> FindAllCategoryNames()
        {
            List<String> categoryNames = new List<string>();

            List<Category> categories = CategoryDao.GetAllElements();

            foreach (Category category in categories)
            {
                categoryNames.Add(category.Nombre);
            }
            return categoryNames;

        }


        //Tag

        [Transactional]
        public void CreateTag(String title)
        {
            Tag tag = new Tag();
            tag.title = title;
            tag.usedTimes = 0;

            TagDao.Create(tag);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void AddTags(List<String> tagList, long imgId)
        {
            ImageSet image = ImageDao.Find(imgId);

            int count = 0;

            foreach (String tagName in tagList)
            {
                Tag tag = TagDao.findByTitle(tagName);

                if (tag == null)
                {
                    CreateTag(tagName);
                    tag = TagDao.findByTitle(tagName);
                }

                foreach (Tag t in image.Tag)
                {
                    if (t.TagId == tag.TagId)
                    {
                        count += 1;
                    }
                }

                if (count == 0)
                {
                    tag.usedTimes += 1;
                    image.Tag.Add(tag);
                }
                TagDao.Update(tag);
            }
            ImageDao.Update(image);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void RemoveTags(List<String> tagList, long imgId)
        {
            ImageSet image = ImageDao.Find(imgId);

            foreach (String tagName in tagList)
            {
                Tag tag = TagDao.findByTitle(tagName);

                if (tag != null && TagDao.Exists(tag.TagId))
                {
                    image.Tag.Remove(tag);
                    tag.usedTimes -= 1;

                    if (tag.usedTimes == 0)
                    {
                        ImageDao.Update(image);
                        TagDao.Remove(tag.TagId);
                    }
                    else
                    {
                        TagDao.Update(tag);
                    }
                }
            }
            ImageDao.Update(image);
        }

        [Transactional]
        public List<Tag> FindAllTags()
        {
            List<Tag> tags = TagDao.GetAllElements();
            return tags;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateTag(long tagId, string title)
        {
            Tag tag = TagDao.Find(tagId);
            tag.title = title;
            TagDao.Update(tag);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public List<Tag> FindImageTags(long imgId)
        {

            ImageSet image = ImageDao.Find(imgId);

            List<Tag> tags = new List<Tag>();
            if (image != null)
            {
                tags = TagDao.findImageTags(image);
            }

            return tags;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ImageBlock FindTagImages(long tagId, int startIndex, int count)
        {

            Tag tag = TagDao.Find(tagId);

            List<ImageSet> images = new List<ImageSet>();
            if (tag != null)
            {
                images = TagDao.findTagImages(tag, startIndex, count + 1);
            }

            bool existMoreImages = (images.Count == count + 1);
            if (existMoreImages)
            {
                images.RemoveAt(count);
            }
            return new ImageBlock(images, existMoreImages);

        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public Boolean ImageHasTag(long imageId)
        {
            List<Tag> tags = new List<Tag>();
            tags = FindImageTags(imageId);
            
            return (tags.Count != 0);
        }

    }
}
