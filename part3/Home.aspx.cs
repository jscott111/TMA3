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
            double total = 0;
            float price = 0;
            string[,] component = new string[6, 2] { { "Motherboards", "motherboard" }, { "CPUs", "cpu" }, { "RAM", "ram" }, { "Displays", "display" }, { "Operating Systems", "os" }, { "Soundcards", "soundcard" } };
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlConnection priceCon = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("SELECT TOP(4) name, url, price, id FROM [dbo].[systems]", con);
            SqlCommand priceCommand;
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

                    priceCommand = new SqlCommand("SELECT [cpu].[price], [motherboard].[price], [display].[price], [os].[price], [ram].[price], [soundcard].[price] FROM[dbo].[systems] INNER JOIN[cpu] ON[systems].[cpu] = [cpu].[id] INNER JOIN[motherboard] ON[systems].[motherboard] = [motherboard].[id] INNER JOIN[display] ON[systems].[display] = [display].[id] INNER JOIN[os] ON[systems].[os] = [os].[id] INNER JOIN[ram] ON[systems].[ram] = [ram].[id] INNER JOIN[soundcard] ON[systems].[soundcard] = [soundcard].[id] WHERE[systems].[id] = " + reader[3].ToString(), priceCon);
                    priceCon.Open();
                    priceCommand.ExecuteNonQuery();
                    using (SqlDataReader priceReader = priceCommand.ExecuteReader())
                    {
                        while (priceReader.Read())
                        {
                            total += Convert.ToDouble(priceReader[0].ToString());
                            total += Convert.ToDouble(priceReader[1].ToString());
                            total += Convert.ToDouble(priceReader[2].ToString());
                            total += Convert.ToDouble(priceReader[3].ToString());
                            total += Convert.ToDouble(priceReader[4].ToString());
                            total += Convert.ToDouble(priceReader[5].ToString());
                        }
                    }
                    priceCon.Close();
                    itemPrice.Text = total.ToString("C2");
                    itemPrice.ID = reader[3].ToString() + "price";

                    panel.Controls.Add(picture);
                    panel.Controls.Add(itemName);
                    panel.Controls.Add(itemPrice);
                    panel.Attributes["class"] = "itemDiv";
                    panel.Attributes["onClick"] = "productView('" + reader[3].ToString() + "', '', '', 'false')";
                    panel.ID = reader[3].ToString();

                    bestSeller.Controls.Add(panel);
                    total = 0;
                }
            }


            command = new SqlCommand("SELECT [systems].name, [systems].url, [systems].price, [systems].id, [onSale].discount FROM[dbo].[systems] INNER JOIN [dbo].[onSale] ON [systems].id = [onSale].system", con);
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

                    priceCommand = new SqlCommand("SELECT [cpu].[price], [motherboard].[price], [display].[price], [os].[price], [ram].[price], [soundcard].[price] FROM[dbo].[systems] INNER JOIN[cpu] ON[systems].[cpu] = [cpu].[id] INNER JOIN[motherboard] ON[systems].[motherboard] = [motherboard].[id] INNER JOIN[display] ON[systems].[display] = [display].[id] INNER JOIN[os] ON[systems].[os] = [os].[id] INNER JOIN[ram] ON[systems].[ram] = [ram].[id] INNER JOIN[soundcard] ON[systems].[soundcard] = [soundcard].[id] WHERE[systems].[id] = " + reader[3].ToString(), priceCon);
                    priceCon.Open();
                    priceCommand.ExecuteNonQuery();
                    using (SqlDataReader priceReader = priceCommand.ExecuteReader())
                    {
                        while (priceReader.Read())
                        {
                            total += Convert.ToDouble(priceReader[0].ToString());
                            total += Convert.ToDouble(priceReader[1].ToString());
                            total += Convert.ToDouble(priceReader[2].ToString());
                            total += Convert.ToDouble(priceReader[3].ToString());
                            total += Convert.ToDouble(priceReader[4].ToString());
                            total += Convert.ToDouble(priceReader[5].ToString());
                        }
                    }
                    priceCon.Close();
                    price = (float)((float) total / (1 + Convert.ToDouble(reader[4]) / 100));
                    discountPrice.Text = Convert.ToDecimal(price.ToString()).ToString("C2");
                    discountPrice.Attributes.Add("style", "color: red;");
                    itemPrice.Text = total.ToString("C2");
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
                    panel.Attributes["onClick"] = "productView('" + reader[3].ToString() + "', '', '', 'false')";

                    onSale.Controls.Add(panel);
                    total = 0;
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
