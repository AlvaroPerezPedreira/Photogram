using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ImageDetails : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se busca el id de la url y se asignan los valores
            if (Request.Params["id"] != null)
            {
                long imageId;
                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    var image = SessionManager.FindImage(imageId);

                    if (image != null)
                    {
                        Image1.ImageUrl = ConvertImagesToBase64(image.Data);
                        textTitulo.Text = image.Titulo;
                        textDescripcion.Text = image.Descripcion;
                        textFecha.Text = image.FechaDeSubida.ToString();
                        textAuthor.Text = image.author;
                        textApertura.Text = image.EXIF.Apertura;
                        TextBoxExposicion.Text = image.EXIF.TExposicion;
                        TextBoxISO.Text = image.EXIF.ISO;
                        TextBoxWB.Text = image.EXIF.WB;
                        TextCategory.Text = image.Categoría.Nombre;
                    }
                }

            }

        }

        public String ConvertImagesToBase64(object image)
        {
            Byte[] imagen = (Byte[])image;

            return "data:image;base64," + Convert.ToBase64String(imagen);

        }
    }
}