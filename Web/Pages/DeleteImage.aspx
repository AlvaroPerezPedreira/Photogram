<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="DeleteImage.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.DeleteImage" meta:resourcekey="Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent" runat="server">

    <form id="form1" runat="server">

    <div class="container">
        
        <asp:Image ID="Image1" runat="server" CssClass="img-fluid" style="margin-top:10px; max-width: 500px; max-height: 500px; width: 100%; height: auto;"/>
        
        </div>
            <div style="margin-top: 20px; display: flex; justify-content: center; align-content: center; align-items: center;">
            <asp:Button ID="btnDelete" runat="server" OnClick="BtnDeleteClick" meta:resourcekey="btnDelete" class="btnDislikePg" />
        </div>

    </form>
</asp:Content>