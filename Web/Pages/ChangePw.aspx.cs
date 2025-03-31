using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.PracticaMaD.Model.UserService.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ChangePw : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOldPasswordError.Visible = false;
        }

        protected void BtnChangePasswordClick(object sender, EventArgs e)
        {
            if(Page.IsValid) //Comprueba los validadores
            {
                try
                {
                    SessionManager.ChangePassword(Context, txtOldPassword.Text, txtNewPassword.Text);

                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));
                }
                catch (IncorrectPasswordException)
                {
                    lblOldPasswordError.Visible = true;
                }
            }
        }
    }
}