<%@ Page Language="C#" Debug="true"%>
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
    </head>
    <body>
        <%
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=photos;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            System.Drawing.Image img = System.Drawing.Image.FromStream(@"https://tma3.azurewebsites.net/part2/Images/CRW_5523.jpg");

            SqlCommand command = new SqlCommand("SELECT name, caption, url FROM [dbo].[pic]", con);
            con.Open();
            command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    picture.ImageUrl = reader[2].ToString();
                    img = System.Drawing.Image.FromStream(@"https://tma3.azurewebsites.net/part2/" + picture.ImageUrl);
                }
            }
            con.Close();

            int picWidth = img.Width;
            int picHeight = img.Height;

            float ratio = (float) picHeight / (float) picWidth;

            picture.Width = new Unit(Request.Browser.ScreenPixelsHeight / ratio);
            picture.Height = new Unit(Request.Browser.ScreenPixelsHeight);
        %>
        <asp:Image ID="picture" runat="server" style="border:1px solid #000000;"></asp:Image><br />
        <button id="toggleButton" type="button" value="random" class="button" style="padding: 5px;">Random</button>
        <button id="playButton" type="button" value="play" class="button" style="padding: 5px;">Pause</button><br />
        <button id="previousButton" type="button" value="previous" class="button" style="padding: 5px;">Previous</button>
        <button id="nextButton" type="button" value="next" class="button" style="padding: 5px;">Next</button><br />
    </body>
</html>
