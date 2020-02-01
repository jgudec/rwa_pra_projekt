<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="EditNamirnice.aspx.cs" Inherits="AdminSite.Pages.Namirnice.EditNamirnice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Content/CustCss/ViewObroci.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <asp:LinkButton CssClass="waves-effect waves-teal shortenBack" runat="server" PostBackUrl="~/Pages/Namirnice/ViewNamirnice.aspx"><i class=" material-icons small">arrow_back</i></asp:LinkButton>
        <h5 class="modal-title">Uređivanje namirnica.</h5>
        <br />
        <asp:DropdownList 
            runat="server" 
            ID="ddlNamirnice" 
            CssClass="browser-default shorten center" 
            AutoPostBack="true" 
            OnSelectedIndexChanged="ddlNamirnice_SelectedIndexChanged" />
        <br />
        <asp:Label Text="Naziv" runat="server" />
        <asp:TextBox 
            runat="server" 
            ID="tbNaziv" 
            CssClass="shorten center" 
            />
        <asp:Label Text="Kalorije( Kj )" runat="server" CssClass="margintop" />
        <asp:TextBox 
            runat="server" 
            ID="tbKj" 
            CssClass="shorten center" 
            />
        <asp:Label Text="Kalorije( Kcal )" runat="server" CssClass="margintop" />
        <asp:TextBox 
            runat="server" 
            ID="tbKcal" 
            CssClass="shorten center" 
            />
        <asp:Label Text="Tip namirnice" runat="server" CssClass="margintop" />
        <asp:DropDownList 
            ID="ddlTipoviNamirnica" 
            runat="server" AutoPostBack="true"
            CssClass="browser-default shorten center" OnSelectedIndexChanged="ddlTipoviNamirnica_SelectedIndexChanged"/>
        <asp:RequiredFieldValidator ControlToValidate="tbNaziv" ID="rfValidator" runat="server" ErrorMessage="Molimo ispunite polje!" Display="Dynamic" />
        <asp:RequiredFieldValidator ControlToValidate="tbKj" ID="rfValidator1" runat="server" ErrorMessage="Molimo ispunite polje!" Display="Dynamic" />
        <asp:RequiredFieldValidator ControlToValidate="tbKcal" ID="rfValidator2" runat="server" ErrorMessage="Molimo ispunite polje!" Display="Dynamic" />
        <br />
        <div>
        <asp:Button ID="btnAdd" runat="server" CssClass="modal-close waves-effect waves-green btn blue shortenB col-4" OnClick="btnAdd_Click" Text="Dodaj" />
        <asp:Button ID="btnDelete" runat="server" CssClass="modal-close waves-effect waves-green btn blue shortenB col-4" OnClick="btnDelete_Click" Text="Ukloni" />
        <asp:Button ID="btnUpdate" runat="server" CssClass="modal-close waves-effect waves-green btn blue shortenB col-4" OnClick="btnUpdate_Click" Text="Spremi" />
        </div>
        
    </div>
</asp:Content>
