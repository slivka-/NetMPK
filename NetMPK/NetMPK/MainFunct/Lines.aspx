<%@ Page Title="Linie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lines.aspx.cs" Inherits="NetMPK.MainFunct.Lines" %>

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
            Wyszukaj linie
        </h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <asp:TextBox runat="server" ID="lineSearch" /><asp:Button runat="server" ID="lineSearchButton" OnClick="lineSearchButton_Click" Text="Szukaj" />
        <h2><p runat="server" id="titleText"> 
            Lista linii
        </p></h2>
    <div runat="server" id="mainContent" class="col-md-12"/>
    </div>
</asp:Content>
