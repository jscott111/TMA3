<%@ Page Language="C#" Debug="true" Async="true" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Store.Home"%>

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
                <img id="cart" src="https://icon-library.com/images/shop-cart-icon/shop-cart-icon-13.jpg" width="50" height="50" class="clickable" onclick="viewCart()"/>
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
        <div class="content">
            <div>
                <h2>Best Sellers</h2>
                <a href="SystemList.aspx" class="seeMore">See More</a>
            </div>
            <div id="bestSeller" class="storeDiv">
	            <div id="1" class="itemDiv" onclick="productView('1', '', '', 'false')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-190-01.jpg" style="height:130px;width:160px;"/><span>Falcon</span><span id="1price">$2,118.86</span>
	            </div>
                <div id="2" class="itemDiv" onclick="productView('2', '', '', 'false')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-211-01.jpg" style="height:130px;width:160px;"/><span>Hawk</span><span id="2price" style="text-decoration: line-through;">$1,757.94</span><span style="color: red;">$1,598.13</span>
	            </div>
                <div id="3" class="itemDiv" onclick="productView('3', '', '', 'false')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-198-01.jpg" style="height:130px;width:160px;"/><span>Eagle</span><span id="3price" style="text-decoration: line-through;">$1,645.94</span><span style="color: red;">$1,524.02</span>
	            </div>
                <div id="4" class="itemDiv" onclick="productView('4', '', '', 'false')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-201-01.jpg" style="height:130px;width:160px;"/><span>Owl</span><span id="4price">$1,433.94</span>
	            </div>
            </div>

            <h2>On Sale</h2>
            <div id="onSale" class="storeDiv">
	            <div class="itemDiv" onclick="productView('2', '', '', 'false')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-211-01.jpg" style="height:130px;width:160px;"/><span>Hawk</span><span style="text-decoration: line-through;">$1,757.94</span><span style="color: red;">$1,598.13</span>
	            </div>
                <div class="itemDiv" onclick="productView('3', '', '', 'false')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-198-01.jpg" style="height:130px;width:160px;"/><span>Eagle</span><span style="text-decoration: line-through;">$1,645.94</span><span style="color: red;">$1,524.02</span>
	            </div>
                <div class="itemDiv" onclick="productView('6', '', '', 'false')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-219-01.jpg" style="height:130px;width:160px;"/><span>Stork</span><span style="text-decoration: line-through;">$1,135.10</span><span style="color: red;">$1,004.51</span>
	            </div>
            </div>
    
            <h2>Components</h2>
            <div id="categories" class="storeDiv">
	            <div class="itemDiv" onclick="componentList('motherboard')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/13-119-353-V04.jpg" style="height:130px;width:160px;"/><span>Motherboards</span>
	            </div>
                <div class="itemDiv" onclick="componentList('cpu')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/19-113-663-V01.jpg" style="height:130px;width:160px;"/><span>CPUs</span>
	            </div>
                <div class="itemDiv" onclick="componentList('ram')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/20-232-880-V01.jpg" style="height:130px;width:160px;"/><span>RAM</span>
	            </div>
                <div class="itemDiv" onclick="componentList('display')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/24-281-063-S01.jpg" style="height:130px;width:160px;"/><span>Displays</span>
	            </div>
                <div class="itemDiv" onclick="componentList('os')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/32-416-892-11.jpg" style="height:130px;width:160px;"/><span>Operating Systems</span>
	            </div>
                <div class="itemDiv" onclick="componentList('soundcard')">
		            <img src="https://c1.neweggimages.com/ProductImageCompressAll300/29-102-110-V01.jpg" style="height:130px;width:160px;"/><span>Soundcards</span>
	            </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="storeDriver.js"></script>
</body>
</html>
