using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class DeleteImage : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Busca en la url la Id
            if (Request.Params["id"] != null)
            {
                long imageId;
                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    var image = SessionManager.FindImage(imageId).Data;

                    if (image != null)
                    {
                        Image1.ImageUrl = ConvertImagesToBase64(image);
                    }
                }
            }
        }

        /* Para convertir las imágenes */
        public String ConvertImagesToBase64(object image)
        {
            Byte[] imagen = (Byte[])image;

            return "data:image;base64," + Convert.ToBase64String(imagen);
        }

        protected void BtnDeleteClick(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                long imageId;
                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    SessionManager.DeleteImage(imageId);

                }
            }

            Response.Redirect(Response.
                ApplyAppPathModifier("~/Pages/Home.aspx"));
        }
    }
}