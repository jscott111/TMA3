
function componentList(id) {
    document.writeln("<form id='form' action='ComponentList.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='system' name='system' value=" + id + ">");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function goHome() {
    document.writeln("<form id='form' action='Home.aspx' runat='server'>");
    document.writeln("</form>");

    document.getElementById("form").submit();
}

function productView(id) {
    document.writeln("<form id='form' action='ProductView.aspx' runat='server'>");
    document.writeln("    <input type='hidden' id='system' name='system' value=" + id + ">");
    document.writeln("</form>");

    document.getElementById("form").submit();
}
