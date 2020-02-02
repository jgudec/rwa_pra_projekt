<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="AdminSite.MainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/CustCss/MainMenu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main card" >
        <div id="welcome" class="center">
            <h1>Dobrodošli!</h1>
            <p class="center">Odaberite opciju u glavnom izborniku.</p>
        </div>
        <div class="col-12 col centered ">
                    <a href="Pages/Korisnici/ViewKorisnici.aspx" class="waves-effect waves-light btn-large blue buton meh">Korisnici</a>
                    <a href="#" class="waves-effect waves-light btn-large blue buton meh">Kombinacije</a>
                </div>
        <div class="col-12 col centered ">
                    <a class="waves-effect waves-light btn-large blue cust center meh" href="Pages/Obroci/ViewObroci.aspx">Obroci</a>
                </div>
        <div class="col-12 col centered ">
                   <a href="Pages/Namirnice/ViewNamirnice.aspx" class="waves-effect waves-light btn-large blue buton meh ">Namirnice</a>
                   <a href="Pages/MjJedinice/ViewMjJedinice.aspx" class="waves-effect waves-light btn-large blue buton meh">Mjerne Jedinice</a>
                </div>
    </div>
</asp:Content>

