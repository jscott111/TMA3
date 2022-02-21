using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Store
{
    public partial class ProductView : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[,] component = new string[7, 3] { { "Motherboard", "motherboard", "" }, { "CPU", "cpu", "" }, { "RAM", "ram", "" }, { "Display", "display", "" }, { "OS", "os", "" }, { "Soundcard", "soundcard", "" }, { "Hard Drive", "hd", "" } };
            string id = Request.QueryString["system"];
            string systemID = "";
            double total = 0;
            Image picture = new Image();
            Panel panel = new Panel();
            Label itemName = new Label();
            Label itemPrice = new Label();
            Label speed = new Label();
            Label size = new Label();
            Label fps = new Label();
            Label storage = new Label();
            Label tax = new Label();
            Label shipping = new Label();
            Label totalPrice = new Label();
            Panel itemInfoDiv = new Panel();
            Panel priceDiv = new Panel();
            Button cart = new Button();
            SqlCommand command = new SqlCommand();

            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            if (Request.QueryString["swap"] == "true")
            {
                command = new SqlCommand("UPDATE [dbo].[systems] SET " + Request.QueryString["part"] + " = " + Request.QueryString["partID"] + " WHERE id = " + Request.QueryString["system"], con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

            command = new SqlCommand("SELECT [cpu].[price], [motherboard].[price], [display].[price], [os].[price], [ram].[price], [soundcard].[price], [hd].[price] FROM[dbo].[systems] INNER JOIN [hd] ON [systems].[hd] = [hd].[id]  INNER JOIN[cpu] ON[systems].[cpu] = [cpu].[id] INNER JOIN[motherboard] ON[systems].[motherboard] = [motherboard].[id] INNER JOIN[display] ON[systems].[display] = [display].[id] INNER JOIN[os] ON[systems].[os] = [os].[id] INNER JOIN[ram] ON[systems].[ram] = [ram].[id] INNER JOIN[soundcard] ON[systems].[soundcard] = [soundcard].[id] WHERE[systems].[id] = " + id, con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    total += Convert.ToDouble(reader[0].ToString());
                    total += Convert.ToDouble(reader[1].ToString());
                    total += Convert.ToDouble(reader[2].ToString());
                    total += Convert.ToDouble(reader[3].ToString());
                    total += Convert.ToDouble(reader[4].ToString());
                    total += Convert.ToDouble(reader[5].ToString());
                }
            }
            con.Close();


            command = new SqlCommand("SELECT [systems].[id], [systems].[name], [systems].[price], [systems].[url], [cpu].[speed], [ram].[size], [display].[fps], [hd].[size] FROM [dbo].[systems] INNER JOIN [hd] ON [systems].[hd] = [hd].[id] INNER JOIN [cpu] ON [systems].[cpu] = [cpu].[id] INNER JOIN [ram] ON [systems].[ram] = [ram].[id] INNER JOIN [display] ON [systems].[display] = [display].[id] WHERE [systems].[id] = " + id, con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    systemID = reader[0].ToString();

                    itemName.Text = reader[1].ToString();
                    itemName.Attributes["class"] = "itemName";
                    itemInfoDiv.Controls.Add(itemName);
                    itemInfoDiv.Attributes["class"] = "productInfo";
                    speed.Text = "Speed: " + reader[4].ToString() + " GHz";
                    size.Text = "Size: " + reader[5].ToString() + " GB";
                    fps.Text = "FPS: " + reader[6].ToString() + "Hz";
                    storage.Text = "Storage: " + reader[7].toString() + " TB";
                    itemInfoDiv.Controls.Add(speed);
                    itemInfoDiv.Controls.Add(size);
                    itemInfoDiv.Controls.Add(fps);
                    
                    picture.ImageUrl = reader[3].ToString();
                    picture.Height = new Unit(200);
                    picture.Width = new Unit(270);
                    picture.Attributes["class"] = "itemImage";

                    itemPrice.Text = total.ToString("C2");
                    itemPrice.ID = systemID + "price";
                    itemPrice.Attributes.Add("style", "font-size: 30px;margin-right: 10px; float: right;");

                    cart.Text = "Add to Cart";
                    cart.Attributes["class"] = "cartButton";
                    cart.OnClientClick = "addToCart('" + systemID + "')";

                    tax.Text = "Taxes:  " + (total * 0.15).ToString("C2");
                    tax.Attributes["class"] = "taxAndShippingInfo";

                    shipping.Text = "Shipping:  $8.99";
                    shipping.Attributes["class"] = "taxAndShippingInfo";
                    shipping.Attributes.Add("style", "text-decoration: underline;");

                    totalPrice.Text = "Total:  " + ((total * 1.15) + 8.99).ToString("C2");
                    totalPrice.Attributes["class"] = "taxAndShippingInfo";
                    totalPrice.Attributes.Add("style", "font-weight: bold;");

                    priceDiv.Attributes["class"] = "productViewPrice";
                    priceDiv.ID = reader[0].ToString() + "priceDiv";
                    priceDiv.Controls.Add(itemPrice);
                    priceDiv.Controls.Add(tax);
                    priceDiv.Controls.Add(shipping);
                    priceDiv.Controls.Add(totalPrice);
                    priceDiv.Controls.Add(cart);

                    panel.Attributes["class"] = "productDisplay";
                    panel.Controls.Add(picture);
                    panel.Controls.Add(itemInfoDiv);
                    panel.ID = reader[0].ToString();

                    product.Controls.Add(panel);
                    product.Controls.Add(priceDiv);
                }
            }
            con.Close();

            command = new SqlCommand("SELECT discount FROM [dbo].[onSale] WHERE system = " + systemID, con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Label discountPrice = new Label();

                    float price = (float)((float)total / (1 + Convert.ToDouble(reader[0]) / 100));
                    discountPrice.Text = Convert.ToDecimal(price.ToString()).ToString("C2");
                    discountPrice.Attributes.Add("style", "color: red; font-size: 30px; margin-right: 10px; float: right;");
                    itemPrice.Text = total.ToString("C2");
                    itemPrice.Attributes.Add("style", "font-size: 30px; margin-right: 10px; float: right; text-decoration: line-through;");

                    tax.Text = "Taxes:  " + (price * 0.15).ToString("C2");
                    tax.Attributes["class"] = "taxAndShippingInfo";

                    shipping.Text = "Shipping:  $8.99";
                    shipping.Attributes["class"] = "taxAndShippingInfo";
                    shipping.Attributes.Add("style", "text-decoration: underline;");

                    totalPrice.Text = "Total:  " + ((price * 1.15) + 8.99).ToString("C2");
                    totalPrice.Attributes["class"] = "taxAndShippingInfo";
                    totalPrice.Attributes.Add("style", "font-weight: bold;");

                    priceDiv.Controls.AddAt(1, discountPrice);
                }
            }
            con.Close();

                    product.Attributes["class"] = "product";

            command = new SqlCommand("SELECT motherboard, cpu, ram, display, os, soundcard, hd FROM [dbo].[systems] WHERE id = " + systemID, con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    component[0, 2] = reader[0].ToString();
                    component[1, 2] = reader[1].ToString();
                    component[2, 2] = reader[2].ToString();
                    component[3, 2] = reader[3].ToString();
                    component[4, 2] = reader[4].ToString();
                    component[5, 2] = reader[5].ToString();
                    component[6, 2] = reader[5].ToString();
                }
            }

            for (int i = 0; i < 6; i++)
            {
                Image image = new Image();
                Panel box = new Panel();
                Label label = new Label();
                Label name = new Label();
                Button swap = new Button();
                image.ImageUrl = getURL(component[i, 1], component[i, 2]);
                image.Height = new Unit(100);
                image.Width = new Unit(130);
                label.Text = component[i, 0];
                name.Text = getName(component[i, 1], component[i, 2]);
                swap.OnClientClick = "swapComponent('" + component[i, 1] + "', '" + systemID + "')";
                swap.Text = "Swap";
                swap.CssClass = "swapButton";
                box.Attributes["class"] = "itemDiv";
                box.Attributes["onClick"] = "swapComponent('" + component[i, 1] + "', '" + systemID + "')";
                box.Controls.Add(label);
                box.Controls.Add(swap);
                box.Controls.Add(image);
                box.Controls.Add(name);

                categories.Controls.Add(box);
            }
            con.Close();

            command = new SqlCommand("SELECT count(system) FROM [dbo].[cart] WHERE id = '" + Request.UserHostAddress + "'", con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    numberInCart.Text = reader[0].ToString();
                }
            }
            con.Close();
        }
        public string getURL(string table, string id)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("SELECT url FROM [dbo].[" + table + "] WHERE id = " + id, con);
            try
            {

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
            }catch(Exception e)
            {
                string message = "Server timeout, please try reloading";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }

            return "";
        }

        public string getName(string table, string id)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("SELECT name FROM [dbo].[" + table + "] WHERE id = " + id, con);
            try
            {
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
            }catch(Exception e)
            {
                string message = "Server timeout, please try reloading";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("');");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            return "";
        }
    }
}
