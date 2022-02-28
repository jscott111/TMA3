using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;

namespace Store
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command;
            bool alreadyThere = false;
            
            command = new SqlCommand("SELECT COUNT(system) FROM [dbo].[cart] WHERE system = '" + Request.QueryString["system"] + "' AND id='" + Request.UserHostAddress + "'", con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if(Convert.ToInt32(reader[0]) > 0){
                        alreadyThere = true;
                    }
                }
            }
            con.Close();
            
            if (Request.QueryString["action"] == "add" && !alreadyThere)
            {
                command = new SqlCommand("INSERT INTO [dbo].[cart] (id, system) VALUES ('" + Request.UserHostAddress + "', '" + Request.QueryString["system"] + "')", con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Cart.aspx?action=view");
            }
            if(Request.QueryString["action"] == "delete")
            {
                if (Request.QueryString["user"] != "" && Request.QueryString["user"] != null)
                {
                    command = new SqlCommand("DELETE FROM [dbo].[orderedItems] WHERE orderID = '" + Request.QueryString["orderID"] + "' AND itemID = '" + Request.QueryString["system"] + "'", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();

                    command = new SqlCommand("SELECT COUNT(*) FROM [dbo].[orderedItems] WHERE orderID = '" + Request.QueryString["orderID"] + "'", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToInt32(reader[0]) == 0)
                            {
                                con.Close();
                                deleteOrder(Request.QueryString["orderID"], Request.QueryString["user"]);
                                con.Open();
                            }
                            else
                            {
                                Response.Redirect("Orders.aspx?userID=" + Request.QueryString["user"]);
                            }
                        }
                    }
                    con.Close();

                    Response.Redirect("Cart.aspx?orderID=" + Request.QueryString["orderID"] + "&user=" + Request.QueryString["user"]);
                }
                else
                {
                    command = new SqlCommand("DELETE FROM [dbo].[cart] WHERE id = '" + Request.UserHostAddress + "' AND system = '" + Request.QueryString["system"] + "'", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            if (Request.QueryString["user"] != null && Request.QueryString["user"] != "")
            {
                title.Text = "Order";
                command = new SqlCommand("SELECT [orderedItems].[itemID], [systems].[name], [systems].[price], [systems].[url], [cpu].[speed], [ram].[size], [display].[fps], [hd].[size] FROM[dbo].[orderedItems] INNER JOIN[dbo].[systems] ON[orderedItems].[itemID] = [systems].[id] INNER JOIN[dbo].[orders] ON[orderedItems].[orderID] = [orders].[id] INNER JOIN[dbo].[cpu] ON[cpu].[id] = [systems].[cpu] INNER JOIN[dbo].[hd] ON[hd].[id] = [systems].[hd] INNER JOIN[dbo].[ram] ON[ram].[id] = [systems].[ram] INNER JOIN[dbo].[display] ON[display].[id] = [systems].[display] WHERE[orders].[userid] = '" + Request.QueryString["user"] + "' AND [orders].[id] = '" + Request.QueryString["orderID"] + "'", con);
            }
            else
            {
                command = new SqlCommand("SELECT [cart].[system], [systems].[name], [systems].[price], [systems].[url], [cpu].[speed], [ram].[size], [display].[fps], [hd].[size] FROM[dbo].[systems] INNER JOIN[cpu] ON[systems].[cpu] = [cpu].[id] INNER JOIN[ram] ON[systems].[ram] = [ram].[id] INNER JOIN[display] ON[systems].[display] = [display].[id] INNER JOIN[hd] ON[hd].[id] = [systems].[hd] INNER JOIN[cart] ON [cart].[system] = [systems].[id] WHERE [cart].[id] = '" + Request.UserHostAddress + "'", con);
            }

            SqlConnection priceCon = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand priceCommand;
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    double total = 0;
                    Image picture = new Image();
                    Panel panel = new Panel();
                    Label itemName = new Label();
                    Label itemPrice = new Label();
                    Label speed = new Label();
                    Label size = new Label();
                    Label fps = new Label();
                    Panel div = new Panel();
                    Panel priceDiv = new Panel();
                    Panel item = new Panel();
                    Label name = new Label();
                    Label storage = new Label();
                    Button deleteButton = new Button();

                    itemName.Text = reader[1].ToString();
                    itemName.Attributes["class"] = "itemName";
                    div.Controls.Add(itemName);
                    div.Attributes["class"] = "listItemTitle";
                    speed.Text = "Speed: " + reader[4].ToString() + " GHz";
                    size.Text = "Size: " + reader[5].ToString() + " GB";
                    fps.Text = "FPS: " + reader[6].ToString() + "Hz";
                    storage.Text = "Storage: " + reader[7].ToString() + " TB";
                    deleteButton.Text = "Delete";
                    if(Request.QueryString["action"] == "view"){
                        deleteButton.OnClientClick = "deleteCartItem('" + reader[0].ToString() + "', '', '')";
                    }else{
                        deleteButton.OnClientClick = "deleteCartItem('" + reader[0].ToString() + "', '" + Request.QueryString["user"] + "', '" + Request.QueryString["orderID"] + "')";
                    }
                    deleteButton.Attributes["class"] = "swapButton";
                    deleteButton.Attributes.Add("style", "width: 80px;");
                    div.Controls.Add(speed);
                    div.Controls.Add(size);
                    div.Controls.Add(fps);
                    div.Controls.Add(storage);
                    div.Controls.Add(deleteButton);

                    picture.ImageUrl = reader[3].ToString();
                    picture.Height = new Unit(120);
                    picture.Width = new Unit(170);
                    picture.Attributes["class"] = "itemImage";

                    priceCommand = new SqlCommand("SELECT [cpu].[price], [motherboard].[price], [display].[price], [os].[price], [ram].[price], [soundcard].[price], [hd].[price] FROM[dbo].[systems] INNER JOIN[cpu] ON[systems].[cpu] = [cpu].[id] INNER JOIN[motherboard] ON[systems].[motherboard] = [motherboard].[id] INNER JOIN[display] ON[systems].[display] = [display].[id] INNER JOIN[dbo].[hd] ON[hd].[id] = [systems].[hd] INNER JOIN[os] ON[systems].[os] = [os].[id] INNER JOIN[ram] ON[systems].[ram] = [ram].[id] INNER JOIN[soundcard] ON[systems].[soundcard] = [soundcard].[id] WHERE[systems].[id] = " + reader[0].ToString(), priceCon);
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
                            total += Convert.ToDouble(priceReader[6].ToString());
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

                    contents.Controls.Add(panel);
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
                    double total = 0;
                    float price;
                    Label discountPrice = new Label();
                    Label itemPrice = new Label();

                    priceCommand = new SqlCommand("SELECT [cpu].[price], [motherboard].[price], [display].[price], [os].[price], [ram].[price], [soundcard].[price], [hd].[price] FROM[dbo].[systems] INNER JOIN[dbo].[hd] ON[hd].[id] = [systems].[hd] INNER JOIN[cpu] ON[systems].[cpu] = [cpu].[id] INNER JOIN[motherboard] ON[systems].[motherboard] = [motherboard].[id] INNER JOIN[display] ON[systems].[display] = [display].[id] INNER JOIN[os] ON[systems].[os] = [os].[id] INNER JOIN[ram] ON[systems].[ram] = [ram].[id] INNER JOIN[soundcard] ON[systems].[soundcard] = [soundcard].[id] WHERE[systems].[id] = " + reader[3].ToString(), priceCon);
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
                            total += Convert.ToDouble(priceReader[6].ToString());
                        }
                    }
                    priceCon.Close();
                    price = (float)((float)total / (1 + Convert.ToDouble(reader[4]) / 100));
                    discountPrice.Text = Convert.ToDecimal(price.ToString()).ToString("C2");
                    discountPrice.Attributes.Add("style", "color: red;");
                    itemPrice.Text = Convert.ToDecimal(total.ToString()).ToString("C2");
                    itemPrice.Attributes.Add("style", "text-decoration: line-through;");
                    discountPrice.Attributes["class"] = "price";
                    
                    updatePriceDB(reader[3].ToString(), total);

                    try
                    {
                        if (Page.FindControl(reader[3].ToString() + "priceDiv") != null)
                        {
                            Page.FindControl(reader[3].ToString() + "priceDiv").Controls.Remove(Page.FindControl(reader[3].ToString() + "price"));
                            Page.FindControl(reader[3].ToString() + "priceDiv").Controls.Add(discountPrice);
                            Page.FindControl(reader[3].ToString() + "priceDiv").Controls.Add(itemPrice);
                        }
                        total = 0;
                    }
                    catch (Exception){

                    }
                    
                }
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

        public void deleteOrder(string orderID, string userID)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[orders] WHERE id = '" + orderID + "'", con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            Response.Redirect("Orders.aspx?userID=" + userID);
        }
        
        public void updatePriceDB(string itemID, double total)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("UPDATE [dbo].[systems] SET price=" + ((float) total) + " WHERE id = '" + itemID + "'", con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
