<%@ Page Title="View Latest Forecast" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="viewForecast.aspx.cs" Inherits="GeneralUsers.viewForecast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/viewForecast.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSuccess" runat="server">
        <br />
    <asp:Label ID="successMsg" runat="server"><p class="successMsg">Forecast generated successfully, Scroll down to view it</p>
    </asp:Label>
    </asp:Panel>
    <div class="jumbotron header">
        <h1>Welcome <%= Session["User"].ToString() %></h1>
        <hr />
        <h4>View Latest Forecasts</h4>
        <br />
        <p>Down below is a drop down list of your favourite specified cities <br />
            Choose one and click the button to view the latest forecast for your favourite city
        </p>
        <hr />
    </div>
    <br />
    <h2 style="text-align: center;">Favourite Cities<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WeatherIOdb %>" SelectCommand="SELECT DISTINCT [CITY] FROM [Forecasts] WHERE ([CITY] = @CITY)">
        <SelectParameters>
            <asp:SessionParameter Name="CITY" SessionField="UserID" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
    </h2>
    <hr />
    <br />
    <asp:dropdownlist cssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="CITY" DataValueField="CITY" ID="ddl_FavCities"></asp:dropdownlist>
    <br />
    <div style="text-align: center;"><asp:button cssClass="btn btn-dark" ID="btnView" runat="server" text="View Latest" OnClick="btnView_Click" /></div>
    <br />
    <br />
    <div class="table-responsive">
        <asp:GridView ID="gvForecast" runat="server" CssClass="table table-bordered" HorizontalAlign="Center">
    </asp:GridView>
    </div>
    <br />
</asp:Content>
