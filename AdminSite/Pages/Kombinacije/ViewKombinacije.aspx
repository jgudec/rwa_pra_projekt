<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ViewKombinacije.aspx.cs" Inherits="AdminSite.Pages.Kombinacije.ViewKombinacije" %>
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
        <div class="center centered card-header">
            <h3 class="center">Kombinacije</h3>
            <div class="input-field inline">
                <i class="material-icons prefix s6">date_range</i>
                <input id="datumOd" type="text" class="datepicker"/>
                <label for="datumOd">OD</label>
          </div>
          <div class="input-field inline">
              <i class="material-icons prefix">date_range</i>
                <input id="datumDo" type="text" class="datepicker"/>
                <label for="datumDo">DO</label>
          </div>
            <br/>
            Broj obroka
        <asp:DropDownList 
                ID="ddlSort" 
                runat="server" 
                CssClass="browser-default center col-2 offset-5" 
                AutoPostBack="true">
                <asp:ListItem Value="asc">3</asp:ListItem>
            </asp:DropDownList>
    </div>
        <br />
        <asp:LinkButton type="button" 
            runat="server" 
            class="btn-floating btn-large halfway-fab waves-effect waves-light red" PostBackUrl="~/Pages/Kombinacije/EditKombinacije.aspx">
            <i class="material-icons">edit</i></asp:LinkButton>    
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
            <td>10</td>
            <td>45</td>
            <td>45</td>
            <td>500</td>
          </tr>
          <tr>
            <td>Ručak</td>
            <td>20</td>
            <td>40</td>
            <td>40</td>
            <td>600</td>
          </tr>
          <tr>
            <td>Večera</td>
            <td>25</td>
            <td>455</td>
            <td>70</td>
            <td>400</td>
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
