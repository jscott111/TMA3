
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

function addToCart(ip, system) {
    document.writeln("<form id='form' action='Cart.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='ip' name='ip' value=" + ip + ">");
    document.writeln("    <input type='hidden' id='system' name='system' value=" + system + ">");
    document.writeln("    <input type='hidden' id='action' name='action' value='add'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function viewCart(ip) {
    document.writeln("<form id='form' action='Cart.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='ip' name='ip' value='" + ip + "'>");
    document.writeln("    <input type='hidden' id='action' name='action' value='view'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}
