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
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ImageService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System.Web.UI.HtmlControls;
using Es.Udc.DotNet.PracticaMaD.Model.ComentarioDao;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ShowComments : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Params["id"] != null)
            {
                long imageId;
                if (long.TryParse(Request.Params["id"], out imageId))
                {

                    int startIndex, count;

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

                    var image = SessionManager.FindImage(imageId).Data;

                    if (image != null)
                    {
                        Image1.ImageUrl = ConvertImagesToBase64(image);

                        ComentarioBlock commentBlock = SessionManager.ShowComments(imageId, startIndex, count);
                        List<Model.Comment> comentarios = commentBlock.Comentarios;

                        rptComments.DataSource = comentarios;
                        rptComments.DataBind();

                        /* "Previous" link */
                        if ((startIndex - count) >= 0)
                        {
                            String url =
                                Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowComments.aspx?id=" + imageId + "&startindex=" + (startIndex - count) + "&count=" + count;

                            this.lnkPrevious.NavigateUrl =
                                Response.ApplyAppPathModifier(url);
                            this.lnkPrevious.Visible = true;
                        }

                        /* "Next" link */
                        if (commentBlock.ExistMoreComentarios)
                        {
                            String url =
                                Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowComments.aspx?id=" + imageId + "&startindex=" + (startIndex + count) + "&count=" + count;

                            this.lnkNext.NavigateUrl =
                                Response.ApplyAppPathModifier(url);
                            this.lnkNext.Visible = true;
                        }
                    }
                }
            }
        }


        public String ConvertImagesToBase64(object image)
        {
            Byte[] imagen = (Byte[])image;

            return "data:image;base64," + Convert.ToBase64String(imagen);

        }

        protected void rptComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Accedo a cada comentario
                Model.Comment comment = (Model.Comment)e.Item.DataItem;

                // Accedo al texto del comentario
                HtmlGenericControl commentText = (HtmlGenericControl)e.Item.FindControl("CommentD");
                commentText.InnerText = comment.Texto;

                // Accedo a la fecha del comentario
                HtmlGenericControl date = (HtmlGenericControl)e.Item.FindControl("Fecha");
                date.InnerText = comment.Date.ToString();

                // Accedo a los links del comentario
                HyperLink userLink = (HyperLink)e.Item.FindControl("lnkUsuario");
                userLink.NavigateUrl = "ShowUserProfile.aspx?login=" + comment.author;
                userLink.Text = comment.author;

                HyperLink editCommentLink = (HyperLink)e.Item.FindControl("lnkEditarComentario");
                editCommentLink.NavigateUrl = "EditComment.aspx?imageId=" + comment.ImagenSetId + "&comentarioId=" + comment.comentarioId + "&texto=" + comment.Texto;
                
                if(SessionManager.IsUserAuthenticated(Context))
                {
                    if (SessionManager.IsCommentFromUser(Context, comment.comentarioId))
                    {
                        editCommentLink.Visible = true;
                    }
                    else
                    {
                        editCommentLink.Visible = false;
                    }
                }
            }
        }

    }
}