using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Store
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            float price = 0;
            string[,] component = new string[6, 2] { { "Motherboards", "motherboard" }, { "CPUs", "cpu" }, { "RAM", "ram" }, { "Displays", "display" }, { "Operating Systems", "os" }, { "Soundcards", "soundcard" } };
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("SELECT TOP(4) name, url, price, id FROM [dbo].[systems]", con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Image picture = new Image();
                    Panel panel = new Panel();
                    Label itemName = new Label();
                    Label itemPrice = new Label();

                    itemName.Text = reader[0].ToString();

                    picture.ImageUrl = reader[1].ToString();
                    picture.Height = new Unit(130);
                    picture.Width = new Unit(160);

                    itemPrice.Text = Convert.ToDecimal(reader[2].ToString()).ToString("C2");
                    itemPrice.ID = reader[3].ToString() + "price";

                    panel.Controls.Add(picture);
                    panel.Controls.Add(itemName);
                    panel.Controls.Add(itemPrice);
                    panel.Attributes["class"] = "itemDiv";
                    panel.ID = reader[3].ToString();

                    bestSeller.Controls.Add(panel);
                }
            }
            con.Close();


            command = new SqlCommand("SELECT [systems].name, [systems].url, [systems].price, [systems].id, [onSale].discount FROM[dbo].[systems] INNER JOIN [dbo].[onSale] ON [systems].id = [onSale].system", con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Image picture = new Image();
                    Panel panel = new Panel();
                    Label itemName = new Label();
                    Label itemPrice = new Label();
                    Label discountPrice = new Label();
                    Label discountBSPrice = new Label();

                    itemName.Text = reader[0].ToString();

                    picture.ImageUrl = reader[1].ToString();
                    picture.Height = new Unit(130);
                    picture.Width = new Unit(160);

                    price = (float)((float) Convert.ToDouble(reader[2]) / (1 + Convert.ToDouble(reader[4]) / 100));
                    discountPrice.Text = Convert.ToDecimal(price.ToString()).ToString("C2");
                    discountPrice.Attributes.Add("style", "color: red;");
                    itemPrice.Text = Convert.ToDecimal(reader[2].ToString()).ToString("C2");
                    itemPrice.Attributes.Add("style", "text-decoration: line-through;");
                    discountBSPrice.Text = discountPrice.Text;
                    discountBSPrice.Attributes.Add("style", "color: red;");

                    if (Page.FindControl(reader[3].ToString() + "price") != null){
                        Label bs = (Label) Page.FindControl(reader[3].ToString() + "price");
                        bs.Attributes.Add("style", "text-decoration: line-through;");
                        Page.FindControl(reader[3].ToString()).Controls.Add(discountBSPrice);
                    }
                    
                    panel.Controls.Add(picture);
                    panel.Controls.Add(itemName);
                    panel.Controls.Add(itemPrice);
                    panel.Controls.Add(discountPrice);
                    panel.Attributes["class"] = "itemDiv";

                    onSale.Controls.Add(panel);
                }
            }
            con.Close();



            for (int i = 0; i < 6; i++)
            {
                Image image = new Image();
                Panel box = new Panel();
                Label label = new Label();
                image.ImageUrl = getURL(component[i, 1]);
                image.Height = new Unit(130);
                image.Width = new Unit(160);
                label.Text = component[i, 0];
                box.Attributes["class"] = "itemDiv";
                box.Attributes["onClick"] = "componentList('" + component[i, 1] + "')";
                box.Controls.Add(image);
                box.Controls.Add(label);

                categories.Controls.Add(box);
            }
        }

        public string getURL(string table)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("SELECT url FROM [dbo].[" + table + "]", con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    return reader[0].ToString();
                }
            }
            con.Close();

            return "";
        }
    }
}