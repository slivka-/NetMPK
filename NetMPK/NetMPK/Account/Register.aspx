﻿<%@ Page Title="Rejestracja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NetMPK.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
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
    <h2>Zarejestruj się</h2>
    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Stwórz nowe konto</h4>
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
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:Label runat="server" ID="EmailErr" CssClass="text-danger"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="Podanie adresu Email jest wymagane" />
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
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Powtórz hasło</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="Podanie potwierdzenia jest wymagane" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="Potwierdzenie nie pasuje do hasła" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Zarejestruj się" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
