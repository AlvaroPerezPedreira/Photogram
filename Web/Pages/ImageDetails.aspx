<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master"
    AutoEventWireup="true" CodeBehind="ImageDetails.aspx.cs"
    Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ImageDetails" 
    meta:resourcekey="Page" %>



<asp:Content
  ID="Content1"
  ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
  runat="server"
>
    <div class="image-big-container">
      <div class="imginfo">
        <form id="form2" runat="server" class="miform">

      <div class="container">
        <asp:Image ID="Image1" runat="server" CssClass="img-fluid" style="margin-top:10px; max-width: 500px; max-height: 500px; width: 100%; height: auto; margin-bottom: 20px;"/>
      </div>
          <div class="show-usr-txt">
            <!-- Título -->
            <asp:Label
              ID="lblTitulo"
              runat="server"
              Text="Label"
              meta:resourcekey="lblTitulo"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textTitulo"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- Descripción -->
          <div class="show-usr-txt">
            <asp:Label
              ID="lblDescripcion"
              runat="server"
              Text="Label"
              meta:resourcekey="lblDescripcion"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textDescripcion"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- Fecha -->
          <div class="show-usr-txt">
            <asp:Label
              ID="lblFecha"
              runat="server"
              Text="Label"
              meta:resourcekey="lblFecha"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textFecha"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- Autor -->
          <div class="show-usr-txt">
            <asp:Label
              ID="lblAuthor"
              runat="server"
              Text="Label"
              meta:resourcekey="lblAuthor"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textAuthor"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- Apertura -->
          <div class="show-usr-txt">
            <asp:Label
              ID="lblApertura"
              runat="server"
              Text="Label"
              meta:resourcekey="lblApertura"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="textApertura"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- Exposición -->
           <div class="show-usr-txt">
            <asp:Label
              ID="LabelExposicion"
              runat="server"
              Text="Label"
              meta:resourcekey="lblExposicion"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="TextBoxExposicion"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- ISO -->
           <div class="show-usr-txt">
            <asp:Label
              ID="LabelISO"
              runat="server"
              Text="Label"
              meta:resourcekey="lblISO"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="TextBoxISO"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- White balance -->
           <div class="show-usr-txt">
            <asp:Label
              ID="LabelWB"
              runat="server"
              Text="Label"
              meta:resourcekey="lblWB"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="TextBoxWB"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>

          <!-- Categoría -->
           <div class="show-usr-txt">
            <asp:Label
              ID="LabelCategory"
              runat="server"
              Text="Label"
              meta:resourcekey="lblCategory"
              Style="display: inline-block"
            ></asp:Label>

            <asp:TextBox
              class="show-user-text"
              ID="TextCategory"
              runat="server"
              Enabled="False"
            ></asp:TextBox>
          </div>
        </form>
      </div>
    </div>
</asp:Content>
