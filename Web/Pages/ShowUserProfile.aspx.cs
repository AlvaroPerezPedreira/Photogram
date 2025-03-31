using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.ImageService;
using Es.Udc.DotNet.PracticaMaD.Model.UserService;

using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.Properties;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ShowUserProfile : SpecificCulturePage
    {
        public long userIdFinal = -1;

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


            string userLogin = Request.QueryString["login"];
            textLoginName.Text = userLogin;

            try
            {
                UserProfile userProfile = SessionManager.FindUser(userLogin);

                ImageBlock imageBlock = SessionManager.FindImagesByUserIdentifier(Convert.ToInt64(userProfile.usrId), userLogin, startIndex, count);

                userIdFinal = userProfile.usrId;
                textFirstName.Text = userProfile.firstName;
                textLastName.Text = userProfile.lastName;
                textEmail.Text = userProfile.email;
                textCountry.Text = userProfile.country;

                lnkShowSeguidores.NavigateUrl = Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowUsers.aspx?lnk=seguidores" + "&valorBusqueda=" + userLogin + "&startindex =" + 0 + " & count = " + Settings.Default.PracticaMaD_defaultCount;
                lnkShowSeguidos.NavigateUrl = Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowUsers.aspx?lnk=seguidos" + "&valorBusqueda=" + userLogin + "&startindex =" + 0 + " & count = " + Settings.Default.PracticaMaD_defaultCount;

                // Convierte la lista de imágenes a base64
                List<string> imageUrls = ConvertImagesToBase64(imageBlock.Images);

                // Vincula la lista de URLs al control Repeater
                rptUsrImages.DataSource = imageUrls;
                rptUsrImages.DataBind();

                /* "Previous" link */
                if ((startIndex - count) >= 0)
                {
                    String url =
                        Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowUserProfile.aspx?login=" + userLogin + "&startindex=" + (startIndex - count) + "&count=" + count;

                    this.lnkPrevious.NavigateUrl =
                        Response.ApplyAppPathModifier(url);
                    this.lnkPrevious.Visible = true;
                }

                /* "Next" link */
                if (imageBlock.ExistMoreImages)
                {
                    String url =
                        Settings.Default.PracticaMaD_applicationURL + "/Pages/ShowUserProfile.aspx?login=" + userLogin + "&startindex=" + (startIndex + count) + "&count=" + count;

                    this.lnkNext.NavigateUrl =
                        Response.ApplyAppPathModifier(url);
                    this.lnkNext.Visible = true;
                }
                
                if(SessionManager.UserFollowUser(Context, userProfile.usrId))
                {
                    btnFollow.Visible = false;
                    btnUnfollow.Visible = true;
                }
                else
                {
                    btnFollow.Visible = true;
                    btnUnfollow.Visible = false;
                }

            }
            catch (InstanceNotFoundException)
            {
                Response.Redirect(Response.
                    ApplyAppPathModifier("~/Pages/Errors/UserNotFoundException.aspx"));
            }

        }

        private List<string> ConvertImagesToBase64(List<ImageSet> images)
        {
            return images.Select(image => "data:image;base64," + Convert.ToBase64String(image.Data)).ToList();
        }

        protected void Follow_Click(object sender, EventArgs e)
        {
            if (userIdFinal != -1)
            {
                SessionManager.followUser(Context, userIdFinal);
                Response.Redirect(Response.ApplyAppPathModifier(Request.RawUrl));

            }
        }

        protected void Unfollow_Click(object sender, EventArgs e)
        {
            if (userIdFinal != -1)
            {
                SessionManager.unfollowUser(Context, userIdFinal);
                Response.Redirect(Response.ApplyAppPathModifier(Request.RawUrl));
            }
        }
    }
}