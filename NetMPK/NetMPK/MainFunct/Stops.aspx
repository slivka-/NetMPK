<%@ Page Title="Przystanki" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stops.aspx.cs" Inherits="NetMPK.MainFunct.Stops" %>

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
        <h2> 
            Wyszukaj przystanek
        </h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <asp:TextBox runat="server" ID="stopSearch" /><asp:Button runat="server" ID="stopSearchButton" OnClick="stopSearchButton_Click" Text="Szukaj" />
        <h2><p runat="server" id="titleText"> 
            Lista przystanków 
        </p></h2>
    <div runat="server" id="mainContent" class="col-md-2"/>
    </div>

</asp:Content>
