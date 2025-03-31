using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao
{
    public class ComentarioBlock
    {
        public List<Comment> Comentarios { get; private set; }
        public bool ExistMoreComentarios { get; private set; }

        public ComentarioBlock(List<Comment> comentarios, bool existMoreComentarios)
        {
            this.Comentarios = comentarios;
            this.ExistMoreComentarios = existMoreComentarios;
        }
    }
}
