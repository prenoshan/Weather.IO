<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GeneralUsers.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="~/css/loginStyles.css" rel="stylesheet" />

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>

    <!-- Popper JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlError" runat="server">
            <br />
            <asp:Label CssClass="errorMsg" ID="errorMsg" runat="server"><div style="text-align: center;"><p>Invalid Credentials, Please try again</p></div></asp:Label>
        </asp:Panel>
        <div class="jumbotron header">
            <h1>Login Form</h1>
            <hr />
            <p>Please use the form below to login</p>
        </div>
        <div class="loginForm">
            <br />
            <h3>Login</h3>
            <hr />
            <br />
            <p>Username</p>
            <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server"></asp:TextBox>
            <br />
            <br />
            <p>Password</p>
            <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button CssClass="btn btn-dark" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
        <br />
        <br />
    </form>
</body>
</html>
