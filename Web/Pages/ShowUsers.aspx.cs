using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ShowUsers : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
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

            string lnkRecibido = Request.QueryString["lnk"];
            string valorRecibido = Request.QueryString["valorBusqueda"];

            UsersBlock usersBlock;

            if (lnkRecibido == "seguidores")
            {
                usersBlock = SessionManager.FindAllSeguidores(Context, valorRecibido, startIndex, count);
            }
            else
            {
                usersBlock = SessionManager.FindAllSeguidos(Context, valorRecibido, startIndex, count);
            }

            List<UserProfile> users = usersBlock.Users;

            rptSeguidos.DataSource = users;
            rptSeguidos.DataBind();

            /* "Previous" link */
            if ((startIndex - count) >= 0)
            {
                String url =
                    Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowUsers.aspx?lnk=" + lnkRecibido + "valorBusqueda=" + valorRecibido + "&startindex=" + (startIndex - count) + "&count=" + count;

                this.lnkPrevious.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkPrevious.Visible = true;
            }

            /* "Next" link */
            if (usersBlock.ExistMoreUsers)
            {
                String url =
                    Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowUsers.aspx?lnk=" + lnkRecibido + "valorBusqueda = " + valorRecibido + "&startindex=" + (startIndex + count) + "&count=" + count;

                this.lnkNext.NavigateUrl =
                    Response.ApplyAppPathModifier(url);
                this.lnkNext.Visible = true;
            }
        }
        protected void rptUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Acceder al control link del usuario dentro del RepeaterItem
                HyperLink showUserProfileLink = (HyperLink)e.Item.FindControl("lnkUserProfile");

                // Me traigo el userprofile
                UserProfile user = (UserProfile)e.Item.DataItem;

                // Le asigno el link
                showUserProfileLink.NavigateUrl = "ShowUserProfile.aspx?valorBusqueda=" + user.loginName + "&startindex=" + 0 + " &count =" + 3;
                showUserProfileLink.Text = user.loginName;
            }
        }
    }
}