<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="ShowUsers.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ShowUsers" meta:resourcekey="Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    
    <div class="container">
        <div id="seguidosContainer" class="row">
            <!-- Repeater de links a usuarios -->
            <div id="pageTitle">
                <asp:Localize ID="lclShowUsersPage" runat="server" meta:resourcekey="lclShowUsersPage" />
            </div>
            <asp:Repeater ID="rptSeguidos" runat="server" OnItemDataBound="rptUsers_ItemDataBound">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-4 col-sm-6 mb-4">
                        <asp:HyperLink ID="lnkUserProfile" runat="server" class="show-image-link" Visible="true" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <!-- "Previous" and "Next" links. -->
            <asp:HyperLink ID="lnkPrevious" Text="<%$ Resources:Common, Previous %>" runat="server" Visible="False"></asp:HyperLink>
            <asp:HyperLink ID="lnkNext" Text="<%$ Resources:Common, Next %>" runat="server" Visible="False"></asp:HyperLink>
        </div>
    </div>

</asp:Content>
