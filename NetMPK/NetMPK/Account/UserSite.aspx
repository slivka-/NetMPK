<%@ Page Title="Strona użytkownika" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserSite.aspx.cs" Inherits="NetMPK.Account.UserSite" %>

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
    <h2>Witaj <%: username %>!</h2>

    <div class="row">
        <div class="col-md-4">
            <h3>Oto twoje statystyki</h3>
            <h7>Średni czas spędzony w podróży: <%: avgTime %></h7><br/>
            <h7>Ulubiona linia: <%: favLine %></h7>
        </div>
        <div class="col-md-6">
            <h3>Zapisane trasy</h3>
            <div id="savedTracks" runat="server"/>
        </div>

    </div>


    <asp:Label runat="server" ID="wLabel" CssClass="text-success"/>
</asp:Content>
