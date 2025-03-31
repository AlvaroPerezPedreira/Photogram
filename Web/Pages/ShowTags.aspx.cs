using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.Properties;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ShowTags : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                long imageId;
                if (long.TryParse(Request.Params["id"], out imageId))
                {
                    // Obtén el bloque de imágenes desde la sesión
                    List<Tag> tags = SessionManager.FindImageTags(imageId);

                    // Vincula la lista de URLs al control Repeater
                    rptTags.DataSource = tags;
                    rptTags.DataBind();
                }
            }
        }

        protected void rptTags_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Acceder al control asp:Image dentro del RepeaterItem
                HyperLink showTagImagesLink = (HyperLink)e.Item.FindControl("lnkTag");

                // Obtener la URL de la imagen del DataItem y establecerla como ImageUrl
                Tag tag = (Tag)e.Item.DataItem;

                showTagImagesLink.NavigateUrl = $"ShowImages.aspx?valorBusqueda={null}&category={"-"}&" + "tags=" + tag.TagId + $"&startindex=0&count={Settings.Default.PracticaMaD_defaultCount}";
                showTagImagesLink.Text = tag.title;

                // Para cambiar el tamaño de la fuente según el uso
                if (tag.usedTimes == 1)
                {
                    showTagImagesLink.Font.Size = new FontUnit(16, UnitType.Pixel);
                }
                else if (tag.usedTimes > 1 && tag.usedTimes <= 5)
                {
                    showTagImagesLink.Font.Size = new FontUnit(22, UnitType.Pixel);
                    showTagImagesLink.ForeColor = Color.Blue;
                }
                else if (tag.usedTimes > 5 && tag.usedTimes <= 10)
                {
                    showTagImagesLink.Font.Size = new FontUnit(28, UnitType.Pixel);
                    showTagImagesLink.ForeColor = Color.Yellow;
                }
                else
                {
                    showTagImagesLink.Font.Size = new FontUnit(50, UnitType.Pixel);
                    showTagImagesLink.ForeColor = Color.Red;
                }
            }
        }
    }
}