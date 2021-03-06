<%@ Page Language="C#" Debug="true" Async="true" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Store.Feedback"%>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title>Computer Store</title>
    <link rel="stylesheet" href="../styles/TMA3Styles.css"/>
</head>
<body runat="server">
    <div class="topBar" runat="server">
        <div class="header">
            <img src="https://github.com/jscott111/TMA3/blob/main/part3/logo.jpg?raw=true" width="200" height="100" class="clickable" onclick="goHome()"/>
            <div class="cart" style="right: 50px; position: fixed; top: 25px; height: 53px;">
                <img src="https://icon-library.com/images/shop-cart-icon/shop-cart-icon-13.jpg" width="50" height="50" class="clickable" onclick="viewCart()"/>
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
                        <li><a href="ComponentList.aspx?part=hd">Hard Drive</a></li>
                    </ul>
                </li>
                <li><a href="Contact.aspx">Contact</a></li>
                <li><a href="Feedback.aspx">Feedback</a></li>
            </ul>
        </div>
    </div>

    <br /><br />

    <div class="content" runat="server">
        <h2>Feedback</h2>

        <form runat="server" style="margin-left: 40px;">

            Name:<br>

            <asp:textbox ID="name" MaxLength="30" runat="server"></asp:textbox><br><br>

            Message:<br> 

            <asp:textbox ID="message" Rows="6" Columns="20" TextMode="MultiLine" runat="server"></asp:textbox>

            <br><br> 

            <asp:Button ID="feedbackForm" runat="server" OnClick="sendEmail" Text="Submit"></asp:Button>
        </form>
    </div>

    <script type="text/javascript" src="storeDriver.js"></script>
</body>
</html>
