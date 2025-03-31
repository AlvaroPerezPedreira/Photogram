<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="EditTags.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.EditTags" meta:resourcekey="Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">

    <form id="form1" runat="server">

        <div class="main-big-container">
        <div class="main-page-container">

            <div class="field" style="display: flex; justify-content: space-between; width: 200px;">

                <!-- Etiqueta de la droplist -->                    
                <span class="label" style="display: flex; justify-content:left; text-align:left;">
                    <asp:Localize ID="lclTags" runat="server" Text="<%$ Resources:Common, lclTags %>" />
                </span>

                <span class="entry" style="display: flex; justify-content:right; text-align:right;">

                <br />

                <!-- Droplist de los tags de la imagen -->                    
                <asp:DropDownList ID="ddlTags" runat="server" Width="100px">
                    </asp:DropDownList>
                </span>

            </div>

            <!-- Para añadir tags -->                                
            <div class="main-row">
                <div class="main-column">
                    <span class="main-entry">
                        <asp:TextBox class="main-txt" 
                            ID="txtAddTags" 
                            runat="server" 
                            Columns="16">
                        </asp:TextBox>
                    </span>  
                </div>

                <div class="main-column">
                    <asp:Button class="main-btn" 
                        ID="btnAddTags" 
                        runat="server" 
                        OnClick="BtnAddTagsClick" 
                        meta:resourcekey="btnAddTags" />
                </div>
            </div>

            <!-- Para borrar tags -->                                
            <div class="main-row last">
                <div class="main-column">
                    <span class="main-entry">
                        <asp:TextBox class="main-txt" 
                            ID="txtRemoveTags" 
                            runat="server" 
                            Columns="16">
                        </asp:TextBox>
                    </span>  
                </div>

                <div class="main-column">
                    <asp:Button class="main-btn" 
                        ID="btnRemoveTags" 
                        runat="server" 
                        OnClick="BtnRemoveTagsClick" 
                        meta:resourcekey="btnRemoveTags" />
                </div>

            </div>

        </div>
     </div>

    </form>
</asp:Content>