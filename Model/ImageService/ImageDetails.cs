using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ImageService
{

    /// <summary>
    /// VO Class which contains the image details
    /// </summary>
    [Serializable()]
    public class ImageDetails
    {
        #region Properties Region
        public string Titulo { get; set; }
        public string loginName { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaDeSubida { get; set; }
        public byte[] Data { get; set; }
        public long CategoríaId { get; set; }
        public List<Tag> tags { get; set; } // PREGUNTAR
        public EXIF exif { get; set; }
        public long numLikes { get; set; }

        #endregion


        public ImageDetails(String Titulo, String loginName, String Descripcion, System.DateTime FechaDeSubida, Byte[] Data, long CategoríaId, List<Tag> tags, EXIF exif, long numLikes)
        {
            this.Titulo = Titulo;
            this.loginName = loginName;
            this.Descripcion = Descripcion;
            this.FechaDeSubida = FechaDeSubida;
            this.Data = Data;
            this.CategoríaId = CategoríaId;
            this.tags = tags;
            this.exif = exif;
            this.numLikes = numLikes;

        }

        public override bool Equals(object obj)
        {

            ImageDetails target = (ImageDetails)obj;

            return (this.Titulo == target.Titulo)
                  && (this.loginName == target.loginName)
                  && (this.Descripcion == target.Descripcion)
                  && (this.FechaDeSubida == target.FechaDeSubida)
                  && (this.Data == target.Data)
                  && (this.CategoríaId == target.CategoríaId)
                  && (this.tags == target.tags)
                  && (this.exif == target.exif)
                  && (this.numLikes == target.numLikes);
        }

        // The GetHashCode method is used in hashing algorithms and data 
        // structures such as a hash table. In order to ensure that it works 
        // properly, we suppose that the FirstName does not change.        
        public override int GetHashCode()
        {
            return this.Titulo.GetHashCode();
        }

    }
}