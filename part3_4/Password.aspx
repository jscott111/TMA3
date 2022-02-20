<%@ Page Language="C#" Debug="true" Async="true" AutoEventWireup="true" CodeFile="Password.aspx.cs" Inherits="Store.Password"%>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title>Computer Store</title>
    <link rel="stylesheet" href="../styles/TMA3Styles.css"/>   
</head>
<body>
    <div class="topBar" runat="server">
        <div class="header">
            <img src="logo.jpg" width="200" height="100" class="clickable" onclick="goHome()"/>
            <div class="cart" style="right: 50px; position: fixed; top: 25px; height: 53px;">
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
        <form runat="server">
            <asp:Label ID="title" class="title" runat="server">Reset</asp:Label>
            <asp:Panel ID="contents" class="loginPanel" runat="server">
                <form action="Login.aspx" method="post">
                    <label>Username:</label>
                    <input name="username" type="text" />
                    <label>Phone Number:</label>
                    <input name="phoneNumber" type="text" />
                    <label>New password:</label>
                    <input name="firstPassword" type="password" />
                    <label>Confirm password:</label>
                    <input name="secondPassword" type="password" />
                    <div style="display: flex; flex-direction: row;">
                        <input name="button" type="submit" style="padding: 5px 5px; margin: 10px;" value="Reset" />
                    </div>
                </form>
                <asp:Label ID="incorrect" style="color: red;" runat="server"></asp:Label>
            </asp:Panel>
        </form>
    </div>

    <script type="text/javascript" src="storeDriver.js"></script>
</body>
</html>
