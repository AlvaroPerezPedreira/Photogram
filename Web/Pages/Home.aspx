<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master"
    AutoEventWireup="true" CodeBehind="Home.aspx.cs" 
    Inherits="Es.Udc.DotNet.PracticaMaD.Web.Home" meta:resourcekey="Page"%>

<asp:Content
  ID="Content1"
  ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
  runat="server"
>
  <form id="form1" runat="server">
    <br />

    <div class="main-big-container">
      <div class="main-page-container">

        <!-- Sobreescribe el pageTitle de Master -->
        <div id="pageTitle">
            <asp:Localize ID="lclHomePage" runat="server" meta:resourcekey="lclHomePage" />
        </div>

        <!-- Buscador -->

        <div class="main-row">
          <div class="main-column">
            <span class="main-entry">
              <asp:Label
                  ID="lblBuscarImagen"
                  runat="server"
                  meta:resourcekey="lblBuscarImagen"
                  Style="display: inline-block"
              ></asp:Label>

              <asp:TextBox
                class="main-txt"
                ID="txtBuscar"
                runat="server"
                Columns="16"
              ></asp:TextBox>
            </span>
          </div>

        <!-- Desplegable de categoría -->

          <asp:DropDownList
            ID="ddlCategory"
            runat="server"
            Width="100px"
            placeholder="Categoría"
          >
          </asp:DropDownList>
        </div>

        <!-- Botón de buscar -->

        <div>
          <asp:Button
            class="mainpage-button mt3"
            ID="btnBuscar"
            runat="server"
            OnClick="BtnBuscarClick"
            meta:resourcekey="btnBuscarImage"
            ValidationGroup="BuscarImagen"
          />
        </div>

        <!-- Buscador de usuarios -->

        <div class="main-row last" style="margin-top: 20px;">
          <div class="main-column">
            <span class="main-entry">
              <asp:Label
                  ID="lblBuscarUser"
                  runat="server"
                  meta:resourcekey="lblBuscarUser"
                  Style="display: inline-block"
              ></asp:Label>
              <asp:TextBox
                class="main-txt"
                ID="txtBuscar2"
                runat="server"
                Columns="16"
                meta:resourcekey="txtBuscarResource2"
              ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvBuscarUser"
                  runat="server"
                  ControlToValidate="txtBuscar2"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                  ValidationGroup="BuscarUser"
                />
            </span>
          </div>
        </div>

        <!-- Botón del buscador de usuarios -->
        <div>
          <asp:Button
            class="mainpage-button mt2"
            ID="btnBuscar2"
            runat="server"
            OnClick="BtnBuscarClick2"
            meta:resourcekey="btnBuscarUsuario"
            ValidationGroup="BuscarUser"
          />
        </div>

      </div>
    </div>

        <!-- Tags -->

        <div class="main-big-container">
            <div class="main-page-container">
                <div class="repeater-div">
                  <asp:Repeater ID="rptTags" runat="server" OnItemDataBound="rptTags_ItemDataBound">
                    <ItemTemplate>
                        <asp:HyperLink
                          ID="lnkTag"
                          runat="server"
                          class="show-image-link"                    
                          Visible="true"
                        />
                    </ItemTemplate>
                  </asp:Repeater>
               </div>
            </div>
        </div>

    <br />
  </form>
</asp:Content>