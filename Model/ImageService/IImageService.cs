using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.PracticaMaD.Model.ImageDao;
using Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model.CategoryDao;

namespace Es.Udc.DotNet.PracticaMaD.Model.ImageService
{
    public interface IImageService
    {

        IImageDao ImageDao { set; }

        ICategoryDao CategoryDao { set; }

        [Transactional]
        ImageBlock FindImagesByUserIdentifier(long userId, string loginName, int startIndex, int count);
        
        [Transactional]
        ImageSet CreateImage(ImageSet image, EXIF exif);

        [Transactional]
        void DeleteImage(long imgId);
        
        [Transactional]
        ImageBlock FilterImages(String keywords, String categoryName, int startIndex, int count);

        [Transactional]
        ImageBlock FilterImagesNoCategory(String keywords, int startIndex, int count);

        [Transactional]
        void LikeImage(long id_user, long id_image);

        [Transactional]
        void DislikeImage(long id_user, long id_image);

        [Transactional]
        bool UserLikeImage(long id_user, long id_image);

        [Transactional]
        ImageSet FindImage(long imageIdentifier);


        //Comment

        [Transactional]
        long CommentImage(long id_user, long id_image, String texto);

        [Transactional]
        ComentarioDao.ComentarioBlock ShowComments(long imgId, int startIndex, int count);

        [Transactional]
        bool CommentsExists(long imgId);

        [Transactional]
        void UpdateComment(long userId, long commentId, string text);

        [Transactional]
        void DeleteComment(long commentId);

        [Transactional]
        bool IsCommentFromUser(long userId, long commentId);


        //Category

        [Transactional]
        Category FindCategoryName(String name);

        [Transactional]
        List<String> FindAllCategoryNames();


        //Tag

        [Transactional]
        void CreateTag(String title);

        [Transactional]
        void AddTags(List<String> tagList, long imgId);

        /* [Transactional]
         void RemoveTag(Tag tag, ImageSet image);*/

        [Transactional]
        void RemoveTags(List<String> tagList, long imgId);

        [Transactional]
        List<Tag> FindAllTags();

        [Transactional]
        void UpdateTag(long tagId, string title);

        [Transactional]
        List<Tag> FindImageTags(long imgId);

        [Transactional]
        ImageBlock FindTagImages(long tagId, int startIndex, int count);

        [Transactional]
        Boolean ImageHasTag(long imageId);
    }
}
