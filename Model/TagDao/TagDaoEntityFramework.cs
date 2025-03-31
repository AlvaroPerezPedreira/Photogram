using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.TagDao;

namespace Es.Udc.DotNet.PracticaMaD.Model.TagDao
{
    public class TagDaoEntityFramework : GenericDaoEntityFramework<Tag, Int64>, ITagDao
    {
        public TagDaoEntityFramework()
        {
        }
        public Tag findByTitle(string title)
        {
            Tag tag = null;

            #region Option 1: Using Linq.

            DbSet<Tag> tag1 = Context.Set<Tag>();

            var result =
                (from u in tag1
                 where u.title == title
                 select u);

            tag = result.FirstOrDefault();
            #endregion Option 1: Using Linq.

            return tag;
        }

        public List<Tag> mostUsedTags()
        {
            #region Option 1: Using Linq.

            DbSet<Tag> tags = Context.Set<Tag>();

            var result = tags
                        .OrderByDescending(tag => tag.usedTimes)
                        .Take(5).ToList();


            return result;

            #endregion Option 1: Using Linq.
        }


        public List<Tag> findImageTags(ImageSet image)
        {
            var result = image.Tag.ToList();
            return result;
        }

        public List<ImageSet> findTagImages(Tag tag, int startIndex, int count)
        {

            var result = tag.ImageSet.Skip(startIndex).Take(count).ToList();
            return result;
        }
    }
}