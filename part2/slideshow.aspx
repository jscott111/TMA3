<%@ Page Language="C#" Debug="true" Async="true" AutoEventWireup="true" CodeFile="Slideshow.aspx.cs" Inherits="Project.Slideshow"%>

<!DOCTYPE html>
<html>
    <head>
        <title>Slideshow</title>
        <style type="text/CSS">
            .button{
                margin-top: 5px;
                margin-bottom: 5px;
                margin-left: 5px;
                margin-right: 5px;
            }
            .panel {
                display:inline-block;
                float: left;
            }
        </style>
    </head>
    <body>
        <asp:Panel ID="pictures" runat="server" HorizontalAlign="Center">

        </asp:Panel>
        
        <form runat="server">
            <asp:HiddenField ID="numPics" runat="server" value="0"></asp:HiddenField>
        </form>
        <asp:Label ID="messages" runat="server"></asp:Label>
        <asp:Panel ID="caption" runat="server" HorizontalAlign="Center">

        </asp:Panel>
        
        <asp:Panel ID="buttons" runat="server" CssClass="panel">
            <button id="toggleButton" type="button" value="random" class="button" style="padding: 5px;">Random</button>
            <button id="playButton" type="button" value="play" class="button" style="padding: 5px;">Pause</button><br />
            <button id="previousButton" type="button" value="previous" class="button" style="padding: 5px;">Previous</button>
            <button id="nextButton" type="button" value="next" class="button" style="padding: 5px;">Next</button><br />
        </asp:Panel>

        <script type="text/javascript" src="driver.js"></script>
        
    </body>
</html>

