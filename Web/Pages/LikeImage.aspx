<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master" AutoEventWireup="true"
    CodeBehind="LikeImage.aspx.cs" Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.LikeImage" meta:resourcekey="Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
    runat="server">

    <form id="form1" runat="server">

    <div class="container">
        <asp:Image ID="Image1" runat="server" CssClass="img-fluid" style="margin-top:10px; max-width: 500px; max-height: 500px; width: 100%; height: auto;"/>
    </div>

        <div style="display: flex; justify-content: center; align-content: center; margin-top: 20px;"> 

            <!-- Número de likes -->
            <p>Número de likes: </p>
            <asp:TextBox
              style="color: black; margin-left: 20px; display: flex; align-content: center; justify-content: center; height: 20px; align-items: center; justify-items: center; margin-top:4px; width: 20px;"
              ID="textLikes"    
              runat="server"
              Enabled="False"
            ></asp:TextBox>
         </div>
       
        <!-- Botón de like y dislike -->        
        <div id="like-buttons"> 
            <asp:Button ID="btnLike" class="btnLikePg" runat="server" OnClick="BtnLikeClick" meta:resourcekey="btnLike" Visible="true" />
            <asp:Button ID="btnDislike" class="btnDislikePg" runat="server" OnClick="BtnDisLikeClick" meta:resourcekey="btnDislike" />
        </div>

    </form>
</asp:Content>