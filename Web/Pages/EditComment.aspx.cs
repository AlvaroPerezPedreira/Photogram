using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class EditComment : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Solo se carga una vez
            {
                if (Request.Params["comentarioId"] != null && Request.Params["texto"] != null)
                {
                    txtEditComment.Text = Request.Params["texto"];
                }
            }
        }

        protected void BtnEditCommentClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (Request.Params["comentarioId"] != null)
                {
                    long comentarioId, imageId;
                    if (long.TryParse(Request.Params["comentarioId"], out comentarioId))
                    {
                        if (long.TryParse(Request.Params["imageId"], out imageId)) {
                            SessionManager.EditComment(Context, comentarioId, txtEditComment.Text);

                            Response.Redirect(Response.
                                ApplyAppPathModifier("~/Pages/ShowComments.aspx?id=" + imageId));
                        }
                    }
                }
            }
        }
    }
}