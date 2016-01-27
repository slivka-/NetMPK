<%@ Page Title="Zaloguj się" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotLoggedIn.aspx.cs" Inherits="NetMPK.MainFunct.NotLoggedIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="jumbotron">
        <h1>Nie jesteś zalogowany!</h1>
        <p class="lead">Jeśli chcesz uzyskać dostęp do funkcji naszego serwisu musisz się zalogować.</p>
        <p>Nie masz jeszcze konta?</p>
        <p><a runat="server" href="~/Account/Register.aspx" class = "btn btn-primary btn-lg">Zarejestruj się »</a></p>
    </div>
 
    </div>
</asp:Content>
