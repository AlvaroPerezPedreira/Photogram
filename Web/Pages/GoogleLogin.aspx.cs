using Es.Udc.DotNet.PracticaMaD.Model.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class GoogleLogin : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string authorizationCode = Request.QueryString["code"];

            string clientId = "729771401163-amt7lp5k5aauj6qf77alnhfmetp1iupd.apps.googleusercontent.com";
            string clientSecret = "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";
            string redirectUri = "https://localhost:44321/PracticaMaD/Pages/GoogleLogin.aspx";

            string[] scopes = new[] { "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/userinfo.email" };

            GoogleAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                Scopes = scopes
            });


            var token = flow.ExchangeCodeForTokenAsync("", authorizationCode, redirectUri, System.Threading.CancellationToken.None).Result;

            if (token != null)
            {
                var credential = new UserCredential(flow, "user", token);

                var service = new Oauth2Service(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential
                });

                var userInfo = service.Userinfo.Get().Execute();

                if (SessionManager.UserExists(userInfo.Email.Split('@')[0]))
                {
                    SessionManager.Login(Context, userInfo.Email.Split('@')[0], userInfo.Email, true);

                    FormsAuthentication.RedirectFromLoginPage(userInfo.Email.Split('@')[0], true);
                }
                else
                {
                    UserProfileDetails details = new UserProfileDetails(userInfo.GivenName, userInfo.FamilyName, userInfo.Email, userInfo.Locale, userInfo.Locale);

                    SessionManager.RegisterUser(Context, userInfo.Email.Split('@')[0], userInfo.Email, details);

                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));
                }
            }
            else
            {
                Response.Write("Error en la autorización.");
            }
        }
    }
}