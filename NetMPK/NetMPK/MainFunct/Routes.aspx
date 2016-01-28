<%@ Page Title="Trasy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Routes.aspx.cs" Inherits="NetMPK.MainFunct.Routes" %>

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
     <h2> 
        Wyszukaj połączenie
    </h2>

    <div class="row">
        
        <div class="col-md-2">
             <h5>Przystanek początkowy</h5>
             <asp:TextBox runat="server" ID="sourceStop"/>
        </div>
    
        
        <div class="col-md-2">
            <h5>Przystanek końcowy</h5>
                <asp:TextBox runat="server" ID="endStop"/>
        </div>
    </div>
    <br/>
    <div>
                <asp:Button runat="server" OnClick="routeSearchButton_Click" Text="Szukaj" />

    </div>
      
    <div runat="server" id="mainContent"/>
    <asp:Button runat="server" ID="routeSaveBtn" OnClick="routeSaveButton" Text="Zapisz trase" Visible="false"/>
    
</asp:Content>
