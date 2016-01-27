<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StopLines.aspx.cs" Inherits="NetMPK.MainFunct.StopLines" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
        <h2><p runat="server" id="titleText"> 
            Linie przechodzące przez przystanek 
        </p></h2>
    <div runat="server" id="mainContent" class="col-md-12"/>
    </div>
</asp:Content>
