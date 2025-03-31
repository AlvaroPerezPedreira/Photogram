using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.Properties;

namespace Es.Udc.DotNet.PracticaMaD.Web
{
    public partial class PracticaMaD : System.Web.UI.MasterPage
    {

        public static readonly String USER_SESSION_ATRIBUTE = "userSession";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Link de home
            if (lblDash5 != null)
            {
                lblDash5.Visible = true;
            }
            if (lnkHome != null)
            {
                lnkHome.Visible = true;
            }


            if (!SessionManager.IsUserAuthenticated(Context)) //En caso de no estar autenticado
            {

                if (lblDash2 != null)
                {
                    lblDash2.Visible = false;
                }
                if (lnkUpdate != null)
                {
                    lnkUpdate.Visible = false;
                }

                if (lblDash3 != null)
                {
                    lblDash3.Visible = false;
                }
                if (lnkLogout != null)
                {
                    lnkLogout.Visible = false;
                }

                if (lblDash4 != null)
                {
                    lblDash4.Visible = false;
                }
                if (lnkCreateImage != null)
                {
                    lnkCreateImage.Visible = false;
                }

                if (lblDash7 != null)
                    lblDash7.Visible = false;

                if (lnkShowSeguidores != null)
                    lnkShowSeguidores.Visible = false;

                if (lblDash6 != null)
                    lblDash6.Visible = false;

                if (lnkShowSeguidos != null)
                    lnkShowSeguidos.Visible = false;

            }
            else // En caso de estar autenticado
            {
                if(lblWelcome != null)
                {
                    lblWelcome.Text = GetLocalResourceObject("lblWelcome.Hello.Text").ToString() + " " + SessionManager.GetUserSession(Context).FirstName;
                }
                if(lblDash1 != null)
                {
                    lblDash1.Visible = false;
                }
                if(lnkAuthenticate != null)
                {
                    lnkAuthenticate.Visible = false;
                }

                UserSession userSession = SessionManager.GetUserSession(Context);
                UserProfile user = SessionManager.FindUserById(userSession.UserProfileId);

                lnkShowSeguidores.NavigateUrl = Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowUsers.aspx?lnk = seguidores" + "&valorBusqueda=" + user.loginName + " &startindex=" + 0 + "&count=" + Settings.Default.PracticaMaD_defaultCount;
                lnkShowSeguidos.NavigateUrl = Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowUsers.aspx?lnk = seguidos" + "&valorBusqueda=" + user.loginName + " &startindex=" + 0 + "&count=" + Settings.Default.PracticaMaD_defaultCount;
            }
        }
    }
}