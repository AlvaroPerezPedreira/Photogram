<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="DislikedException.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Errors.DislikedException"
    meta:resourcekey="Page" %>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">

    <br />
    <br />
    <asp:Label ID="lblErrorTitle" runat="server"
        meta:resourcekey="lblErrorTitle" />
    <br />
    <br />
    <asp:Label ID="lblDisliked" runat="server"
        meta:resourcekey="lblDislikedLiked" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <asp:Localize ID="lclContent" runat="server" meta:resourcekey="lclContent" />
</asp:Content>