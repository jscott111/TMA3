
<%@ Page Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>

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
        </style>
        <configuration>
            <system.web>
                <customErrors mode="Off"/>
            </system.web>
        </configuration>
    </head>
    <body>
        <asp:Image ID="picture" runat="server" style="border:1px solid #000000;"></asp:Image>
        <button id="toggleButton" type="button" value="random" class="button" style="padding: 5px;">Random</button>
        <button id="playButton" type="button" value="play" class="button" style="padding: 5px;">Pause</button><br />
        <button id="previousButton" type="button" value="previous" class="button" style="padding: 5px;">Previous</button>
        <button id="nextButton" type="button" value="next" class="button" style="padding: 5px;">Next</button><br />
        <!--<%
            
            drawImageActualSize();


            void drawImageActualSize() {
                SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=photos;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            
                SqlCommand command = new SqlCommand("SELECT name, caption, url FROM [dbo].[pic]", con);
                con.Open();
                command.ExecuteNonQuery();

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        picture.ImageUrl = reader[2].ToString();
                    }
                }
                con.Close();

                //picture.Width = Request.Browser.ScreenPixelsWidth - 20;
                //picture.Height = Request.Browser.ScreenPixelsHeight - 110;

                //float ratio = this.naturalHeight / picture.Height;

                //ctx.drawImage(this, 0, 0, this.naturalWidth / ratio, picture.Height);
                //ctx.font = "20px Arial";
                //ctx.strokeText(findElement(pictures, "id", (20 + counter) % 20)["caption"], 850, 50);
            }


            
            /*var counter = 0;
            var image = new Image();
            var sequentialID;
            var randomID;
            var canvas = document.getElementById("canvas");
            var toggleButton = document.getElementById("toggleButton");
            var playButton = document.getElementById("playButton");
            var previousButton = document.getElementById("previousButton");
            var nextButton = document.getElementById("nextButton");

            image.src = findElement(pictures, "id", 0)["source"];
            image.onload = drawImageActualSize;

            sequentialLoop();

            toggleButton.addEventListener("click", e => {
                if(toggleButton.innerHTML == "Random"){
                toggleButton.innerHTML = "Sequential";
                clearInterval(sequentialID);
                nextButton.style.display = "none";
                previousButton.style.display = "none";
                randomLoop();
                }else{
                toggleButton.innerHTML = "Random";
                clearInterval(randomID);
                nextButton.style.display = "inline";
                previousButton.style.display = "inline";
                sequentialLoop();
                }
            })

            playButton.addEventListener("click", e => {
                if(playButton.innerHTML == "Pause"){
                playButton.innerHTML = "Play";
                clearInterval(sequentialID);
                clearInterval(randomID);
                }else{
                playButton.innerHTML = "Pause";
                if(toggleButton.innerHTML == "Random"){
                    sequentialLoop();
                }else{
                    randomLoop();
                }
                }
            })

            nextButton.addEventListener("click", e => {
                clearInterval(sequentialID);
                counter++;
                image.src = findElement(pictures, "id", (100 + counter) % 20)["source"];
                image.onload = drawImageActualSize;
                sequentialLoop();
            })

            previousButton.addEventListener("click", e => {
                clearInterval(sequentialID);
                counter--;
                image.src = findElement(pictures, "id", (100 + counter) % 20)["source"];
                image.onload = drawImageActualSize;
                sequentialLoop();
            })





            function randomLoop(){
                randomID = setInterval(function(){
                counter = Math.floor(Math.random() * 20);
                image.src = findElement(pictures, "id", (100 + counter) % 20)["source"];
                image.onload = drawImageActualSize;
                }, 5000)
            }

            function sequentialLoop(){
                sequentialID = setInterval(function(){
                counter++;
                image.src = findElement(pictures, "id", (100 + counter) % 20)["source"];
                image.onload = drawImageActualSize;
                }, 5000)
            }



            function findElement(a, name, value) {
                for (var i=0; i < a.length; i++)
                if (a[i][name] == value)
                    return a[i];
            }*/
        %>-->
    </body>
</html>
