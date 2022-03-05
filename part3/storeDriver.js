
function componentList(id) {
    document.writeln("<form id='form' action='ComponentList.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='part' name='part' value=" + id + ">");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function swapComponent(id, system) {
    document.writeln("<form id='form' action='ComponentList.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='system' name='system' value=" + system + ">");
    document.writeln("    <input type='hidden' id='part' name='part' value=" + id + ">");
    document.writeln("    <input type='hidden' id='swap' name='swap' value='true'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function productView(id, partID, part, swap) {
    document.writeln("<form id='form' action='ProductView.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='system' name='system' value=" + id + ">");
    document.writeln("    <input type='hidden' id='partID' name='partID' value=" + partID + ">");
    document.writeln("    <input type='hidden' id='part' name='part' value=" + part + ">");
    document.writeln("    <input type='hidden' id='swap' name='swap' value=" + swap + ">");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function goHome() {
    document.writeln("<form id='form' action='Home.aspx' runat='server'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function addToCart(system, motherboard, ram, cpu, display, os, soundcard, hd) {
    document.writeln("<form id='form' action='Cart.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='system' name='system' value='" + system + "'>");
    document.writeln("    <input type='hidden' id='motherboard' name='motherboard' value='" + motherboard + "'>");
    document.writeln("    <input type='hidden' id='ram' name='ram' value='" + ram + "'>");
    document.writeln("    <input type='hidden' id='cpu' name='cpu' value='" + cpu + "'>");
    document.writeln("    <input type='hidden' id='display' name='display' value='" + display + "'>");
    document.writeln("    <input type='hidden' id='os' name='os' value='" + os + "'>");
    document.writeln("    <input type='hidden' id='soundcard' name='soundcard' value='" + soundcard + "'>");
    document.writeln("    <input type='hidden' id='hd' name='hd' value='" + hd + "'>");
    document.writeln("    <input type='hidden' id='action' name='action' value='add'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function deleteCartItem(systemID, userID, orderID) {
    document.writeln("<form id='form' action='Cart.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='system' name='system' value='" + systemID + "'>");
    document.writeln("    <input type='hidden' id='user' name='user' value='" + userID + "'>");
    document.writeln("    <input type='hidden' id='orderID' name='orderID' value='" + orderID + "'>");
    document.writeln("    <input type='hidden' id='action' name='action' value='delete'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function viewOrder(orderID, userID) {
    document.writeln("<form id='form' action='Cart.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='orderID' name='orderID' value='" + orderID + "'>");
    document.writeln("    <input type='hidden' id='user' name='user' value='" + userID + "'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function viewCart() {
    document.writeln("<form id='form' action='Cart.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='action' name='action' value='view'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function loginPage() {
    document.writeln("<form id='form' action='Login.aspx' runat='server'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}