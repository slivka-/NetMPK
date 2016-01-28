<%@ Page Title="Trasy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Routes.aspx.cs" Inherits="NetMPK.MainFunct.Routes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h2> 
        Wyszukaj połączenie
    </h2>

    <div>
        <asp:Label runat="server" CssClass="col-md-2 control-label">Przystanek początkowy</asp:Label>
        <div>
                <asp:TextBox runat="server" ID="sourceStop"/>
        </div>
    </div>
   <div >
        <asp:Label runat="server" CssClass="col-md-2 control-label">Przystanek końcowy</asp:Label>
        <div>
                <asp:TextBox runat="server" ID="endStop"/>
        </div>
    </div>
    <div >
            <div>
                <asp:Button runat="server" OnClick="routeSearchButton_Click" Text="Znajdź" />
            </div>
    </div>       
    <div runat="server" id="mainContent"/>
    
</asp:Content>
