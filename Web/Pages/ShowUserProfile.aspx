<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master"
AutoEventWireup="true" CodeBehind="ShowUserProfile.aspx.cs"
Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ShowUserProfile"
meta:resourcekey="Page" %>

<asp:Content
  ID="Content1"
  ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
  runat="server"
>
  <div class="user-container">
    <div class="form-style-2">
      <div
        class="form-style-2-heading"
        style="
          font-weight: bold;
          font-style: italic;
          font-size: 15px;
          padding-bottom: 3px;
          margin-bottom: 20px;
          border-bottom: 2px solid #ddd;
        "
      >
        <h1>Perfil de Usuario</h1>
      </div>
    </div>

    <div class="image-big-container">
      <div class="userinfo">
        <form id="form2" runat="server" class="miform">
          
          <!-- login name -->
          <div class="show-usr-txt">  
            <asp:Label
              ID="lblLoginName"
              runat="server"
              Text="Label"
              meta:resourcekey="lblLoginName"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              style="color: black"
              ID="textLoginName"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- first name -->
          <div class="show-usr-txt">
            <asp:Label
              ID="lblFirstName"
              runat="server"
              Text="Label"
              meta:resourcekey="lblFirstName"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textFirstName"
              style="color: black"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- last name -->
          <div class="show-usr-txt">
            <asp:Label
              ID="lblLastName"
              runat="server"
              Text="Label"
              meta:resourcekey="lblLastName"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textLastName"
              style="color: black"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- email -->
          <div class="show-usr-txt">
            <asp:Label
              ID="lblEmail"
              runat="server"
              Text="Label"
              meta:resourcekey="lblEmail"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textEmail"
              style="color: black"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- country -->
          <div class="show-usr-txt">
            <asp:Label
              ID="lblCountry"
              runat="server"
              Text="Label"
              meta:resourcekey="lblCountry"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textCountry"
              style="color: black"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

           <!-- Show seguidos/seguidores -->
            <div
            style="
              margin-top: 20px;
              display: flex;
              gap: 20px;
              justify-content: center;
              padding: 12px;
            "
            >
            <asp:HyperLink
              ID="lnkShowSeguidores"
              runat="server"
              class="show-image-link"
              Visible="true"
              meta:resourcekey="lnkShowSeguidores"
            />

            <asp:HyperLink
              ID="lnkShowSeguidos"
              runat="server"
              class="show-image-link"
              Visible="true"
              meta:resourcekey="lnkShowSeguidos"
            />
          </div>

          <!-- Botón de follow/unfollow -->
          <div style="margin-top: 10px">
            <asp:Button
                ID="btnFollow"
                runat="server"
                OnClick="Follow_Click"
                meta:resourcekey="btnFollow"
                style="margin-top: 5px"
            />

            <asp:Button
              ID="btnUnfollow"
              runat="server"
              OnClick="Unfollow_Click"
              meta:resourcekey="btnUnfollow"
              style="margin-top: 5px"
            />
          </div>


        </form>
      </div>
    </div>

    <!-- Imagenes del usuario -->
    <div class="img-container-user">
      <h1 class="img-title">Images</h1>
    </div>

    <asp:Repeater ID="rptUsrImages" runat="server">
      <ItemTemplate>
        <div style="margin-bottom: 90px">
          <asp:Image
            ID="usrImgDynamic"
            runat="server"
            ImageUrl="<%# Container.DataItem %>"
            CssClass="img-fluid"
            Style="margin-top: 20px; max-width: 500px; max-height: 500px; width: 100%; height: auto;"
          />
        </div>
      </ItemTemplate>
    </asp:Repeater>

    <!-- "Previous" and "Next" links. -->

    <div style="margin-bottom: 200px">
      <asp:HyperLink
        ID="lnkPrevious"
        Text="<%$ Resources:Common, Previous %>"
        runat="server"
        Visible="False"
      ></asp:HyperLink>
      <asp:HyperLink
        ID="lnkNext"
        Text="<%$ Resources:Common, Next %>"
        runat="server"
        Visible="False"
      ></asp:HyperLink>
    </div>
  </div>
</asp:Content>