<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="AdminSite.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/popper.js"></script>
    <!-- Compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css"/>
    <!-- Compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/js/materialize.min.js"></script>
    <link href="Content/CustCss/LogIn.css" rel="stylesheet" />
</head>
<body>
    <div class="main">
        <h2>Diabetic Food Menu</h2>
        <form id="form1" runat="server">
            <div class="card center">
                <asp:Login ID="LoginCard" runat="server" DisplayRememberMe="False" OnAuthenticate="LoginCard_Authenticate"
                    TitleText="" PasswordLabelText="Password" UserNameLabelText="Username" DestinationPageUrl="~/MainMenu.aspx" >
               
                    <LoginButtonStyle CssClass="waves-effect waves-light btn blue" />

                </asp:Login>
            </div>
        </form>
    </div>
</body>
</html>
