using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Threading.Tasks;

namespace Project
{
    public partial class Slideshow : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            messages.Text += "Program Started ";
            Task.Run(async () =>
            {
                SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=photos;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                byte[] imageData;
                string imageUrl = "http://tma3.azurewebsites.net/part2/Images/CRW_5523.jpg";
                //int height = (Request.Browser.ScreenPixelsHeight) * 2 - 320;
                int height = 500;

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
                        picture.ImageUrl = reader[2].ToString();
                        imageUrl = "http://tma3.azurewebsites.net/part2/" + picture.ImageUrl;
                        imageData = new System.Net.WebClient().DownloadData(imageUrl);
                        stream = new System.IO.MemoryStream(imageData);
                        img = System.Drawing.Image.FromStream(stream);
                        img.Save(Server.MapPath("img.bmp"));
                        float ratio = (float)img.Height / (float)img.Width;
                        picture.Width = new Unit(height / ratio);
                        picture.Height = new Unit(height);
                        await Task.Delay(1000);
                        print();
                    }
                }
                con.Close();
            });

            void print()
            {
                messages.Text += "Picture Loaded ";
            }

            messages.Text += "Program Finished ";
        }
    }
}


