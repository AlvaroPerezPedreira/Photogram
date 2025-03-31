using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ImageService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.Properties;
using System.Web.UI.HtmlControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ShowImages : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int startIndex, count;
            long tagId;
            ImageBlock imageBlock;

            lnkPrevious.Visible = false;
            lnkNext.Visible = false;

            /* Get Start Index */
            try
            {
                startIndex = Int32.Parse(Request.Params.Get("startIndex"));
            }
            catch (ArgumentNullException)
            {
                startIndex = 0;
            }

            /* Get Count */
            try
            {
                count = Int32.Parse(Request.Params.Get("count"));
            }
            catch (ArgumentNullException)
            {
                count = Settings.Default.PracticaMaD_defaultCount;
            }

            /* Get TagId */
            try
            {
                tagId = long.Parse(Request.Params.Get("tags"));
            }
            catch (Exception ex)
            {
                tagId = -1;
            }


            string valorRecibido = Request.QueryString["valorBusqueda"];
            string category = Request.QueryString["category"];

            // Obtén el bloque de imágenes desde la sesión
            if(category == "-" && tagId == -1)
            {
                imageBlock = SessionManager.FilterImagesNoCategory(valorRecibido, startIndex, count);
            }
            else if(tagId == -1)
            {
                imageBlock = SessionManager.FilterImages(valorRecibido, category, startIndex, count);
            }
            else
            {
                imageBlock = SessionManager.FindTagImages(tagId, startIndex, count);
            }

            // Vincula la lista de URLs al control Repeater
            rptImages.DataSource = imageBlock.Images;
            rptImages.DataBind();


            /* "Previous" link */
            if ((startIndex - count) >= 0)
            {
                String url =
                    Settings.Default.PracticaMaD_applicationURL + $"/Pages/ShowImages.aspx?valorBusqueda={valorRecibido}&category={category}&tags={tagId}&startindex={(startIndex - count)}&count={count}";


                this.lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (imageBlock.ExistMoreImages)
            {
                String url =
                Settings.Default.PracticaMaD_applicationURL + $"/Pages/ShowImages.aspx?valorBusqueda={valorRecibido}&category={category}&tags={tagId}&startindex={(startIndex + count)}&count={count}";

                this.lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkNext.Visible = true;
            }
        }

        public String ConvertImagesToBase64(object image)
        {
            Byte[] imagen = (Byte[])image;

            return "data:image;base64," + Convert.ToBase64String(imagen);

        }

        protected void rptImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Acceder al control asp:Image dentro del RepeaterItem
                Image imgDynamic = (Image)e.Item.FindControl("imgDynamic");
                HtmlGenericControl h5Titulo = (HtmlGenericControl)e.Item.FindControl("Titulo");
                HtmlGenericControl pNumLikes = (HtmlGenericControl)e.Item.FindControl("numLikes");
                HyperLink detailsLink = (HyperLink)e.Item.FindControl("lnkDetallesImagen");
                HyperLink likeLink = (HyperLink)e.Item.FindControl("lnkLike");
                HyperLink commentLink = (HyperLink)e.Item.FindControl("lnkComment");
                HyperLink showCommentsLink = (HyperLink)e.Item.FindControl("lnkShowComments");
                HyperLink deleteImageLink = (HyperLink)e.Item.FindControl("lnkDeleteImage");
                HyperLink editTagLink = (HyperLink)e.Item.FindControl("lnkEditTags");
                HyperLink showTagsLink = (HyperLink)e.Item.FindControl("lnkShowTags");



                // Obtener la URL de la imagen del DataItem y establecerla como ImageUrl
                ImageSet image = (ImageSet)e.Item.DataItem;
                imgDynamic.ImageUrl = ConvertImagesToBase64(image.Data);
                h5Titulo.InnerText = image.Titulo;
                pNumLikes.InnerText = "Número de likes: " + image.numLikes;
                detailsLink.NavigateUrl = "ImageDetails.aspx?id=" + image.Id;
                likeLink.NavigateUrl = "LikeImage.aspx?id=" + image.Id;
                commentLink.NavigateUrl = "Comment.aspx?id=" + image.Id;
                showCommentsLink.Visible = SessionManager.CommentsExists(image.Id);
                showCommentsLink.NavigateUrl = "ShowComments.aspx?id=" + image.Id;
                deleteImageLink.NavigateUrl = "DeleteImage.aspx?id=" + image.Id;
                editTagLink.NavigateUrl = "EditTags.aspx?id=" + image.Id;
                showTagsLink.NavigateUrl = "ShowTags.aspx?id=" + image.Id;

                if(SessionManager.ImageHasTags(image.Id))
                {
                    showTagsLink.Visible = true;
                }
                else {
                    showTagsLink.Visible = false;
                }

                if (SessionManager.IsUserAuthenticated(Context) && SessionManager.IsUserTheAuthor(Context, image.usrId))
                {
                    deleteImageLink.Visible = true;
                    editTagLink.Visible = true;
                }
                else
                {
                    deleteImageLink.Visible = false;
                    editTagLink.Visible = false;
                }
            }
        }

        public List<string> GetImageUrls(ImageBlock imageBlock)
        {
            List<string> imageUrls = new List<string>();
            foreach(var image in imageBlock.Images)
            {
                string imageUrl = ConvertImagesToBase64(image.Data);
                imageUrls.Add(imageUrl);
            }
            return imageUrls;
        }

    }
}