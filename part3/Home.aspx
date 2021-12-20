﻿<%@ Page Language="C#" Debug="true" Async="true" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Store.Home"%>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title>Computer Store</title>
    <link rel="stylesheet" href="TMA3Styles.css"/>
</head>
<body runat="server">
    <div class="topBar" runat="server">
        <div class="header">
            <img src="https://github.com/jscott111/TMA3/blob/main/part3/logo.jpg?raw=true" width="200" height="100" class="clickable" onclick="goHome()"/>
            <div class="cart" style="right: 50px; position: fixed; top: 25px; height: 53px;">
                <img src="https://icon-library.com/images/shop-cart-icon/shop-cart-icon-13.jpg" width="50" height="50" class="clickable"/>
                <b runat="server" style="display: block; float: right; margin-top: 20px;">0</b>
            </div>
        </div>

        <div class="mainmenu" runat="server">
            <ul>
                <li><a href="Home.aspx">Home</a></li>
                <li><a href="SystemList.aspx">Pre-Built Systems</a></li>
                <li><a>Components</a>
                    <ul>
                        <li><a href="ComponentList.aspx?system=motherboard">Motherboards</a></li>
                        <li><a href="ComponentList.aspx?system=cpu">CPUs</a></li>
                        <li><a href="ComponentList.aspx?system=ram">RAM</a></li>
                        <li><a href="ComponentList.aspx?system=display">Displays</a></li>
                        <li><a href="ComponentList.aspx?system=os">Operating Systems</a></li>
                        <li><a href="ComponentList.aspx?system=soundcard">Soundcards</a></li>
                    </ul>
                </li>
                <li><a href="Contact.aspx">Contact</a></li>
                <li><a href="Feedback.aspx">Feedback</a></li>
            </ul>
        </div>
    </div>

    <br /><br />

    <div class="content" runat="server">
        <div>
            <h2>Best Sellers</h2>
            <a href="SystemList.aspx" class="seeMore">See More</a>
        </div>
        <asp:Panel ID="bestSeller" runat="server" class="storeDiv">

        </asp:Panel>

        <h2>On Sale</h2>
        <asp:Panel ID="onSale" runat="server" class="storeDiv">

        </asp:Panel>
    
        <h2>Components</h2>
        <asp:Panel ID="categories" runat="server" class="storeDiv">

        </asp:Panel>
    </div>
    <script type="text/javascript" src="storeDriver.js"></script>
</body>
</html>
