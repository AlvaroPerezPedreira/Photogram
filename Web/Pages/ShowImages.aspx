<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master"
AutoEventWireup="true" Codebehind="ShowImages.aspx.cs"
Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.ShowImages" meta:resourcekey="Page" %>

<asp:Content
  ID="Content1"
  ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
  runat="server"
>
  <div class="container">
    <form id="ShowImagesForm" runat="server">
      <div
        class="center-div"
       style="display: flex; flex-direction: column;"
      >
        <div class="repeater-div">
          <asp:Repeater ID="rptImages" runat="server" OnItemDataBound="rptImages_ItemDataBound">
            <ItemTemplate>
              <div class="card" style="background-color: darkgray; height: auto;">


                <!-- La imagen -->
                <div id="img-show-imgs">
                    <asp:Image
                      ID="imgDynamic"
                      runat="server"
                      class="card-img-top"
                      CssClass="img-fluid"
                      style="
                        width: 100%;
                        height: auto;
                        margin: 0px;
                      "
                    />
                </div>

               <div class="card-body">
                   <div style="margin-bottom: 10px">
                    <!-- Título -->
                        <h5 class="card-title" id="Titulo" runat="server">
                        </h5>
                      
                    <!-- Nº likes -->
                        <p class="card-text" id="numLikes" runat="server">Nº Likes
                        </p>
                   </div>

                    <!-- Links -->

                    <div class="buttons-img-card" style="">

                    <!-- Link de DetallesImagen -->
                      <asp:HyperLink
                        ID="lnkDetallesImagen"
                        style="color: black"
                        runat="server"
                        class="show-image-link"
                        Visible="true"
                        meta:resourcekey="lnkDetallesImagen"
                      />

                    <!-- Link de LikeImage -->
                      <asp:HyperLink
                        ID="lnkLike"
                        style="color: black"
                        runat="server"
                        class="show-image-link"
                        Visible="true"
                        meta:resourcekey="lnkLike"
                      />

                    <!-- Link de Comment -->
                      <asp:HyperLink
                        ID="lnkComment"
                        style="color: black"
                        runat="server"
                        class="show-image-link"
                        Visible="true"
                        meta:resourcekey="lnkComment"
                      />

                    <!-- Link de Show Comments -->
                      <asp:HyperLink
                        ID="lnkShowComments"
                        style="color: black"
                        runat="server"
                        class="show-image-link"
                        meta:resourcekey="lnkShowComments"
                      />

                    <!-- Link de Delete -->
                      <asp:HyperLink
                        ID="lnkDeleteImage"
                        style="color: black"
                        runat="server"
                        class="show-image-link"
                        Visible="true"
                        meta:resourcekey="lnkDeleteImage"
                      />

                    <!-- Link de EditTags -->
                        <asp:HyperLink
                          ID="lnkEditTags"
                          runat="server"
                          style="color: black"
                          class="show-image-link"
                          Visible="true"
                          meta:resourcekey="lnkEditTag"
                        />

                    <!-- Link de ShowTags -->
                        <asp:HyperLink
                          ID="lnkShowTags"
                          runat="server"
                          style="color: black"
                          class="show-image-link"
                          meta:resourcekey="lnkShowTags"
                        />

                   </div>
                </div>

              </div>
            </ItemTemplate>
          </asp:Repeater>

          <!-- "Previous" and "Next" links. -->


        </div>
                             <div>
          <asp:HyperLink
            ID="lnkPrevious"
            Text="<%$ Resources:Common, Previous %>"
            runat="server"
            Visible="False"
          ></asp:HyperLink>
          <asp:HyperLink
            ID="lnkNext"
            Text="<%$ Resources:Common, Next %>"
            runat="server"
            Visible="False"
          ></asp:HyperLink>
         </div>


      </div>

    </form>


  </div>
</asp:Content>