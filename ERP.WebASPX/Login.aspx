<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ERP.WebASPX.Login" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxFormLayout ID="uiLayout" runat="server" RequiredMarkDisplayMode="RequiredOnly" EnableViewState="false" 
        EncodeHtml="false" UseDefaultPaddings="false" Width="100%"
        >
        <Items>
            <dx:LayoutGroup ShowCaption="False">
                <Items>
                    <dx:LayoutItem Caption="Usuario" HelpText="Ingresa tu nombre de usuario">
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer>
                              <dx:ASPxTextBox ID="uiUsuario" runat="server" Width="100%">

                                  <ValidationSettings>
                                      <RequiredField IsRequired="True" />
                                  </ValidationSettings>

                              </dx:ASPxTextBox>
                          </dx:LayoutItemNestedControlContainer>
                           
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                    <dx:LayoutItem Caption="Password" HelpText="Ingresa tu contraseña">
                        <LayoutItemNestedControlCollection>
                            <dx:LayoutItemNestedControlContainer>
                                <dx:ASPxTextBox ID="uiPassword" runat="server" Width="170px"></dx:ASPxTextBox>
                            </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                    </dx:LayoutItem>
                </Items>
            </dx:LayoutGroup>
        </Items>
    </dx:ASPxFormLayout>
</asp:Content>
