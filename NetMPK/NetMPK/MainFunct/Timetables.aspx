﻿<%@ Page Title="Rozkłady jazdy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Timetables.aspx.cs" Inherits="NetMPK.MainFunct.Timetables" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3><asp:TextBox runat="server" ID="timeTableTextBox" CssClass="form-control" TextMode="MultiLine" /></h3>
</asp:Content>
