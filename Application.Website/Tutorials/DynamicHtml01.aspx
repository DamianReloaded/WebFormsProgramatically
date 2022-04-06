<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DynamicHtml01.aspx.cs" Inherits="Application.Website.Tutorials.DynamicHtml01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head><script type="text/javascript" src="/library/jquery/jquery-1.11.2.min.js"></script><script type="text/javascript" src="/library/bootstrap/bootstrap.min.js"></script><link href="/Default.css" type="text/css" rel="stylesheet" /><link href="/library/bootstrap/bootstrap.min.css" type="text/css" rel="stylesheet" /><title>Home</title><style></style></head>
<body>
    <form runat="server">
        <asp:scriptmanager runat="server"></asp:scriptmanager>
        <asp:placeholder id="PlaceHolder" runat="server"></asp:placeholder>
    </form>
</body>
</html>
