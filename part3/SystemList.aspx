<%@ Page Language="C#" Debug="true" Async="true" AutoEventWireup="true" CodeFile="SystemList.aspx.cs" Inherits="Store.SystemList"%>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title>Computer Store</title>
    <link rel="stylesheet" href="TMA3Styles.css"/>  
</head>
<body>
    <div class="topBar" runat="server">
        <div class="header">
            <img src="https://github.com/jscott111/TMA3/blob/main/part3/logo.jpg?raw=true" width="200" height="100" class="clickable" onclick="goHome()"/>
            <div class="cart" style="right: 50px; position: fixed; top: 25px; height: 53px;">
                <p id="ip" style="display: none;"><%=Request.UserHostAddress %></p>
                <script>var ip = document.getElementById("ip").innerHTML</script>
                <img src="account.png" width="50" height="50" class="clickable" onclick="loginPage()"/>
                <img src="https://icon-library.com/images/shop-cart-icon/shop-cart-icon-13.jpg" width="50" height="50" class="clickable" onclick="viewCart()"/>
                <b><asp:Label runat="server" ID="numberInCart" style="display: block; float: right; margin-top: 20px;"></asp:Label></b>
            </div>
        </div>

        <div class="mainmenu" runat="server">
            <ul>
                <li><a href="Home.aspx">Home</a></li>
                <li><a href="SystemList.aspx">Pre-Built Systems</a></li>
                <li><a>Components</a>
                    <ul>
                        <li><a href="ComponentList.aspx?part=motherboard">Motherboards</a></li>
                        <li><a href="ComponentList.aspx?part=cpu">CPUs</a></li>
                        <li><a href="ComponentList.aspx?part=ram">RAM</a></li>
                        <li><a href="ComponentList.aspx?part=display">Displays</a></li>
                        <li><a href="ComponentList.aspx?part=os">Operating Systems</a></li>
                        <li><a href="ComponentList.aspx?part=soundcard">Soundcards</a></li>
                    </ul>
                </li>
                <li><a href="Contact.aspx">Contact</a></li>
                <li><a href="Feedback.aspx">Feedback</a></li>
            </ul>
        </div>
    </div>

    <div class="content">
        <asp:Label ID="title" class="title" runat="server">Pre-Built Systems</asp:Label>
        <asp:Panel ID="list" runat="server">

        </asp:Panel>
    </div>

    <script type="text/javascript" src="storeDriver.js"></script>
</body>
</html>

