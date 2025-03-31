using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao;
using System.Data.Entity;

namespace Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao
{
    public class ComentarioDaoEntityFramework : GenericDaoEntityFramework<Comment, Int64>, IComentarioDao
    {

        #region IComentarioDao Members

        public List<Comment> FindByImgId(long imgId, int startIndex,
            int count)
        {
            #region Option 1: Using Linq.

            DbSet<Comment> comentarios = Context.Set<Comment>();

            var result =
                 (from i in comentarios
                  where i.ImagenSetId == imgId
                  orderby i.Date descending
                  select i).Skip(startIndex).Take(count).ToList();

            return result;

            #endregion Option 1: Using Linq.
        }
        #endregion IImageDao Members

    }
}