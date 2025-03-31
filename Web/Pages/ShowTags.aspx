<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="ShowTags.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ShowTags" meta:resourcekey="Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    
    <div class="container">
        <div id="seguidosContainer" class="row">
            <!-- Repeater de links a usuarios -->
            <div id="pageTitle">
                <asp:Localize ID="lclShowTagsPage" runat="server" meta:resourcekey="lclShowTagsPage" />
            </div>

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

</asp:Content>
