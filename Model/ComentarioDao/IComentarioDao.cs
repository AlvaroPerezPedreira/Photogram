using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao;

namespace Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao
{
    public interface IComentarioDao : IGenericDao<Comment, Int64>
    {
        List<Comment> FindByImgId(long imgId, int startIndex, int count);
    }
}