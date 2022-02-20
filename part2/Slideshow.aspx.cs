using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Slideshow : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int counter = 0;
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=photos;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            byte[] imageData;
            string imageUrl = "http://tma3.azurewebsites.net/part2/Images/CRW_5523.jpg";
            int height = (Request.Browser.ScreenPixelsHeight) * 2 - 400;

            imageData = new System.Net.WebClient().DownloadData(imageUrl);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(imageData);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(Server.MapPath("img.bmp"));
            SqlCommand command = new SqlCommand("SELECT name, caption, url FROM [dbo].[pic]", con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Image picture = new Image();
                        
                    imageUrl = "http://tma3.azurewebsites.net/part2/Images/" + reader[2].ToString();
                    imageData = new System.Net.WebClient().DownloadData(imageUrl);
                    stream = new System.IO.MemoryStream(imageData); 
                    img = System.Drawing.Image.FromStream(stream);
                    img.Save(Server.MapPath("img.bmp"));
                    float ratio = (float)img.Height / (float)img.Width;
                    picture.Width = new Unit(height / ratio);
                    picture.Height = new Unit(height);

                    picture.Style.Add("display", "none");
                    picture.ImageUrl = imageUrl;
                    picture.ID = counter.ToString();
                    pictures.Controls.Add(picture);

                    Label label = new Label();
                    label.Text = reader[1].ToString();
                    label.ID = "cap" + counter;
                    label.Style.Add("display", "none");
                    caption.Controls.Add(label);

                    counter++;
                }
            }
            con.Close();
            counter--;
            numPics.Value = counter.ToString();
        }
    }
}


