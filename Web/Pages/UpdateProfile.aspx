<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master"
AutoEventWireup="true" Codebehind="UpdateProfile.aspx.cs"
Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.UpdateProfile"
meta:resourcekey="Page" %>

<asp:Content
  ID="Content3"
  ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
  runat="server"
>
  <div id="form">
    <form id="UpdateProfileForm" method="POST" runat="server">
      <div class="main-big-container">
        <div class="main-page-container">

        <!-- First name -->

          <div
            class="field"
            style="display: flex; justify-content: space-between; width: 200px"
          >
            <span class="label" style="display: flex; justify-content:left; text-align:left;">
              <asp:Localize
                ID="lclFirstName"
                runat="server"
                meta:resourcekey="lclFirstName"
              /> </span
            ><span class="entryUpdate">
              <asp:TextBox
                ID="txtFirstName"
                runat="server"
                Width="100"
                Columns="16"
              ></asp:TextBox>
              <asp:RequiredFieldValidator
                ID="rfvFirstName"
                runat="server"
                ControlToValidate="txtFirstName"
                Display="Dynamic"
                Text="<%$ Resources:Common, mandatoryField %>"
            /></span>
          </div>

        <!-- Surname -->

          <div class="field" style="display: flex; justify-content: space-between; width: 200px">
            <span class="label" style="display: flex; justify-content:left; text-align:left;"
              ><asp:Localize
                ID="lclSurname"
                runat="server"
                meta:resourcekey="lclSurname" /></span
            ><span class="entry" style="display: flex; justify-content:right; text-align:right;">
              <asp:TextBox
                ID="txtSurname"
                runat="server"
                Width="100"
                Columns="16"
              ></asp:TextBox>
              <asp:RequiredFieldValidator
                ID="rfvSurname"
                runat="server"
                ControlToValidate="txtSurname"
                Display="Dynamic"
                Text="<%$ Resources:Common, mandatoryField %>"
            /></span>
          </div>

        <!-- Email -->

          <div class="field" style="display: flex; justify-content: space-between; width: 200px">
            <span class="label" style="display: flex; justify-content:left; text-align:left;"
              ><asp:Localize
                ID="lclEmail"
                runat="server"
                meta:resourcekey="lclEmail" /></span
            ><span class="entry" style="display: flex; justify-content:right; text-align:right;">
              <asp:TextBox
                ID="txtEmail"
                runat="server"
                Width="100"
                Columns="16"
              ></asp:TextBox>
              <asp:RequiredFieldValidator
                ID="rfvEmail"
                runat="server"
                ControlToValidate="txtEmail"
                Display="Dynamic"
                Text="<%$ Resources:Common, mandatoryField %>" />
              <!-- Validador de formato de correo -->
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

          <!-- Idioma -->

          <div class="field" style="display: flex; justify-content: space-between; width: 200px">
            <span class="label" style="display: flex; justify-content:left; text-align:left;"
              ><asp:Localize
                ID="lclLanguage"
                runat="server"
                meta:resourcekey="lclLanguage" /></span
            ><span class="entry" style="display: flex; justify-content:right; text-align:right;">
              <asp:DropDownList
                ID="comboLanguage"
                runat="server"
                AutoPostBack="True"
                Width="100px"
                onselectedindexchanged="ComboLanguageSelectedIndexChanged"
              >
              </asp:DropDownList
            ></span>
          </div>

          <!-- País -->

          <div class="field" style="display: flex; justify-content: space-between; width: 200px">
            <span class="label" style="display: flex; justify-content:left; text-align:left;"
              ><asp:Localize
                ID="lclCountry"
                runat="server"
                meta:resourcekey="lclCountry" /></span
            ><span class="entry" style="display: flex; justify-content:right; text-align:right;">
              <asp:DropDownList ID="comboCountry" runat="server" Width="100px">
              </asp:DropDownList
            ></span>
          </div>

          <!-- Change Pw -->

          <asp:HyperLink
            ID="lnkChangePassword"
            runat="server"
            NavigateUrl="~/Pages/ChangePw.aspx"
            meta:resourcekey="lnkChangePassword"
          />

          <!-- Botón de Update -->

          <div class="button">
            <asp:Button
              ID="btnUpdate"
              runat="server"
              OnClick="BtnUpdateClick"
              meta:resourcekey="btnUpdate"
            />
          </div>
        </div>
      </div>
    </form>
  </div>
</asp:Content>