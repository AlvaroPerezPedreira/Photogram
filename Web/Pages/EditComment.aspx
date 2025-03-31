<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="EditComment.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.EditComment" meta:resourcekey="Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">

    <form id="form1" runat="server">
    <div class="container">

        <div class="field">
                <span class="label">
                    <asp:Localize ID="lclEditComment" runat="server" meta:resourcekey="lclEditComment" /></span>
                    <!-- Donde se escribre el nuevo comentario -->
                    <span
                        class="entry">
                        <asp:TextBox ID="txtEditComment" runat="server" Width="100" Columns="16"></asp:TextBox>
                    </span>
            </div>
        </div>
        <!-- Botón para confirmar la edición del comentario-->
        <asp:Button ID="btnEditComment" runat="server" OnClick="BtnEditCommentClick" meta:resourcekey="btnEditComment" />
    </form>
</asp:Content>