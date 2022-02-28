using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Store
{
    public partial class ComponentList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int index = 0;
            string query = "";
            string extraDetail = "";
            string[,] component = new string[7, 5] { 
                { "Motherboards", "motherboard", "SELECT id, name, price, url FROM [dbo].[motherboard]", "", ""}, 
                { "CPUs", "cpu", "SELECT id, name, price, url, speed FROM [dbo].[cpu]", "Speed", "GHz"}, 
                { "RAM", "ram", "SELECT id, name, price, url, size FROM [dbo].[ram]", "Size", "GB"}, 
                { "Displays", "display", "SELECT id, name, price, url, fps FROM [dbo].[display]", "FPS", "Hz"}, 
                { "Operating Systems", "os", "SELECT id, name, price, url FROM [dbo].[os]", "", ""}, 
                { "Soundcards", "soundcard", "SELECT id, name, price, url FROM [dbo].[soundcard]", "", ""},
                { "Hard Drives", "hd", "SELECT id, name, price, url, size FROM [dbo].[hd]", "Storage", "TB"} 
            };

            for (int i = 0; i < 7; i++)
            {
                if(Request.QueryString["part"] == component[i, 1])
                {
                    title.Text = component[i, 0];
                    query = component[i, 2];
                    extraDetail = component[i, 3];
                    index = i;
                }
            }


            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand(query, con);
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
                    Label extra = new Label();
                    Panel div = new Panel();
                    Panel pricePanel = new Panel();

                    itemName.Text = reader[1].ToString();
                    itemName.Attributes["class"] = "itemName";
                    div.Controls.Add(itemName);
                    if (extraDetail != "")
                    {
                        extra.Text = component[index, 3] + ": " + reader[4].ToString() + " " + component[index, 4];
                        div.Controls.Add(extra);
                    }
                    div.Attributes["class"] = "listItemTitle";

                    picture.ImageUrl = reader[3].ToString();
                    picture.Height = new Unit(120);
                    picture.Width = new Unit(170);
                    picture.Attributes["class"] = "itemImage";

                    itemPrice.Text = Convert.ToDecimal(reader[2].ToString()).ToString("C2");
                    itemPrice.ID = reader[0].ToString() + "price";
                    pricePanel.Controls.Add(itemPrice);
                    pricePanel.Attributes["class"] = "price";

                    panel.Attributes["class"] = "listItem";
                    panel.Controls.Add(picture);
                    panel.Controls.Add(div);
                    panel.ID = reader[0].ToString();

                    if (Request.QueryString["swap"] == "true")
                    {
                        Button swap = new Button();
                        swap.Text = "Swap";
                        swap.CssClass = "swapButton";
                        swap.OnClientClick = "productView('" + Request.QueryString["system"] + "', '" + reader[0].ToString() + "', '" + component[index, 1] + "', 'true')";

                        pricePanel.Controls.Add(swap);
                    }

                    panel.Controls.Add(pricePanel);

                    list.Controls.Add(panel);
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
                    numberInCart.Text += reader[0].ToString();
                }
            }
            con.Close();
        }
    }
}
