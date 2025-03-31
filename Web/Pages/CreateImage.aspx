<%@ Page Language="C#" MasterPageFile="~/PracticaMaD.Master"
AutoEventWireup="true" Codebehind="CreateImage.aspx.cs"
Inherits="Es.Udc.DotNet.PracticaMaD.Web.Pages.CreateImage" meta:resourcekey="Page" %>

<asp:Content
  ID="Content3"
  ContentPlaceHolderID="ContentPlaceHolder_BodyContent"
  runat="server"
>

  <div id="form">
    <form id="CreateImageForm" method="POST" runat="server">

      <div class="main-big-container">
        <div class="main-page-container">

           <!-- Title -->

          <div class="main-row">

            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclTitle"
                  runat="server"
                  meta:resourcekey="lclTitle"
                />
              </span>
            </div>

            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:TextBox
                  ID="txtTitle"
                  runat="server"
                  Width="150px"
                  Columns="16"
                  meta:resourcekey="txtTitle"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvLogin"
                  runat="server"
                  ControlToValidate="txtTitle"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                />
              </span>
            </div>
          </div>

            <!-- Descripción -->

          <div class="main-row">
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclDescription"
                  runat="server"
                  meta:resourcekey="lclDescription"
              /></span>
            </div>
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:TextBox
                  ID="txtDescription"
                  runat="server"
                  Width="150px"
                  Columns="16"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvDescription"
                  runat="server"
                  ControlToValidate="txtDescription"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                />
              </span>
            </div>
          </div>

            <!-- Url de la imagen -->

          <div class="main-row">
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclUrl"
                  runat="server"
                  meta:resourcekey="lclUrl"
              /></span>
            </div>
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                  <asp:FileUpload
                      ID="Url"
                      runat="server"
                      Width="150px"
                      Columns="16">
                  </asp:FileUpload>

                <asp:RequiredFieldValidator
                  ID="rfvUrl"
                  runat="server"
                  ControlToValidate="Url"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                />
              </span>
            </div>
          </div>

            <!-- Categoría -->

          <div class="main-row">
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclCategory"
                  runat="server"
                  meta:resourcekey="lclCategory"
              /></span>
            </div>
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:DropDownList ID="ddlCategory" runat="server" Width="150px">
                    </asp:DropDownList>
              </span>
            </div>
          </div>

            <!-- Apertura -->

          <div class="main-row">
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclOpening"
                  runat="server"
                  meta:resourcekey="lclOpening"
              /></span>
            </div>
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:TextBox
                  ID="txtOpening"
                  runat="server"
                  Width="150px"
                  Columns="16"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvOpening"
                  runat="server"
                  ControlToValidate="txtOpening"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                />
              </span>
            </div>
          </div>


            <!-- Exposición -->

          <div class="main-row">
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclExposition"
                  runat="server"
                  meta:resourcekey="lclExposition"
              /></span>
            </div>
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:TextBox
                  ID="txtExposition"
                  runat="server"
                  Width="150px"
                  Columns="16"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvExposition"
                  runat="server"
                  ControlToValidate="txtExposition"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                />
              </span>
            </div>
          </div>

            <!-- ISO -->

          <div class="main-row">
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="label">
                <asp:Localize
                  ID="lclISO"
                  runat="server"
                  meta:resourcekey="lclISO"
              /></span>
            </div>
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:TextBox
                  ID="txtISO"
                  runat="server"
                  Width="150px"
                  Columns="16"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvISO"
                  runat="server"
                  ControlToValidate="txtISO"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                />
              </span>
            </div>
          </div>

            <!-- Balance de blancos - White balance -->

          <div class="main-row">
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="lclWb">
                <asp:Localize
                  ID="Localize1"
                  runat="server"
                  meta:resourcekey="lclWb"
              /></span>
            </div>
            <div class="main-column3"
                style="float: left; width: 50%; margin-top: 6px; text-align: left">
              <span class="entry">
                <asp:TextBox
                  ID="txtWb"
                  runat="server"
                  Width="150px"
                  Columns="16"
                ></asp:TextBox>
                <asp:RequiredFieldValidator
                  ID="rfvWb"
                  runat="server"
                  ControlToValidate="txtWb"
                  Display="Dynamic"
                  Text="<%$ Resources:Common, mandatoryField %>"
                />
              </span>
            </div>
           </div>

            <!-- Tags -->

            <div class="field" style="display: flex; justify-content: space-between; width: 300px;">
                <span class="label" style="display: flex; justify-content:left; text-align:left;">
                    <asp:Localize ID="lclTag" runat="server" meta:resourcekey="lclTag" />
                </span>
                <span class="entry" style="display: flex; justify-content:right; text-align:right;">

                    <asp:TextBox 
                        ID="txtTag" 
                        runat="server" 
                        Width="150px" 
                        Columns="16">
                    </asp:TextBox>
                </span>
            </div>

          <!-- Botón de crear imagen -->

          <div class="button">
            <asp:Button
              class="mainpage-button"
              ID="btnCreateImage"
              runat="server"
              OnClick="BtnCreateImageClick"
              meta:resourcekey="btnCreateImage"
            />
          </div>
        </div>
      </div>
    </form>
  </div>
</asp:Content>