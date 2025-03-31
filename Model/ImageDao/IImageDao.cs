using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;


namespace Es.Udc.DotNet.PracticaMaD.Model.ImageDao
{
    public interface IImageDao : IGenericDao<ImageSet, Int64>
    {

        List<ImageSet> FindByUserId(long userId, int startIndex, int count);

        List<ImageSet> FindByKeywords(String keywords, int startIndex, int count);

        List<ImageSet> FindByKeywordsAndCategory(String keywords, long categoryId, int startIndex, int count);

    }
}