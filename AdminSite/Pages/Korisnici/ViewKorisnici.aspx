<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ViewKorisnici.aspx.cs" Inherits="AdminSite.Pages.Korisnici.ViewKorisnici" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main card" >
        <div id="welcome" class="center hu">
            <h1>Prikaz korisnika</h1>
        </div>

            <table id="KorisniciTable" class="centered responsive-table" >
                <thead>
                    <tr>
                        <th id="tableCell" runat="server"></th>
                        <th>Korisničko ime</th>
                        <th>Ime</th>
                        <th>Prezime</th>
                        <th>E-mail</th>
                        <th>Datum rođenja</th>
                        <th>Spol</th>
                        <th>Tip dijabetesa</th>
                        <th>Fizička aktivnost</th>
                        <th>Težina(kg)</th>
                        <th>Visina(cm)</th>
                        <th>BMI</th>
                    </tr>
                </thead>
                <tbody id="tableBody" runat="server">
                </tbody>
            </table>
        <div class="card-footer">
			<div class="center butons">
            <asp:Button Text="Clear Selection" ID="btnClear" CssClass="waves-effect waves-light btn blue" runat="server" OnClick="btnClear_Click"/>

            <asp:Button Text="Export" ID="btnExport" CssClass="waves-effect waves-light btn blue" runat="server" OnClick="btnExport_Click"/>
        </div>
		</div>
    </div>
    <script>
        $('#KorisniciTable').DataTable();
    </script>
</asp:Content>
