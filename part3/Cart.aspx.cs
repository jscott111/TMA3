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
        public string[,] systems = new string[7, 11]
        {
            {"1", "Falcon", "15", "3", "1", "6", "1", "8", "2345.95", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-190-01.jpg", "3"},
            {"2", "Hawk", "17", "7", "1", "1", "1", "10", "1812.93", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-211-01.jpg", "1"},
            {"3", "Eagle", "14", "1", "1", "7", "1", "6", "1745.93", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-198-01.jpg", "5"},
            {"4", "Owl", "17", "1", "3", "7", "2", "5", "1489.94", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-201-01.jpg", "6"},
            {"5", "Penguin", "13", "3", "4", "6", "3", "1", "1353.95", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-206-01.jpg", "4"},
            {"6", "Stork", "11", "1", "5", "8", "1", "5", "1225.09", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-219-01.jpg", "2"},
            {"7", "Flamingo", "16", "2", "1", "7", "4", "4", "1828.95", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-195-01.jpg", "4"}
        };
        public string[,] cpu = new string[10, 5]
        {
            {"1", "AMD Ryzen 9 5950X 16-Core", "3.4", "949.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-663-V01.jpg"},
            {"2", "Intel Core i9-11900K", "3.5", "619.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-231-V04.jpg"},
            {"3", "AMD Ryzen 9 5900X", "3.7", "659.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-664-V01.jpg"},
            {"4", "Intel Core i7-11700K", "3.6", "429.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-233-V01.jpg"},
            {"5", "AMD Ryzen 7 5800X", "3.8", "499.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-665-V01.jpg"},
            {"6", "Intel Core i5-11600K", "3.9", "319.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-235-V01.jpg"},
            {"7", "AMD Ryzen 5 5600X", "3.7", "374.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-666-V01.jpg"},
            {"8", "Intel Core i9-11900KF", "3.5", "599.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-259-V01.jpg"},
            {"9", "AMD Ryzen 5 3rd Gen - RYZEN 5 3600", "3.6", "289.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-569-V01.jpg"},
            {"10", "Intel Core i7 10th Gen - Core i7-10700K", "3.8", "419.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-123-V01.jpg"}
        };
        public string[,] display = new string[10, 5]
        {
            {"1", "AMD Ryzen 9 5950X 16-Core", "3.4", "949.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-663-V01.jpg"},
            {"2", "Intel Core i9-11900K", "3.5", "619.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-231-V04.jpg"},
            {"3", "AMD Ryzen 9 5900X", "3.7", "659.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-664-V01.jpg"},
            {"4", "Intel Core i7-11700K", "3.6", "429.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-233-V01.jpg"},
            {"5", "AMD Ryzen 7 5800X", "3.8", "499.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-665-V01.jpg"},
            {"6", "Intel Core i5-11600K", "3.9", "319.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-235-V01.jpg"},
            {"7", "AMD Ryzen 5 5600X", "3.7", "374.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-666-V01.jpg"},
            {"8", "Intel Core i9-11900KF", "3.5", "599.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-259-V01.jpg"},
            {"9", "AMD Ryzen 5 3rd Gen - RYZEN 5 3600", "3.6", "289.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-569-V01.jpg"},
            {"10", "Intel Core i7 10th Gen - Core i7-10700K", "3.8", "419.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-123-V01.jpg"}
        };
        public string[,] hd = new string[6, 5]
        {
            {"1", "Seagate BarraCuda ST2000DM008 2TB", "2", "54.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-184-773-V01.jpg"},
            {"2", "Seagate BarraCuda ST4000DM004 4TB", "4", "89.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-179-299-V01.jpg"},
            {"3", "WD Red 4TB NAS Internal Hard Drive", "4", "89.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-234-409-V01.jpg"},
            {"4", "WD Blue 4TB Desktop Hard Disk Drive", "4", "89.99", "https://c1.neweggimages.com/ProductImageCompressAll300/1Z4-0002-01CG2-01.jpg"},
            {"5", "Seagate IronWolf 4TB NAS Hard Drive", "4", "99.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-179-005-V01.jpg"},
            {"6", "Seagate IronWolf 8TB NAS Hard Drive", "8", "254.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-184-796-V06.jpg"}
        };
        public string[,] motherboard = new string[10, 4]
        {
            {"10", "ASUS TUF Gaming X570-PRO", "269.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-119-353-V04.jpg"},
            {"11", "ASUS ROG STRIX B550-F GAMING", "219.15", "https://c1.neweggimages.com/ProductImageCompressAll300/13-119-311-V03.jpg"},
            {"12", "MSI B560M PRO-VDH WIFI LGA 1200", "149.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-397-V01.jpg"},
            {"13", "MSI MPG B550 GAMING PLUS AM4", "179.57", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-325-V01.jpg"},
            {"14", "ASUS PRIME Z590-V LGA 1200 ATX", "169.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-119-418-V01.jpg"},
            {"15", "GIGABYTE Z590 AORUS ULTRA LGA 1200 ATX ", "329.90", "https://c1.neweggimages.com/ProductImageCompressAll300/13-145-270-01.jpg"},
            {"16", "ASUS ROG STRIX Z590-I GAMING", "369.80", "https://c1.neweggimages.com/ProductImageCompressAll300/13-119-377-V80.jpg"},
            {"17", "MSI MAG B560 TOMAHAWK WIFI LGA 1200", "219.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-393-V01.jpg"},
            {"18", "MSI MAG B560M MORTAR", "199.32", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-395-07.jpg"},
            {"19", "MSI MPG Z590M GAMING EDGE", "279.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-458-V08.jpg"}
        };
        public string[,] os = new string[4, 4]
        {
            {"1", "Microsoft Windows 10 Home, 64-bit", "99.99", "https://c1.neweggimages.com/ProductImageCompressAll300/32-416-892-11.jpg"},
            {"2", "Microsoft Windows 10 Pro 64-bit", "169.99", "https://c1.neweggimages.com/ProductImageCompressAll300/32-588-491-08.jpg"},
            {"3", "Microsoft Windows 11 Pro 64-bit", "189.99", "https://c1.neweggimages.com/ProductImageCompressAll300/32-350-882-V01.jpg"},
            {"4", "Microsoft Windows 11 Home 64-bit", "149.99", "https://c1.neweggimages.com/ProductImageCompressAll300/32-350-881-V01.jpg"}
        };
        public string[,] ram = new string[8, 5]
        {
            {"1", "G.SKILL Ripjaws V Series", "16", "93.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-232-880-V01.jpg"},
            {"2", "CORSAIR Vengeance LPX", "16", "79.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-236-540-S01.jpg"},
            {"3", "CORSAIR Vengeance RGB Pro", "32", "233.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-236-408-01.jpg"},
            {"4", "Kingston FURY Impact 16GB", "16", "84.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-242-624-V02.jpg"},
            {"5", "G.SKILL Ripjaws V Series 16GB", "16", "86.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-232-731-Z01.jpg"},
            {"6", "G.SKILL Trident Z Neo Series", "64", "410.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-232-999-V01.jpg"},
            {"7", "G.SKILL Ripjaws V Series", "32", "132.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-232-091-04.jpg"},
            {"8", "Team T-Force Delta RGB", "32", "149.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-331-635-V01.jpg"}
        };
        public string[,] soundcard = new string[10, 4]
        {
            {"1", "Creative Sound Blaster Z SE 5.1 Channels", "130.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-110-V01.jpg"},
            {"2", "Creative Sound Blaster Audigy RX 7.1", "79.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-063-07.jpg"},
            {"3", "Creative Sound Blaster AE-9 Sound Card", "429.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-105-V16.jpg"},
            {"4", "Creative Sound Blaster X-Fi Xtreme Audio 7.1 Channels", "79.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-026-01.jpg"},
            {"5", "Creative Sound Blaster Audigy FX 5.1 PCIe", "59.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-062-05.jpg"},
            {"6", "ASUS Xonar AE 7.1 Channels PCI Express Interface Sound Card", "101.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-132-084-V02.jpg"},
            {"7", "Creative X-Fi SB0670", "79.99", "https://c1.neweggimages.com/ProductImageCompressAll300/A4RE_132060100264906998K8rT9kp1UI.jpg"},
            {"8", "HT OMEGA Claro Halo", "315", "https://c1.neweggimages.com/ProductImageCompressAll300/29-271-004-03.jpg"},
            {"9", "ASUS Xonar AE 7.1 Channels PCI Express x1 Interface Sound Card", "88.44", "https://c1.neweggimages.com/ProductImageCompressAll300/29-132-085-V06.jpg"},
            {"10", "ASUS Xonar SE 5.1 Channel 192 kHz", "104.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-132-086-V01.jpg"}
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command;
            if (Request.QueryString["action"] == "add")
            {
                command = new SqlCommand("INSERT INTO [dbo].[cart] (id, system) VALUES ('0.0.0.0', '" + Request.QueryString["system"] + "')", con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Cart?action=view");
            }
            if(Request.QueryString["action"] == "delete")
            {
                if (Request.QueryString["system"] != "")
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
                                Response.Redirect("Orders?userID=" + Request.QueryString["user"]);
                            }
                        }
                    }
                    con.Close();

                    Response.Redirect("Cart?orderID=" + Request.QueryString["orderID"] + "&user=" + Request.QueryString["user"]);
                }
                else
                {
                    command = new SqlCommand("DELETE FROM [dbo].[cart] WHERE id = '0.0.0.0' AND system = '" + Request.QueryString["system"] + "'", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            if (Request.QueryString["orderID"] != null)
            {
                title.Text = "Order";
                command = new SqlCommand("SELECT [orderedItems].[itemID], [systems].[name], [systems].[price], [systems].[url], [cpu].[speed], [ram].[size], [display].[fps] FROM[dbo].[orderedItems] INNER JOIN[dbo].[systems] ON[orderedItems].[itemID] = [systems].[id] INNER JOIN[dbo].[orders] ON[orderedItems].[orderID] = [orders].[id] INNER JOIN[dbo].[cpu] ON[cpu].[id] = [systems].[cpu] INNER JOIN[dbo].[ram] ON[ram].[id] = [systems].[ram] INNER JOIN[dbo].[display] ON[display].[id] = [systems].[display] WHERE[orders].[userid] = '" + Request.QueryString["user"] + "' AND [orders].[id] = '" + Request.QueryString["orderID"] + "'", con);
            }
            else
            {
                command = new SqlCommand("SELECT [cart].[system], [systems].[name], [systems].[price], [systems].[url], [cpu].[speed], [ram].[size], [display].[fps] FROM[dbo].[cart] INNER JOIN[cpu] ON[cart].[system] = [cpu].[id] INNER JOIN[ram] ON[cart].[system] = [ram].[id] INNER JOIN[display] ON[cart].[system] = [display].[id] INNER JOIN[systems] ON [cart].[system] = [systems].[id] WHERE [cart].[id] = '0.0.0.0'", con);
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
                    Button deleteButton = new Button();

                    itemName.Text = reader[1].ToString();
                    itemName.Attributes["class"] = "itemName";
                    div.Controls.Add(itemName);
                    div.Attributes["class"] = "listItemTitle";
                    speed.Text = "Speed: " + reader[4].ToString() + " GHz";
                    size.Text = "Size: " + reader[5].ToString() + " GB";
                    fps.Text = "FPS: " + reader[6].ToString() + "Hz";
                    deleteButton.Text = "Delete";
                    deleteButton.OnClientClick = "deleteCartItem('" + reader[0].ToString() + "', '" + Request.QueryString["user"] + "', '" + Request.QueryString["orderID"] + "')";
                    deleteButton.Attributes["class"] = "swapButton";
                    deleteButton.Attributes.Add("style", "width: 80px;");
                    div.Controls.Add(speed);
                    div.Controls.Add(size);
                    div.Controls.Add(fps);
                    div.Controls.Add(deleteButton);

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
                    price = (float)((float)total / (1 + Convert.ToDouble(reader[4]) / 100));
                    discountPrice.Text = Convert.ToDecimal(price.ToString()).ToString("C2");
                    discountPrice.Attributes.Add("style", "color: red;");
                    itemPrice.Text = Convert.ToDecimal(total.ToString()).ToString("C2");
                    itemPrice.Attributes.Add("style", "text-decoration: line-through;");
                    discountPrice.Attributes["class"] = "price";

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
        }

        public void deleteOrder(string orderID, string userID)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("DELETE FROM [dbo].[orders] WHERE id = '" + orderID + "'", con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

            Response.Redirect("Orders?userID=" + userID);
        }
    }
}