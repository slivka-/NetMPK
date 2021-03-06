﻿<%@ Page Title="Trasy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmAccount.aspx.cs" Inherits="NetMPK.Account.ConfirmAccount" %>

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
    <br/>
    <br/>
    <h3>Podaj kod otrzymany w mailu aktywacyjnym</h3> 
        <asp:TextBox runat="server" ID="vCode" CssClass="form-control" />
        <asp:Label runat="server" ID="codeErr" CssClass="text-danger"/>
        <asp:Button runat="server" OnClick="ConfirmUser_Click" Text="Potwierdź" CssClass="btn btn-default" />
    <br/>
    <br/>
    <br/>
    <br/>
    <h4>Nie otrzymałeś maila aktywującego? Kliknij poniższy przycisk aby wysłać go ponownie.</h4>
    <asp:Button runat="server" OnClick="ResendEmail" Text="Wyślij" CssClass="btn btn-default" />
    <asp:Label runat="server" ID="resendLabelErr" CssClass="text-danger"/>
    <asp:Label runat="server" ID="resendLabelSuccess" CssClass="text-success"/>
</asp:Content>
