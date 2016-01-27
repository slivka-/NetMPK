<%@ Page Title="Strona użytkownika" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserSite.aspx.cs" Inherits="NetMPK.MainFunct.UserSite" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <asp:Label runat="server" ID="wLabel" CssClass="text-success"/>
</asp:Content>
