<%@ Page Language="C#" Debug="true" Async="true" AutoEventWireup="true" CodeFile="SystemList.aspx.cs" Inherits="Store.SystemList"%>

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

    <div class="content">
        <div class="content">
        <span id="title" class="title">Pre-Built Systems</span>
        <div id="list">
			<div id="1" class="listItem" onclick="productView('1', '', '', false)" style="cursor:pointer;">
				<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-190-01.jpg" style="height:120px;width:170px;"/>
				<div class="listItemTitle">
					<span class="itemName">Falcon</span><span>Speed: 3.4 GHz</span><span>Size: 16 GB</span><span>FPS: 165Hz</span>
				</div>
				<div id="1priceDiv" class="price">
					<span id="1price">$2,118.86</span>
				</div>
			</div>
			<div id="2" class="listItem" onclick="productView('2', '', '', false)" style="cursor:pointer;">
				<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-211-01.jpg" style="height:120px;width:170px;"/>
				<div class="listItemTitle">
					<span class="itemName">Hawk</span><span>Speed: 3.5 GHz</span><span>Size: 16 GB</span><span>FPS: 165Hz</span>
				</div>
				<div id="2priceDiv" class="price">
					<span id="2price" style="text-decoration: line-through;">$1,757.94</span><span class="price" style="color: red;">$1,598.13</span>
				</div>
			</div>
			<div id="3" class="listItem" onclick="productView('3', '', '', false)" style="cursor:pointer;">
				<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-198-01.jpg" style="height:120px;width:170px;"/>
				<div class="listItemTitle">
					<span class="itemName">Eagle</span><span>Speed: 3.7 GHz</span><span>Size: 32 GB</span><span>FPS: 60Hz</span>
				</div>
				<div id="3priceDiv" class="price">
					<span id="3price" style="text-decoration: line-through;">$1,645.94</span><span class="price" style="color: red;">$1,524.02</span>
				</div>
			</div>
			<div id="4" class="listItem" onclick="productView('4', '', '', false)" style="cursor:pointer;">
				<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-201-01.jpg" style="height:120px;width:170px;"/>
				<div class="listItemTitle">
					<span class="itemName">Owl</span><span>Speed: 3.6 GHz</span><span>Size: 16 GB</span><span>FPS: 165Hz</span>
				</div>
				<div id="4priceDiv" class="price">
					<span id="4price">$1,433.94</span>
				</div>
			</div>
			<div id="5" class="listItem" onclick="productView('5', '', '', false)" style="cursor:pointer;">
				<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-206-01.jpg" style="height:120px;width:170px;"/>
				<div class="listItemTitle">
					<span class="itemName">Penguin</span><span>Speed: 3.8 GHz</span><span>Size: 16 GB</span><span>FPS: 75Hz</span>
				</div>
				<div id="5priceDiv" class="price">
					<span id="5price">$1,354.52</span>
				</div>
			</div>
			<div id="6" class="listItem" onclick="productView('6', '', '', false)" style="cursor:pointer;">
				<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-219-01.jpg" style="height:120px;width:170px;"/>
				<div class="listItemTitle">
					<span class="itemName">Stork</span><span>Speed: 3.9 GHz</span><span>Size: 64 GB</span><span>FPS: 75Hz</span>
				</div>
				<div id="6priceDiv" class="price">
					<span id="6price" style="text-decoration: line-through;">$1,135.10</span><span class="price" style="color: red;">$1,004.51</span>
				</div>
			</div>
			<div id="7" class="listItem" onclick="productView('7', '', '', false)" style="cursor:pointer;">
				<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/83-360-195-01.jpg" style="height:120px;width:170px;"/>
				<div class="listItemTitle">
					<span class="itemName">Flamingo</span><span>Speed: 3.7 GHz</span><span>Size: 32 GB</span><span>FPS: 75Hz</span>
				</div>
				<div id="7priceDiv" class="price">
					<span id="7price">$1,859.75</span>
				</div>
			</div>
	</div>
    </div>
    </div>

    <script type="text/javascript" src="storeDriver.js"></script>
</body>
</html>

