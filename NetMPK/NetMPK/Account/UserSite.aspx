<%@ Page Title="Strona użytkownika" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserSite.aspx.cs" Inherits="NetMPK.MainFunct.UserSite" %>

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
    <h2><%: Title %>.</h2>

    <asp:Label runat="server" ID="wLabel" CssClass="text-success"/>
</asp:Content>
