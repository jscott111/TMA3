<%@ Page Language="C#" Debug="true" Async="true"%>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Threading.Tasks" %>

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
        <div class="picture">
            <asp:Image ID="picture" runat="server" style="border:1px solid #000000;"></asp:Image><br />
        </div>
        <button id="toggleButton" type="button" value="random" class="button" style="padding: 5px;">Random</button>
        <button id="playButton" type="button" value="play" class="button" style="padding: 5px;">Pause</button><br />
        <button id="previousButton" type="button" value="previous" class="button" style="padding: 5px;">Previous</button>
        <button id="nextButton" type="button" value="next" class="button" style="padding: 5px;">Next</button><br />

        <%
            Task.Run( async () => {
                SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=photos;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                byte[] originalCoverData;
                string imageUrl = "http://tma3.azurewebsites.net/part2/Images/CRW_5523.jpg";
                //int height = (Request.Browser.ScreenPixelsHeight) * 2 - 320;

                originalCoverData = new System.Net.WebClient().DownloadData(imageUrl);
                System.IO.MemoryStream stream = new System.IO.MemoryStream(originalCoverData);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                img.Save(Server.MapPath("img.bmp"));
                SqlCommand command = new SqlCommand("SELECT name, caption, url FROM [dbo].[pic]", con);
                con.Open();
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        picture.ImageUrl = reader[2].ToString();
                        imageUrl = "http://tma3.azurewebsites.net/part2/" + picture.ImageUrl;
                        originalCoverData = new System.Net.WebClient().DownloadData(imageUrl);
                        stream = new System.IO.MemoryStream(originalCoverData);
                        img = System.Drawing.Image.FromStream(stream);
                        img.Save(Server.MapPath("img.bmp"));
                        int picWidth = img.Width;
                        int picHeight = img.Height;
                        float ratio = (float) picHeight / (float) picWidth;
                        picture.Width = new Unit(picHeight / ratio);
                        picture.Height = new Unit(picHeight);
                        await Task.Delay(1000);
                    }
                }
                con.Close();
            });
        %>
    </body>
</html>
