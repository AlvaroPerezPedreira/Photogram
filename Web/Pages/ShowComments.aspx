<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="ShowComments.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ShowComments" meta:resourcekey="Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    <form id="form1" runat="server">

        <div class="container">

            <div id="commentsContainer" class="row">

                <!-- Imagen de los comentarios -->
                <asp:Image ID="Image1" runat="server" CssClass="img-fluid" Style="margin-top: 10px; max-width: 500px; max-height: 500px; width: 100%; height: auto;" />

                <asp:Repeater ID="rptComments" runat="server" OnItemDataBound="rptComments_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-4 col-sm-6 mb-4">

                            <div class="row">
                                <div class="image-page-container">
                                    <div class="field">
                                        <p id="CommentD" runat="server"></p>

                                        <!-- Link para ir al usuario del comentario -->
                                        <asp:HyperLink
                                            ID="lnkUsuario"
                                            runat="server"
                                            class="show-image-link"
                                            Visible="true" />

                                        <p id="Fecha" runat="server"></p>

                                        <!-- Link para editar comentario -->
                                        <asp:HyperLink
                                            ID="lnkEditarComentario"
                                            runat="server"
                                            class="show-image-link"
                                            Visible="true"
                                            meta:resourcekey="lnkEditarComentario" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <!-- "Previous" and "Next" links. -->

                <asp:HyperLink ID="lnkPrevious" Text="<%$ Resources:Common, Previous %>" runat="server" Visible="False"></asp:HyperLink>
                <asp:HyperLink ID="lnkNext" Text="<%$ Resources:Common, Next %>" runat="server" Visible="False"></asp:HyperLink>
            </div>
        </div>

    </form>


</asp:Content>
