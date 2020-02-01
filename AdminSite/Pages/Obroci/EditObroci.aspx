<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="EditObroci.aspx.cs" Inherits="AdminSite.Pages.Obroci.EditObroci" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/CustCss/ViewObroci.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <asp:LinkButton CssClass="waves-effect waves-teal shortenBack" runat="server" PostBackUrl="~/Pages/Obroci/ViewObroci.aspx"><i class=" material-icons small">arrow_back</i></asp:LinkButton>
        <h5 class="modal-title">Uređivanje obroka.</h5>
        <br />
        <asp:DropdownList 
            runat="server" 
            ID="ddlObroci" 
            CssClass="browser-default shorten center" 
            AutoPostBack="true" 
            OnSelectedIndexChanged="ddlObroci_SelectedIndexChanged" />
        <br />
        <asp:Label Text="Naziv" runat="server" />
        <asp:TextBox 
            runat="server" 
            ID="tbNaziv" 
            CssClass="shorten center" 
            />
        <asp:RequiredFieldValidator ControlToValidate="tbNaziv" ID="rfValidator" runat="server" ErrorMessage="Molimo ispunite polje!" Display="Dynamic"></asp:RequiredFieldValidator>
        <br />
        <div>
        <asp:Button ID="btnAdd" runat="server" CssClass="modal-close waves-effect waves-green btn blue shortenB col-4" OnClick="btnAdd_Click" Text="Dodaj" />
        <asp:Button ID="btnDelete" runat="server" CssClass="modal-close waves-effect waves-green btn blue shortenB col-4" OnClick="btnDelete_Click" Text="Ukloni" />
        <asp:Button ID="btnUpdate" runat="server" CssClass="modal-close waves-effect waves-green btn blue shortenB col-4" OnClick="btnUpdate_Click" Text="Spremi" />
        </div>
        
    </div>
</asp:Content>
