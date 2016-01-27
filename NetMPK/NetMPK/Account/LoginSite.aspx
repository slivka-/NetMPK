<%@ Page Title="Logowanie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginSite.aspx.cs" Inherits="NetMPK.Account.LoginSite" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Zaloguj się</h2>
    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Login" CssClass="col-md-2 control-label">Login</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Login" CssClass="form-control" />
                <asp:Label runat="server" ID="LoginErr" CssClass="text-danger"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Login" CssClass="text-danger" ErrorMessage="Podanie Loginu jest wymagane" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Hasło</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="Podanie hasła jest wymagane" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="LoginUser_Click" Text="Zaloguj się" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
