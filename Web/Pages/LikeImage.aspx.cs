using Es.Udc.DotNet.PracticaMaD.Model.ImageService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class LikeImage : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se busca el id de la url
            if (Request.Params["id"] != null)
            {
                long imageId;
                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    var image = SessionManager.FindImage(imageId);

                    if (image != null)
                    {
                        Image1.ImageUrl = ConvertImagesToBase64(image.Data);
                        if(SessionManager.UserLikeImage(Context, imageId))
                        {
                            btnLike.Visible = false;
                            btnDislike.Visible = true;
                        }
                        else
                        {
                            btnLike.Visible = true;
                            btnDislike.Visible = false;
                        }
                        textLikes.Text = image.numLikes.ToString();
                    }
                }
            }
        }

        public String ConvertImagesToBase64(object image)
        {
            Byte[] imagen = (Byte[])image;

            return "data:image;base64," + Convert.ToBase64String(imagen);
        }

        protected void BtnLikeClick(object sender, EventArgs e)
        {

            if (Request.Params["id"] != null)
            {
                long imageId;
                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    try
                    {
                        SessionManager.Like(Context, imageId);
                        Response.Redirect(Request.RawUrl);
                    }
                    catch (AlreadyLikedException)
                    {

                        Response.Redirect(Response.
                            ApplyAppPathModifier("~/Pages/Errors/AlreadyLikedException.aspx"));
                    }

                }

            }
        }

        protected void BtnDisLikeClick(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                long imageId;
                if (long.TryParse(Request.Params["id"], out imageId))
                {

                    try
                    {
                        SessionManager.Dislike(Context, imageId);
                        Response.Redirect(Request.RawUrl);

                    }
                    catch (NotLikedException)
                    {
                        Response.Redirect(Response.
                            ApplyAppPathModifier("~/Pages/Errors/DislikedException.aspx"));
                    }
                }

            }
        }


    }
}