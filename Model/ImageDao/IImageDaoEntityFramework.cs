using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using System.Data.Entity;

namespace Es.Udc.DotNet.PracticaMaD.Model.ImageDao
{
    public class IImageDaoEntityFramework : GenericDaoEntityFramework<ImageSet, Int64>, IImageDao
    {
        #region IImageDao Members

        public List<ImageSet> FindByUserId(long userId, int startIndex,
            int count)
        {
            #region Option 1: Using Linq.

            DbSet<ImageSet> images = Context.Set<ImageSet>();

            var result =
                 (from i in images
                  where i.usrId == userId
                  orderby i.FechaDeSubida descending
                  select i).Skip(startIndex).Take(count).ToList();

            return result;

            #endregion Option 1: Using Linq.

        }



        public List<ImageSet> FindByKeywords(String keywords, int startIndex, int count)
        {

            #region Option 1: Using Linq.

            DbSet<ImageSet> images = Context.Set<ImageSet>();

            var result =
                 (from i in images
                  where i.Titulo.Contains(keywords) || i.Descripcion.Contains(keywords)
                  orderby i.FechaDeSubida descending
                  select i).Skip(startIndex).Take(count).ToList();

            return result;


            #endregion Option 1: Using Linq.

        }


        public List<ImageSet> FindByKeywordsAndCategory(String keywords, long categoryId, int startIndex, int count)
        {

            #region Option 1: Using Linq.

            DbSet<ImageSet> images = Context.Set<ImageSet>();

            var result =
                 (from i in images
                  where (i.CategoríaId == categoryId) && (i.Titulo.Contains(keywords) || i.Descripcion.Contains(keywords))
                  orderby i.FechaDeSubida descending
                  select i).Skip(startIndex).Take(count).ToList();

            return result;


            #endregion Option 1: Using Linq.

        }

        #endregion IImageDao Members

    }
}