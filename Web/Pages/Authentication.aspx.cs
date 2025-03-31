using System;
using Es.Udc.DotNet.PracticaMaD.Model.UserService.Exceptions;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System.Web.UI;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System.Web.Security;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class Authentication : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPasswordError.Visible = false;
            lblLoginError.Visible = false;
        }

        protected void BtnLoginClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SessionManager.Login(Context, txtLogin.Text, txtPassword.Text, checkRememberPassword.Checked);
                    FormsAuthentication.RedirectFromLoginPage(txtLogin.Text, checkRememberPassword.Checked);
                }
                catch (InstanceNotFoundException)
                {
                    lblLoginError.Visible = true;
                }
                catch (IncorrectPasswordException)
                {
                    lblPasswordError.Visible = true;
                }
            }
        }

        protected void BtnGoogle_Click(object sender, EventArgs e)
        {
            string clientId = "729771401163-amt7lp5k5aauj6qf77alnhfmetp1iupd.apps.googleusercontent.com";

            string redirectUri = "https://localhost:44321/PracticaMaD/Pages/GoogleLogin.aspx";

            string[] scopes = new[] { "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/userinfo.email" };

            string authorizationUrl = $"https://accounts.google.com/o/oauth2/auth?client_id={clientId}&redirect_uri={redirectUri}&scope={string.Join(" ", scopes)}&response_type=code";

            // Redirige al usuario a la página de autorización de Google
            Response.Redirect(authorizationUrl);

        }
    }
}