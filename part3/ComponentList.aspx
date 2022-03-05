<%@ Page Language="C#" Debug="true" Async="true" AutoEventWireup="true" CodeFile="ComponentList.aspx.cs" Inherits="Store.ComponentList"%>

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
        <form runat="server">
            <asp:Label ID="title" class="title" runat="server"></asp:Label>
			<asp:Panel ID="motherboard" runat="server">
				<div id="10" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-119-353-V04.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">ASUS TUF Gaming X570-PRO</span>
					</div>
					<div class="price">
						<span id="10price">$269.99</span>
						<asp:Button ID="motherboard1" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="11" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-119-311-V03.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">ASUS ROG STRIX B550-F GAMING</span>
					</div>
					<div class="price">
						<span id="11price">$219.15</span>
						<asp:Button ID="motherboard2" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="12" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-144-397-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">MSI B560M PRO-VDH WIFI LGA 1200</span>
					</div>
					<div class="price">
						<span id="12price">$149.99</span>
						<asp:Button ID="motherboard3" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="13" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-144-325-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">MSI MPG B550 GAMING PLUS AM4</span>
					</div>
					<div class="price">
						<span id="13price">$179.57</span>
						<asp:Button ID="motherboard4" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="14" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-119-418-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">ASUS PRIME Z590-V LGA 1200 ATX</span>
					</div>
					<div class="price">
						<span id="14price">$169.99</span>
						<asp:Button ID="motherboard5" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="15" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-145-270-01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">GIGABYTE Z590 AORUS ULTRA LGA 1200 ATX </span>
					</div>
					<div class="price">
						<span id="15price">$329.90</span>
						<asp:Button ID="motherboard6" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="16" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-119-377-V80.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">ASUS ROG STRIX Z590-I GAMING</span>
					</div>
					<div class="price">
						<span id="16price">$369.80</span>
						<asp:Button ID="motherboard7" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="17" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-144-393-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">MSI MAG B560 TOMAHAWK WIFI LGA 1200</span>
					</div>
					<div class="price">
						<span id="17price">$219.99</span>
						<asp:Button ID="motherboard8" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="18" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-144-395-07.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">MSI MAG B560M MORTAR</span>
					</div>
					<div class="price">
						<span id="18price">$199.32</span>
						<asp:Button ID="motherboard9" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="19" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/13-144-458-V08.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">MSI MPG Z590M GAMING EDGE</span>
					</div>
					<div class="price">
						<span id="19price">$279.99</span>
						<asp:Button ID="motherboard10" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
			</asp:Panel>
            <asp:Panel ID="cpu" runat="server">
				<div id="1" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-113-663-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">AMD Ryzen 9 5950X 16-Core</span><span>Speed: 3.4 GHz</span>
					</div>
					<div class="price">
						<span id="1price">$949.99</span>
						<asp:Button ID="cpu1" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="2" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-118-231-V04.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">Intel Core i9-11900K</span><span>Speed: 3.5 GHz</span>
					</div>
					<div class="price">
						<span id="2price">$619.99</span>
						<asp:Button ID="cpu2" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="3" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-113-664-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">AMD Ryzen 9 5900X</span><span>Speed: 3.7 GHz</span>
					</div>
					<div class="price">
						<span id="3price">$659.99</span>
						<asp:Button ID="cpu3" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="4" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-118-233-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">Intel Core i7-11700K</span><span>Speed: 3.6 GHz</span>
					</div>
					<div class="price">
						<span id="4price">$429.99</span>
						<asp:Button ID="cpu4" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="5" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-113-665-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">AMD Ryzen 7 5800X</span><span>Speed: 3.8 GHz</span>
					</div>
					<div class="price">
						<span id="5price">$499.99</span>
						<asp:Button ID="cpu5" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="6" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-118-235-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">Intel Core i5-11600K</span><span>Speed: 3.9 GHz</span>
					</div>
					<div class="price">
						<span id="6price">$319.99</span>
						<asp:Button ID="cpu6" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="7" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-113-666-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">AMD Ryzen 5 5600X</span><span>Speed: 3.7 GHz</span>
					</div>
					<div class="price">
						<span id="7price">$374.99</span>
						<asp:Button ID="cpu7" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="8" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-118-259-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">Intel Core i9-11900KF</span><span>Speed: 3.5 GHz</span>
					</div>
					<div class="price">
						<span id="8price">$599.99</span>
						<asp:Button ID="cpu8" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div id="9" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-113-569-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">AMD Ryzen 5 3rd Gen - RYZEN 5 3600</span><span>Speed: 3.6 GHz</span>
					</div>
					<div class="price">
						<span id="9price">$289.99</span>
						<asp:Button ID="cpu9" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/19-118-123-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">Intel Core i7 10th Gen - Core i7-10700K</span><span>Speed: 3.8 GHz</span>
					</div>
					<div class="price">
						<span>$419.99</span>
						<asp:Button ID="cpu10" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
			</asp:Panel>
            <asp:Panel ID="ram" runat="server">
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/20-232-880-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">G.SKILL Ripjaws V Series</span><span>Size: 16 GB</span>
					</div>
					<div class="price">
						<span>$93.99</span>
						<asp:Button ID="ram1" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/20-236-540-S01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">CORSAIR Vengeance LPX</span><span>Size: 16 GB</span>
					</div>
					<div class="price">
						<span>$79.99</span>
						<asp:Button ID="ram2" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/20-236-408-01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">CORSAIR Vengeance RGB Pro</span><span>Size: 32 GB</span>
					</div>
					<div class="price">
						<span>$233.99</span>
						<asp:Button ID="ram3" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/20-242-624-V02.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">Kingston FURY Impact 16GB</span><span>Size: 16 GB</span>
					</div>
					<div class="price">
						<span>$84.99</span>
						<asp:Button ID="ram4" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/20-232-731-Z01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">G.SKILL Ripjaws V Series 16GB</span><span>Size: 16 GB</span>
					</div>
					<div class="price">
						<span>$86.99</span>
						<asp:Button ID="ram5" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/20-232-999-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">G.SKILL Trident Z Neo Series</span><span>Size: 64 GB</span>
					</div>
					<div class="price">
						<span>$410.99</span>
						<asp:Button ID="ram6" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/20-232-091-04.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">G.SKILL Ripjaws V Series</span><span>Size: 32 GB</span>
					</div>
					<div class="price">
						<span>$132.99</span>
						<asp:Button ID="ram7" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/20-331-635-V01.jpg" style="height:120px;width:170px;"/>
					<div class="listItemTitle">
						<span class="itemName">Team T-Force Delta RGB</span><span>Size: 32 GB</span>
					</div>
					<div class="price">
						<span>$149.99</span>
						<asp:Button ID="ram8" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
            </asp:Panel>
            <asp:Panel ID="display" runat="server">
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/24-281-063-S01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">ASUS TUF Gaming VG27VH1B 27" Curved Monitor</span><span>FPS: 165 Hz</span>
					</div><div class="price">
						<span>$249.99</span>
						<asp:Button ID="display1" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/24-236-978-V90.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">ASUS VG248QG 24" Full HD 1920 x 1080</span><span>FPS: 165 Hz</span>
					</div><div class="price">
						<span>$249.99</span>
						<asp:Button ID="display2" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/24-014-660-S01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">BenQ EW2780 27" Full HD 1920 x 1080</span><span>FPS: 60 Hz</span>
					</div><div class="price">
						<span>$264.99</span>
						<asp:Button ID="display3" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/24-281-049-S01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">ASUS TUF GAMING VG27WQ 27" WQHD</span><span>FPS: 165 Hz</span>
					</div><div class="price">
						<span>$449.99</span>
						<asp:Button ID="display4" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/24-475-134-V06.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">MSI Optix G241V E2 24" Full HD</span><span>FPS: 75 Hz</span>
					</div><div class="price">
						<span>$169.99</span>
						<asp:Button ID="display5" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/24-281-091-S01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">ASUS VL249HE 24" (23.8" Viewable) Eye Care Monitor</span><span>FPS: 75 Hz</span>
					</div><div class="price">
						<span>$189.99</span>
						<asp:Button ID="display6" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/AKVHD2101011Z40F.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">LG - 29WL500-B 29" IPS LED UltraWide</span><span>FPS: 75 Hz</span>
					</div><div class="price">
						<span>$229.99</span>
						<asp:Button ID="display7" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/0JC-000D-006A4-S01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">LG 22BK400H-B 21.5" Full HD</span><span>FPS: 75 Hz</span>
					</div><div class="price">
						<span>$161.99</span>
						<asp:Button ID="display8" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
			</asp:Panel>
            <asp:Panel ID="os" runat="server">
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/32-416-892-11.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Microsoft Windows 10 Home, 64-bit</span>
					</div><div class="price">
						<span>$99.99</span>
						<asp:Button ID="os1" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/32-588-491-08.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Microsoft Windows 10 Pro 64-bit</span>
					</div><div class="price">
						<span>$169.99</span>
						<asp:Button ID="os2" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/32-350-882-V01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Microsoft Windows 11 Pro 64-bit</span>
					</div><div class="price">
						<span>$189.99</span>
						<asp:Button ID="os3" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/32-350-881-V01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Microsoft Windows 11 Home 64-bit</span>
					</div><div class="price">
						<span>$149.99</span>
						<asp:Button ID="os4" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
            </asp:Panel>
            <asp:Panel ID="soundcard" runat="server">
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-102-110-V01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Creative Sound Blaster Z SE 5.1 Channels</span>
					</div><div class="price">
						<span>$130.99</span>
						<asp:Button ID="soundcard1" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div id="2" class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-102-063-07.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Creative Sound Blaster Audigy RX 7.1</span>
					</div><div class="price">
						<span>$79.99</span>
						<asp:Button ID="soundcard2" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-102-105-V16.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Creative Sound Blaster AE-9 Sound Card</span>
					</div><div class="price">
						<span>$429.99</span>
						<asp:Button ID="soundcard3" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-102-026-01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Creative Sound Blaster X-Fi Xtreme Audio 7.1 Channels</span>
					</div><div class="price">
						<span>$79.99</span>
						<asp:Button ID="soundcard4" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-102-062-05.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Creative Sound Blaster Audigy FX 5.1 PCIe</span>
					</div><div class="price">
						<span>$59.99</span>
						<asp:Button ID="soundcard5" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-132-084-V02.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">ASUS Xonar AE 7.1 Channels PCI Express Interface Sound Card</span>
					</div><div class="price">
						<span>$101.99</span>
						<asp:Button ID="soundcard6" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/A4RE_132060100264906998K8rT9kp1UI.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Creative X-Fi SB0670</span>
					</div><div class="price">
						<span>$79.99</span>
						<asp:Button ID="soundcard7" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-271-004-03.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">HT OMEGA Claro Halo</span>
					</div><div class="price">
						<span>$315.00</span>
						<asp:Button ID="soundcard8" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-132-085-V06.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">ASUS Xonar AE 7.1 Channels PCI Express x1 Interface Sound Card</span>
					</div><div class="price">
						<span>$88.44</span>
						<asp:Button ID="soundcard9" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/29-132-086-V01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">ASUS Xonar SE 5.1 Channel 192 kHz</span>
					</div><div class="price">
						<span>$104.99</span>
						<asp:Button ID="soundcard10" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
            </asp:Panel>
            <asp:Panel ID="hd" runat="server">
				<div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/22-184-773-V01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Seagate BarraCuda ST2000DM008 2TB 7200 RPM 256MB</span><span>Storage: 2 TB</span>
					</div><div class="price">
						<span>$54.99</span>
						<asp:Button ID="hd1" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/22-179-299-V01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Seagate BarraCuda ST4000DM004 4TB 5400 RPM 256MB</span><span>Storage: 4 TB</span>
					</div><div class="price">
						<span>$89.99</span>
						<asp:Button ID="hd2" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/22-234-409-V01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">WD Red 4TB NAS Internal Hard Drive - 5400 RPM</span><span>Storage: 4 TB</span>
					</div><div class="price">
						<span>$89.99</span>
						<asp:Button ID="hd3" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/1Z4-0002-01CG2-01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">WD Blue 4TB Desktop Hard Disk Drive - 5400 RPM</span><span>Storage: 4 TB</span>
					</div><div class="price">
						<span>$89.99</span>
						<asp:Button ID="hd4" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/22-179-005-V01.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Seagate IronWolf 4TB NAS Hard Drive 5900 RPM</span><span>Storage: 4 TB</span>
					</div><div class="price">
						<span>$99.99</span>
						<asp:Button ID="hd5" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div><div class="listItem">
					<img class="itemImage" src="https://c1.neweggimages.com/ProductImageCompressAll300/22-184-796-V06.jpg" style="height:120px;width:170px;"/><div class="listItemTitle">
						<span class="itemName">Seagate IronWolf 8TB NAS Hard Drive 7200 RPM</span><span>Storage: 8 TB</span>
					</div><div class="price">
						<span>$254.99</span>
						<asp:Button ID="hd6" Text="Swap" CssClass="swapButton" runat="server"/>
					</div>
				</div>
            </asp:Panel>
        </form>
    </div>

    <script type="text/javascript" src="storeDriver.js"></script>
</body>
</html>
