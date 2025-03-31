using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class EditTags : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateComboTags();
        }


        private void UpdateComboTags()
        {
            // Se borran los tags de antes del droplist
            ddlTags.Items.Clear();

            // Buscar la id de la imagen en la url
            if (Request.Params["id"] != null)
            {
                long imageId;

                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    try
                    {
                        // Se añaden los tags de la imagen al droplist
                        List<Tag> tags = SessionManager.FindImageTags(imageId);
                        foreach (Tag tag in tags)
                        {
                            ddlTags.Items.Add(new ListItem(tag.title, tag.title));
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        protected void BtnAddTagsClick(object sender, EventArgs e)
        {

            if (Request.Params["id"] != null)
            {
                long imageId;
                List<String> tags = new List<String>();

                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    if(txtAddTags.Text.Length != 0)
                    {
                        String[] tagList = txtAddTags.Text.Split(',');

                        foreach (String name in tagList)
                        {
                            tags.Add(name.Trim());
                        }
                        SessionManager.AddTags(tags, imageId);
                        Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));
                    }
                }
            }
        }

        protected void BtnRemoveTagsClick(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                long imageId;
                List<String> tags = new List<String>();

                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    if (txtRemoveTags.Text.Length != 0)
                    {
                        String[] tagList = txtRemoveTags.Text.Split(',');

                        foreach (String name in tagList)
                        {
                            tags.Add(name.Trim());
                        }

                        SessionManager.RemoveTags(tags, imageId);
                        Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));
                    }
                }
            }
        }
    }
}