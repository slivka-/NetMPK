<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetMPK._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="jumbotron">
        <h1>Internetowy rozkład jazdy MPK</h1>
        <p class="lead">Wyszukuj trasy, linie i przystanki. Sprawdzaj rozkłady. Szybko i wygodnie!</p>
        <p><a runat="server" href="~/Account/Register.aspx" class = "btn btn-primary btn-lg">Zarejestruj się »</a></p>
    </div>

    <div class="row">
        <div class="col-md-3">
            <h2>Rozkłady jazdy</h2>
            <p>
                Dzięki pełnej i aktualizowanej na bieżąco bazie rozkładów zawsze będziesz na czas!
            </p>
            <p><a runat="server" href="~/MainFunct/Timetables" class = "btn btn-default">Przejdź do rozkładów »</a></p>
        </div>
        <div class="col-md-3">
            <h2>Przystanki</h2>
            <p>Zastanawiasz się jakie linie kursują przez Twój przystanek?</p>
            <p><a runat="server" href="~/MainFunct/Stops" class = "btn btn-default">Wyszukiwanie przystanków »</a></p>
        </div>
        <div class="col-md-3">
            <h2>Linie</h2>
            <p>Chcesz się dowiedzieć przez jakie przystanki przejeżdża Twoja ulubiona linia?</p>
            <p><a runat="server" href="~/MainFunct/Lines" class = "btn btn-default">Wyszukiwanie linii »</a></p>
        </div>
        <div class="col-md-3">
            <h2>Trasy</h2>
            <p>Chcesz się dostać na drugi koniec miasta i nie wiesz czym pojechać? Nasza wyszukiwarka wytyczy dla ciebie całą trase!</p>
            <p><a runat="server" href="~/MainFunct/Routes" class = "btn btn-default">Wyszukiwanie trasy »</a></p>
        </div>
    </div>

</asp:Content>
