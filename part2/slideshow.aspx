<%@ Page Language="C#" Debug="true" Async="true" CodeFile="Slideshow.aspx.cs" Inherits="Project.Slideshow" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Slideshow</title>
        <style type="text/CSS">
            .button{
                margin-top: 5px;
                margin-bottom: 5px;
                margin-left: 5px;
                margin-right: 5px;
            }
            .picture {
                margin: 1em auto 0 auto;
                display: inline-block;
            }
        </style>
    </head>
    <body>
        <asp:Form runat="server">
            <div class="picture">
                <asp:Image ID="picture" runat="server" style="border:1px solid #000000;"></asp:Image><br />
            </div>
            <button id="toggleButton" type="button" value="random" class="button" style="padding: 5px;">Random</button>
            <button id="playButton" type="button" value="play" class="button" style="padding: 5px;">Pause</button><br />
            <button id="previousButton" type="button" value="previous" class="button" style="padding: 5px;">Previous</button>
            <button id="nextButton" type="button" value="next" class="button" style="padding: 5px;">Next</button><br />

            <asp:Label ID="messages" runat="server"></asp:Label>
        </asp:Form>
    </body>
</html>
