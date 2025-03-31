<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master"
AutoEventWireup="true" Codebehind="Authentication.aspx.cs"
Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Authentication" meta:resourcekey="Page" %>

<asp:Content
  ID="Content3"
  ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
  runat="server"
>
  
   <!-- Register -->

  <asp:HyperLink
    ID="lnkRegister"
    runat="server"
    NavigateUrl="~/Pages/Register.aspx"
    meta:resourcekey="lnkRegister"
  />

  <div id="form">
    <form id="AuthenticationForm" method="POST" runat="server">

      <div class="main-big-container">
        <div class="main-page-container">

           <!-- Login Name -->

          <div class="main-row">

            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclLogin"
                  runat="server"
                  meta:resourcekey="lclLogin"
                />
              </span>
            </div>

            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:TextBox
                  ID="txtLogin"
                  runat="server"
                  Width="100"
                  Columns="16"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvLogin"
                  runat="server"
                  ControlToValidate="txtLogin"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                  ValidationGroup="NormalLogin"                  
                />
                <asp:Label
                  ID="lblLoginError"
                  runat="server"
                  ForeColor="Red"
                  Style="position: relative"
                  Visible="False"
                  meta:resourcekey="lblLoginError"
                >
                </asp:Label>
              </span>
            </div>
          </div>

            <!-- Password -->

          <div class="main-row">
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclPassword"
                  runat="server"
                  meta:resourcekey="lclPassword"
              /></span>
            </div>
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:TextBox
                  TextMode="Password"
                  ID="txtPassword"
                  runat="server"
                  Width="100"
                  Columns="16"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvPassword"
                  runat="server"
                  ControlToValidate="txtPassword"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                  ValidationGroup="NormalLogin"                  
                />
                <asp:Label
                  ID="lblPasswordError"
                  runat="server"
                  ForeColor="Red"
                  Style="position: relative"
                  Visible="False"
                  meta:resourcekey="lblPasswordError"
                >
                </asp:Label>
              </span>
            </div>
          </div>

          <!-- Check de recordar contraseña -->

          <div class="checkbox checkbox-login">
            <asp:CheckBox
              ID="checkRememberPassword"
              runat="server"
              TextAlign="Left"
              meta:resourcekey="checkRememberPassword"
            />
          </div>

          <!-- Botón de login -->

          <div class="button">
            <asp:Button
              class="button-register"
              ID="btnLogin"
              runat="server"
              OnClick="BtnLoginClick"
              meta:resourcekey="btnLogin"
              ValidationGroup="NormalLogin"                  
            />
          </div>

          <!-- Botón de login por google -->
          <div>
              <asp:LinkButton 
                  ID="BtnGoogle" 
                  runat="server" 
                  Width="300" 
                  data-provider="google" 
                  OnClick="BtnGoogle_Click" 
                  meta:resourcekey="BtnGoogle"
                  ValidationGroup="GoogleLogin"                                  
                />
          </div>
        </div>
      </div>
    </form>
  </div>
</asp:Content>