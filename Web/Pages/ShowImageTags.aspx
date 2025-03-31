<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="ShowImageTags.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ShowImageTags" meta:resourcekey="Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">
    
        <!-- Tags -->

        <div class="main-big-container">
            <div class="main-page-container">

            <div id="pageTitle">
                <asp:Localize ID="lclShowTags" runat="server" meta:resourcekey="lclShowTags" />
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
