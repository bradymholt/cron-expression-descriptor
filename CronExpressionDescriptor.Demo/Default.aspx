<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="_Default" %>

<html lang="en">
<head>
    <title></title>
    <link href="assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <a href="https://github.com/bradyholt/cron-expression-descriptor">
        <img style="position: absolute; top: 0; right: 0; border: 0;" src="https://a248.e.akamai.net/assets.github.com/img/7afbc8b248c68eb468279e8c17986ad46549fb71/687474703a2f2f73332e616d617a6f6e6177732e636f6d2f6769746875622f726962626f6e732f666f726b6d655f72696768745f6461726b626c75655f3132313632312e706e67"
            alt="Fork me on GitHub">
    </a>
    <div class="container">
        <header>
            <h1>
                Cron Expression Descriptor Demo</h1>
            <p>
                A C# library that converts cron expressions into human readable strings.</p>
        </header>
        <form id="Form1" class="well" runat="server">
        <div class="control-group">
            <asp:Label runat="server" ID="lblCronExpression" Text="Cron Expression:" AssociatedControlID="txtExpression"></asp:Label>
            <asp:TextBox runat="server" CssClass="cronExpression" Text="* * * * *" ID="txtExpression"></asp:TextBox>
            <asp:Button runat="server" ID="btnSubmit" CssClass="btn" Text="Submit" />
        </div>
        <label for="resultContainer">
            Result:</label>
        <div id="resultContainer" class="alert alert-success">
            <asp:Label runat="server" ID="lblResult"></asp:Label>
        </div>
        </form>
        <h2>
            Download</h2>
        Cron Expression Descriptor is <a href="https://github.com/bradyholt/cron-expression-descriptor">
            available for download on Github</a>.
        <h2>
            More Info</h2>
        License: MIT<br />
        Author:Brady Holt (<a href="http://www.geekytidbits.com">http://www.geekytidbits.com</a>)
    </div>
</body>
</html>
