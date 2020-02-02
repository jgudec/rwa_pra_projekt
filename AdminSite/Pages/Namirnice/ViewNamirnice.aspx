<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="ViewNamirnice.aspx.cs" Inherits="AdminSite.Pages.Namirnice.ViewNamirnice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mjerne Jedinice</title>
    <!-- Compiled and minified CSS -->
    <link href="/Content/materialize/css/materialize.min.css" rel="stylesheet" />
    <!-- Compiled and minified JavaScript -->
    <script src="/Content/materialize/js/materialize.min.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" /> 
    <link href="/Content/CustCss/ViewObroci.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-wrapper card">
        <asp:LinkButton type="button" 
            runat="server" 
            class="btn-floating btn-large halfway-fab waves-effect waves-light red modal-trigger" PostBackUrl="~/Pages/Namirnice/EditNamirnice.aspx">
            <i class="material-icons">edit</i>
        </asp:LinkButton>
        <div class="center centered card-header">
            <h2 class="center">Namirnice</h2>
            <br />
            <asp:Label runat="server">Sortiranje po nazivu: </asp:Label>
            <asp:DropDownList 
                ID="ddlSort" 
                runat="server" 
                CssClass="browser-default center meh" 
                AutoPostBack="true">
                <asp:ListItem Value="asc">Rastuće( A-Z )</asp:ListItem>
                <asp:ListItem Value="desc">Padajuće( Z-A )</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="center card-content col-10 offset-1">
            <asp:ListView ID="listNamirnice" 
                ItemType="DAL.Model.Namirnica"
                runat="server" 
                DataKeyNames="IDNamirnica">

            <LayoutTemplate>
                <table class="center centered">
                    <thead>
                        <tr>
                            <th id="lblMus" runat="server">Naziv</th>
                            <th id="Th1" runat="server">Kj</th>
                            <th id="Th2" runat="server">Kcal</th>
                            <th id="Th3" runat="server">Tip Namirnice</th>
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
                    <td runat="server">
                        <asp:Label Text="<%#:Item.Kj %>" CssClass="centered" runat="server" />
                    </td>
                    <td runat="server">
                        <asp:Label Text="<%#:Item.Kcal %>" CssClass="centered" runat="server" />
                    </td>
                    <td runat="server">
                        <asp:Label Text="<%#:Item.tipNamirnice %>" CssClass="centered" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>

        </asp:ListView>

        <div class="card-footer">
            <asp:DataPager runat="server" ID="musDataPager" PagedControlID="listNamirnice">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </div>
      </div>
  </div>
</asp:Content>
