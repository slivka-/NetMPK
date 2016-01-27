<%@ Page Title="Trasy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Routes.aspx.cs" Inherits="NetMPK.MainFunct.Routes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h2> 
        Wyszukaj połączenie
    </h2>

    <div class="form-group">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Przystanek początkowy</asp:Label>
        <div class="col-md-10">
                <asp:TextBox runat="server" ID="sourceStop" CssClass="form-control" />
        </div>
    </div>
   <div class="form-group">
        <asp:Label runat="server" CssClass="col-md-2 control-label">Przystanek końcowy</asp:Label>
        <div class="col-md-10">
                <asp:TextBox runat="server" ID="endStop" CssClass="form-control" />
        </div>
    </div>
    <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="routeSearchButton_Click" Text="Znajdź" CssClass="btn btn-default" />
            </div>
    </div>       
    <div runat="server" id="mainContent" class="col-md-12"/>
    
</asp:Content>
