<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="Comment.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.Comment" meta:resourcekey="Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">

    <form id="form1" runat="server">
        <div class="container">
            
            <!-- Imagen -->

            <asp:Image ID="Image1" runat="server" CssClass="img-fluid" Style="margin-top: 10px; max-width: 500px; max-height: 500px; width: 100%; height: auto;" />
            <br />
            <div class="field comment-text">


                <!-- Input del comentario -->
                <span>
                    <asp:Localize ID="lclComment" runat="server" meta:resourcekey="lclComment" /></span><span>
                        <asp:TextBox ID="txtComment" runat="server" Width="200" Columns="32"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvComment" runat="server"
                            ControlToValidate="txtComment" Display="Dynamic" Text="<%$ Resources:Common, mandatoryField %>" />
                    </span>
            </div>

        </div>

        <!-- Botón de comentar -->

        <div class="comment-button">
            <asp:Button ID="btnComment" runat="server" OnClick="BtnCommentClick" meta:resourcekey="btnComment" class="mainpage-button" />
        </div>

    </form>
</asp:Content>
