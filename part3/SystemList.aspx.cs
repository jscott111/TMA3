using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Store
{
    public partial class SystemList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            float price;
            double total = 0;
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("SELECT[systems].[id], [systems].[name], [systems].[price], [systems].[url], [cpu].[speed], [ram].[size], [display].[fps] FROM[dbo].[systems] INNER JOIN[cpu] ON[systems].[id] = [cpu].[id] INNER JOIN[ram] ON[systems].[id] = [ram].[id] INNER JOIN[display] ON[systems].[id] = [display].[id]", con);
            SqlConnection priceCon = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
                    Label speed = new Label();
                    Label size = new Label();
                    Label fps = new Label();
                    Panel div = new Panel();
                    Panel priceDiv = new Panel();

                    itemName.Text = reader[1].ToString();
                    itemName.Attributes["class"] = "itemName";
                    div.Controls.Add(itemName);
                    div.Attributes["class"] = "listItemTitle";
                    speed.Text = "Speed: " + reader[4].ToString() + " GHz";
                    size.Text = "Size: " + reader[5].ToString() + " GB";
                    fps.Text = "FPS: " + reader[6].ToString() + "Hz";
                    div.Controls.Add(speed);
                    div.Controls.Add(size);
                    div.Controls.Add(fps);

                    picture.ImageUrl = reader[3].ToString();
                    picture.Height = new Unit(120);
                    picture.Width = new Unit(170);
                    picture.Attributes["class"] = "itemImage";

                    priceCommand = new SqlCommand("SELECT [cpu].[price], [motherboard].[price], [display].[price], [os].[price], [ram].[price], [soundcard].[price] FROM[dbo].[systems] INNER JOIN[cpu] ON[systems].[cpu] = [cpu].[id] INNER JOIN[motherboard] ON[systems].[motherboard] = [motherboard].[id] INNER JOIN[display] ON[systems].[display] = [display].[id] INNER JOIN[os] ON[systems].[os] = [os].[id] INNER JOIN[ram] ON[systems].[ram] = [ram].[id] INNER JOIN[soundcard] ON[systems].[soundcard] = [soundcard].[id] WHERE[systems].[id] = " + reader[0].ToString(), priceCon);
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
                    itemPrice.ID = reader[0].ToString() + "price";
                    priceDiv.Attributes["class"] = "price";
                    priceDiv.ID = reader[0].ToString() + "priceDiv";
                    priceDiv.Controls.Add(itemPrice);

                    panel.Attributes["class"] = "listItem";
                    panel.Attributes["onClick"] = "productView('" + reader[0].ToString() + "', '', '', false)";
                    panel.Style.Add("cursor", "pointer");
                    panel.Controls.Add(picture);
                    panel.Controls.Add(div);
                    panel.Controls.Add(priceDiv);
                    panel.ID = reader[0].ToString();

                    list.Controls.Add(panel);
                    total = 0;
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
                    Label discountPrice = new Label();
                    Label itemPrice = (Label) Page.FindControl(reader[3].ToString() + "price");

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
                    itemPrice.Text = Convert.ToDecimal(reader[2].ToString()).ToString("C2");
                    itemPrice.Attributes.Add("style", "text-decoration: line-through;");
                    discountPrice.Attributes["class"] = "price";

                    Page.FindControl(reader[3].ToString() + "priceDiv").Controls.Add(discountPrice);
                    total = 0;
                }
            }
        }
    }
}
