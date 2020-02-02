<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="EditKombinacije.aspx.cs" Inherits="AdminSite.Pages.Kombinacije.EditKombinacije" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Kombinacije</title>
    <!-- Compiled and minified CSS -->
    <link href="/Content/materialize/css/materialize.min.css" rel="stylesheet" />
    <!-- Compiled and minified JavaScript -->
    <script src="/Content/materialize/js/materialize.min.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" /> 
    <link href="/Content/CustCss/ViewObroci.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <asp:LinkButton CssClass="waves-effect waves-teal shortenBack" runat="server" PostBackUrl="~/Pages/Kombinacije/ViewKombinacije.aspx"><i class=" material-icons small">arrow_back</i></asp:LinkButton>
            <h3 class="center">Uređivanje kombinacija</h3>
        <br />
        Broj obroka
        <asp:DropDownList 
                ID="ddlSort" 
                runat="server" 
                CssClass="browser-default center col-2 offset-5" 
                AutoPostBack="true">
                <asp:ListItem Value="asc">3</asp:ListItem>
            </asp:DropDownList>
        <br />
        <asp:LinkButton type="button" 
            runat="server" 
            class="btn-floating btn-large halfway-fab waves-effect waves-light red" PostBackUrl="#">
            <i class="material-icons">save</i></asp:LinkButton>    
    <div class="card-content">
        <table class="striped col-8 centered offset-2 responsive-table">
        <thead>
          <tr>
              <th>Naziv</th>
              <th>Ugljikohidrati</th>
              <th>Masti</th>
              <th>Proteini</th>
              <th>Kcal</th>
          </tr>
        </thead>

        <tbody>
          <tr>
            <td>Doručak</td>
            <td><input value="10" type="number" class="validate col-2 center"/></td>
            <td><input value="45" type="number" class="validate col-2 center"/></td>
            <td><input value="45" type="number" class="validate col-2 center"/></td>
            <td><input value="500" type="number" class="validate col-3 center"/></td>
          </tr>
          <tr>
            <td>Ručak</td>
            <td><input value="20" type="number" class="validate col-2 center"/></td>
            <td><input value="40" type="number" class="validate col-2 center"/></td>
            <td><input value="40" type="number" class="validate col-2 center"/></td>
            <td><input value="600" type="number" class="validate col-3 center"/></td>
          </tr>
          <tr>
            <td>Večera</td>
            <td><input value="25" type="number" class="validate col-2 center"/></td>
            <td><input value="5" type="number" class="validate col-2 center"/></td>
            <td><input value="70" type="number" class="validate col-2 center"/></td>
            <td><input value="400" type="number" class="validate col-3 center"/></td>
          </tr>
        </tbody>
      </table>
    </div>
    </div>
    <script>
        $(document).ready(function () {
            $('.datepicker').datepicker({
                minDate: new Date(),
                showClearBtn: true
            });
        });
    </script>
</asp:Content>

