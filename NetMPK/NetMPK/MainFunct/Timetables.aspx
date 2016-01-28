<%@ Page Title="Rozkłady jazdy" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Timetables.aspx.cs" Inherits="NetMPK.MainFunct.Timetables" %>



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
    <h2>Wyszukaj rozkład</h2>
    <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage0" /><asp:Literal runat="server" ID="ErrorMessage1" />
    </p>

    <div class="row">
        <div class="col-md-2">
        <h4>Linia:</h4><asp:TextBox runat="server" ID="lineSearch" /> 
        </div>
        <div class="col-md-2">
        <h4>Przystanek:</h4><asp:TextBox runat="server" ID="stopSearch" /><br/>
        </div>
    </div>
    <br/>
    <asp:Button runat="server" OnClick="timeTableSearch" ID="stopSearchButton" Text="Szukaj" />
    
    
    <h2><p runat="server" id="titleText"></p></h2>
    <asp:Literal runat="server" ID="DIR" />
    <div class="row">
    <div class="col-md-3" id="weekDays" runat="server">
        Dni powszednie<br/>
    </div>
    <div class="col-md-3" id="saturDays" runat="server">
        Soboty<br/>
    </div>
    <div class="col-md-3" id="holykDays" runat="server">
        Niedziele i święta<br/>
    </div>  
    </div>
    <br/><br/>
    <asp:Literal runat="server" ID="DIR1" />
    <div class="row">
    <div class="col-md-3" id="weekDays1" runat="server">
        Dni powszednie<br/>
    </div>
    <div class="col-md-3" id="saturDays1" runat="server">
        Soboty<br/>
    </div>
    <div class="col-md-3" id="holykDays1" runat="server">
        Niedziele i święta<br/>
    </div>  
    </div>
</asp:Content>