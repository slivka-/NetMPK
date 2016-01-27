<%@ Page Title="Zaloguj się" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotLoggedIn.aspx.cs" Inherits="NetMPK.MainFunct.NotLoggedIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var closing = true;
        $(function () {
            $("a,input[type=submit]").click(function () { closing = false; });
            $(window).unload(function () {
                if (closing) {
                    jQuery.ajax({ url: "http://localhost:54369/MainFunct/PageClosed.aspx", async: false });
                }
            });
        });
    </script>
    <div class="row">
        <div class="jumbotron">
        <h1>Nie jesteś zalogowany!</h1>
        <p class="lead">Jeśli chcesz uzyskać dostęp do funkcji naszego serwisu musisz się zalogować.</p>
        <p>Nie masz jeszcze konta?</p>
        <p><a runat="server" href="~/Account/Register.aspx" class = "btn btn-primary btn-lg">Zarejestruj się »</a></p>
    </div>
 
    </div>
</asp:Content>
