<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" 
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" 
    Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Register" meta:resourcekey="Page" %>

    <asp:Content ID="Content1"
        ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
        runat="server">

        <div id="form">
    <form id="RegisterForm" method="post" runat="server">
      <div class="main-big-container">
        <div class="main-page-container-login">

           <!-- Username -->

          <div>
            <div>
              <asp:Localize
                ID="lclUserName"
                runat="server"
                meta:resourcekey="lclUserName"
              />
            </div>
            <div>
              <span class="entry">
                <asp:TextBox
                  ID="txtLogin"
                  runat="server"
                  Width="150px"
                  Columns="16"
                  meta:resourcekey="txtLoginResource1"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvUserName"
                  runat="server"
                  ControlToValidate="txtLogin"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                  meta:resourcekey="rfvUserNameResource1"
                ></asp:RequiredFieldValidator>
                <asp:Label
                  ID="lblLoginError"
                  runat="server"
                  ForeColor="Red"
                  Style="position: relative"
                  Visible="False"
                  meta:resourcekey="lblLoginError"
                ></asp:Label
              ></span>
            </div>
          </div>

          <!-- Password -->

          <div>
            <div class="field">
              <div>
                <span class="label">
                  <asp:Localize
                    ID="lclPassword"
                    runat="server"
                    meta:resourcekey="lclPassword"
                  />
                </span>
              </div>
              <div>
                <span class="entry">
                  <asp:TextBox
                    TextMode="Password"
                    ID="txtPassword"
                    runat="server"
                    Width="150px"
                    Columns="16"
                    meta:resourcekey="txtPasswordResource1"
                  ></asp:TextBox>
                  <asp:RequiredFieldValidator
                    ID="rfvPassword"
                    runat="server"
                    ControlToValidate="txtPassword"
                    Display="Dynamic"
                    Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvPasswordResource1"
                  ></asp:RequiredFieldValidator
                ></span>
              </div>
            </div>
          </div>

          <!-- Retype Password -->

          <div>
            <div>
              <span class="label">
                <asp:Localize
                  ID="lclRetypePassword"
                  runat="server"
                  meta:resourcekey="lclRetypePassword"
                />
              </span>
            </div>
            <div>
              <span class="entry">
                <asp:TextBox
                  TextMode="Password"
                  ID="txtRetypePassword"
                  runat="server"
                  Width="150px"
                  Columns="16"
                  meta:resourcekey="txtRetypePasswordResource1"
                ></asp:TextBox>
              <asp:RequiredFieldValidator
                ID="rfvRetypePassword"
                runat="server"
                ControlToValidate="txtRetypePassword"
                Display="Dynamic"
                Text="<%$ Resources:Common, mandatoryField %>"
                meta:resourcekey="rfvRetypePasswordResource1"
              ></asp:RequiredFieldValidator>
              </span>
            </div>
          </div>


          <!-- First name -->

          <div>
            <div class="field">
              <div>
                <span class="label">
                  <asp:Localize
                    ID="lclFirstName"
                    runat="server"
                    meta:resourcekey="lclFirstName"
                /></span>
              </div>
              <div>
                <span class="entry">
                  <asp:TextBox
                    ID="txtFirstName"
                    runat="server"
                    Width="150px"
                    Columns="16"
                    meta:resourcekey="txtFirstNameResource1"
                  ></asp:TextBox>
                  </span>
                  <asp:RequiredFieldValidator
                    ID="rfvFirstName"
                    runat="server"
                    ControlToValidate="txtFirstName"
                    Display="Dynamic"
                    Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvFirstNameResource1"
                  ></asp:RequiredFieldValidator
                >
              </div>
            </div>
          </div>

          <!-- Surname -->

          <div>
            <div class="field">
              <div>
                <span class="label">
                  <asp:Localize
                    ID="lclSurname"
                    runat="server"
                    meta:resourcekey="lclSurname"
                /></span>
              </div>
              <div>
                <span class="entry">
                  <asp:TextBox
                    ID="txtSurname"
                    runat="server"
                    Width="150px"
                    Columns="16"
                    meta:resourcekey="txtSurnameResource1"
                  ></asp:TextBox>
                  <asp:RequiredFieldValidator
                    ID="rfvSurname"
                    runat="server"
                    ControlToValidate="txtSurname"
                    Display="Dynamic"
                    Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvSurnameResource1"
                  ></asp:RequiredFieldValidator
                ></span>
              </div>
            </div>
          </div>

          <!-- Email -->

          <div>
            <div class="field">
              <div>
                <span class="label">
                  <asp:Localize
                    ID="lclEmail"
                    runat="server"
                    meta:resourcekey="lclEmail"
                /></span>
              </div>
              <div>
                <span class="entry">
                  <asp:TextBox
                    ID="txtEmail"
                    runat="server"
                    Width="150px"
                    Columns="16"
                    meta:resourcekey="txtEmailResource1"
                  ></asp:TextBox>
                  <asp:RequiredFieldValidator
                    ID="rfvEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    Display="Dynamic"
                    Text="<%$ Resources:Common, mandatoryField %>"
                    meta:resourcekey="rfvEmailResource1"
                  ></asp:RequiredFieldValidator>
                   <!-- Validador de formato email -->
                  <asp:RegularExpressionValidator
                    ID="revEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    Display="Dynamic"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    meta:resourcekey="revEmail"
                  ></asp:RegularExpressionValidator
                ></span>
              </div>
            </div>
          </div>

          <!-- Combo box idioma -->

          <div>
            <div>
              <span class="label">
                <asp:Localize
                  ID="lclLanguage"
                  runat="server"
                  meta:resourcekey="lclLanguage"
              /></span>
              <div>
                <span class="entry">
                  <asp:DropDownList
                    ID="comboLanguage"
                    runat="server"
                    AutoPostBack="True"
                    Width="150px"
                    meta:resourcekey="comboLanguageResource1"
                    OnSelectedIndexChanged="ComboLanguageSelectedIndexChanged"
                  >
                  </asp:DropDownList
                ></span>
              </div>
            </div>
          </div>

          <!-- Combo box país -->

          <div>
            <div>
              <span class="label">
                <asp:Localize
                  ID="lclCountry"
                  runat="server"
                  meta:resourcekey="lclCountry"
              /></span>
            </div>
            <div>
              <span class="entry">
                <asp:DropDownList
                  ID="comboCountry"
                  runat="server"
                  Width="150px"
                  meta:resourcekey="comboCountryResource1"
                >
                </asp:DropDownList
              ></span>
            </div>
          </div>

          <!-- Contraseñas no coinciden -->

          <asp:CompareValidator
            ID="cvPasswordCheck"
            runat="server"
            ControlToCompare="txtPassword"
            ControlToValidate="txtRetypePassword"
            meta:resourcekey="cvPasswordCheck"
          ></asp:CompareValidator>

          <!-- Botón de register -->

          <div >
            <asp:Button
              class="button-register"
              ID="btnRegister"
              runat="server"
              OnClick="BtnRegisterClick"
              meta:resourcekey="btnRegister"
            />
          </div>
        </div>
      </div>
    </form>
  </div>




    </asp:Content>