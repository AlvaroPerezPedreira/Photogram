﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Es.Udc.DotNet.PracticaMaD.Model.UserService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.View.ApplicationObjects;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class UpdateProfile : SpecificCulturePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserProfileDetails userProfileDetails = SessionManager.FindUserProfileDetails(Context);

                txtFirstName.Text = userProfileDetails.FirstName;
                txtSurname.Text = userProfileDetails.Lastname;
                txtEmail.Text = userProfileDetails.Email;

                /* Combo box initialization */
                UpdateComboLanguage(userProfileDetails.Language);
                UpdateComboCountry(userProfileDetails.Language, userProfileDetails.Country);

            }
        }

        /// <summary>
        /// Loads the languages in the comboBox in the *selectedLanguage*. 
        /// Also, the selectedLanguage will appear selected in the 
        /// ComboBox
        /// </summary>
        private void UpdateComboLanguage(String selectedLanguage)
        {
            this.comboLanguage.DataSource = Languages.GetLanguages(selectedLanguage);
            this.comboLanguage.DataTextField = "text";
            this.comboLanguage.DataValueField = "value";
            this.comboLanguage.DataBind();
            this.comboLanguage.SelectedValue = selectedLanguage;
        }

        /// <summary>
        /// Loads the countries in the comboBox in the *selectedLanguage*. 
        /// Also, the *selectedCountry* will appear selected in the 
        /// ComboBox
        /// </summary>
        private void UpdateComboCountry(String selectedLanguage, String selectedCountry)
        {
            this.comboCountry.DataSource = Countries.GetCountries(selectedLanguage);
            this.comboCountry.DataTextField = "text";
            this.comboCountry.DataValueField = "value";
            this.comboCountry.DataBind();
            this.comboCountry.SelectedValue = selectedCountry;
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance 
        /// containing the event data.</param>
        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            if(IsValid)
            {
                UserProfileDetails userProfileDetails = new UserProfileDetails(txtFirstName.Text, txtSurname.Text, txtEmail.Text, comboLanguage.SelectedValue, comboCountry.SelectedValue);

                SessionManager.UpdateUserProfileDetails(Context, userProfileDetails);

                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Home.aspx"));
            }
        }

        protected void ComboLanguageSelectedIndexChanged(object sender, EventArgs e)
        {
            /* Si se cambia el idioma, se actualiza la lista de paises al idioma seleccionado */

            this.UpdateComboCountry(comboLanguage.SelectedValue, comboCountry.SelectedValue);
        }
    }
}