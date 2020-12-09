<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GeneralUsers.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Home</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="css/homeStyles.css" rel="stylesheet" />

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
        <div class="jumbotron header">
            <h1>Welcome to Weather.IO</h1>
            <hr style="background-color: white;" />
            <p>Weather.IO is a simple application that allows you to view the latest forecasts for your favourite cities</p>
            <p>Please use the button below to login into your account</p>
        </div>
        <br />
        <div class="content">
            <br />
        <asp:Button CssClass="btn btn-dark" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
