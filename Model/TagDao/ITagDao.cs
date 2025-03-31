using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;



namespace Es.Udc.DotNet.PracticaMaD.Model.TagDao
{
    public interface ITagDao : IGenericDao<Tag, Int64>
    {
        Tag findByTitle(string title);

        List<Tag> mostUsedTags();

        List<Tag> findImageTags(ImageSet image);

        List<ImageSet> findTagImages(Tag tag, int startIndex, int count);

    }
}