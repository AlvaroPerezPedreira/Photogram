using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class CreateImage : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Para darle valores al desplegable de categoría la primera vez */
            if(!IsPostBack)
            {
                UpdateComboCategory();
            }
        }


        /* Darle valores al desplegable */
        private void UpdateComboCategory()
        {
            try
            {
                List<string> categories = SessionManager.FindAllCategoryNames();

                foreach (string category in categories)
                {
                    ddlCategory.Items.Add(new ListItem(category, category));
                }
            }
            catch (Exception ex)
            {

            }
        }

        /* Cuando se le da al botón de crear imagen */
        protected void BtnCreateImageClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    List<String> tags = new List<string>();
                    string selectedCategory = ddlCategory.SelectedValue;

                    if(!(txtTag.Text.Length == 0))
                    {
                        String[] tagList = txtTag.Text.Split(',');
                        foreach (String name in tagList)
                        {
                            tags.Add(name.Trim());
                        }
                    }

                    ImageSet image = SessionManager.CreateImage(Context, txtTitle.Text, txtDescription.Text, Url.FileBytes, selectedCategory, txtOpening.Text, txtExposition.Text, txtISO.Text, txtWb.Text);

                    if (!(txtTag.Text.Length == 0))
                    {
                        SessionManager.AddTags(tags, image.Id);
                    }

                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));
                }
                catch (DuplicateInstanceException)
                {

                }
            }
        }
    }
}