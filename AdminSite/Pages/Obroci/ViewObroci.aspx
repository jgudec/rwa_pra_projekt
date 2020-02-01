<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ViewObroci.aspx.cs" Inherits="AdminSite.Pages.Obroci.ViewObroci" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Obroci</title>
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"/>
    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" /> 
    <%--Ovo trebas da prokleti modal proradi opet...--%>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" ></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" ></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" ></script>
    <link href="../../Content/CustCss/ViewObroci.css" rel="stylesheet" />
<script>
    $('#exampleModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget)
        var recipient = button.data('whatever')
        var modal = $(this)
        modal.find('.modal-title').text('New message to ' + recipient)
        modal.find('.modal-body input').val(recipient);
    })
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-wrapper card">
        <div class="center centered card-header">
            <h2 class="center">Pregled Obroka</h2>
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
            <asp:LinkButton type="button" 
            runat="server" 
            class="btn-floating btn-large halfway-fab waves-effect waves-light red" PostBackUrl="~/Pages/Obroci/EditObroci.aspx">
            <i class="material-icons">edit</i></asp:LinkButton>
        </div>

        <div class="center card-content">
            <asp:ListView ID="lvObroci" 
            runat="server" 
            OnPagePropertiesChanging="lvObroci_PagePropertiesChanging" ItemType="DAL.Model.Obrok"
            DataKeyNames="IDObrok">
                <LayoutTemplate >
                    <br/>
                    <br/>
                    <table class="center centered">
                        <thead>  
                        </thead>
                        <tbody>
                            <tr id="itemPlaceholder" runat="server" class="center centered"></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server" class="center">
                        <td runat="server">
                            <asp:Label Text="<%#:Item.Naziv%>" runat="server" CssClass="center" /> 
                            <asp:Button  
                                runat="server" 
                                ID="btnToggle"
                                CommandArgument="<%#:Item.IDObrok %>" 
                                OnClick="btnToggle_Click" 
                                OnPreRender="btnToggle_PreRender" 
                                CausesValidation="false"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <br/>
            <br/>
            <asp:DataPager ID="dpObrok" runat="server" PagedControlID="lvObroci">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </div>
    </div>

    
</asp:Content>
