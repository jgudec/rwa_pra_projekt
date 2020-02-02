<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ViewMjJedinice.aspx.cs" Inherits="AdminSite.Pages.MjJedinice.ViewMjJedinice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mjerne Jedinice</title>
    <!-- Compiled and minified CSS -->
    <link href="/Content/materialize/css/materialize.min.css" rel="stylesheet" />
    <!-- Compiled and minified JavaScript -->
    <script src="/Content/materialize/js/materialize.min.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" /> 
    <%--Ovo trebas da prokleti modal proradi opet...--%>
    <script src="/Scripts/jquery-3.4.1.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <link href="/Content/CustCss/ViewObroci.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-wrapper card">
        <asp:LinkButton type="button" 
            runat="server" 
            class="btn-floating btn-large halfway-fab waves-effect waves-light red modal-trigger" PostBackUrl="~/Pages/MjJedinice/EditMjJedinice.aspx">
            <i class="material-icons">edit</i>
        </asp:LinkButton>
        <div class="center centered card-header">
            <h2 class="center">Mjerne jedinice</h2>
            <br />
            <asp:Label runat="server">Sortiranje po nazivu: </asp:Label>
            <asp:DropDownList 
                ID="ddlSort" 
                runat="server" 
                CssClass="browser-default center meh" 
                OnSelectedIndexChanged="ddlSort_SelectedIndexChanged"
                AutoPostBack="true">
                <asp:ListItem Value="asc">Rastuće( A-Z )</asp:ListItem>
                <asp:ListItem Value="desc">Padajuće( Z-A )</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="center card-content">
            <asp:ListView ID="listMjJed" 
            ItemType="DAL.Model.MjJedinica" 
            runat="server"
            DataKeyNames="IDMjernaJedinica">

            <LayoutTemplate>
                <table class="center centered">
                    <thead>
                        <tr>
                            <th id="lblMus" runat="server">Mjerne jedinice
                            </th>
                        </tr>

                    </thead>
                    <tbody>
                        <tr class="center" runat="server" id="itemPlaceholder">
                        </tr>
                    </tbody>
                </table>
            </LayoutTemplate>

            <ItemTemplate runat="server">
                <tr runat="server">
                    <td runat="server">
                        <asp:Label Text="<%#:Item.Naziv %>" CssClass="centered" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>

        </asp:ListView>

        <asp:DataPager runat="server" ID="musDataPager" PagedControlID="listMjJed">
            <Fields>
                <asp:NumericPagerField />
            </Fields>
        </asp:DataPager>
      </div>
      

 
  </div>
</asp:Content>
