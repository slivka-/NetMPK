<%@ Page Title="ADMIN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="NetMPK.Account.AdminPanel" %>

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

    <h2>Witaj administratorze <%: adminName%></h2>
</asp:Content>
