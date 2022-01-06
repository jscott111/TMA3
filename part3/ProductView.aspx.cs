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
            string id = Request.QueryString["system"];
            Image picture = new Image();
            Panel panel = new Panel();
            Label itemName = new Label();
            Label itemPrice = new Label();
            Label speed = new Label();
            Label size = new Label();
            Label fps = new Label();
            Panel itemInfoDiv = new Panel();
            Panel priceDiv = new Panel();

            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command = new SqlCommand("SELECT [systems].[id], [systems].[name], [systems].[price], [systems].[url], [cpu].[speed], [ram].[size], [display].[fps] FROM [dbo].[systems] INNER JOIN [cpu] ON [systems].[id] = [cpu].[id] INNER JOIN [ram] ON [systems].[id] = [ram].[id] INNER JOIN [display] ON [systems].[id] = [display].[id] WHERE [systems].[id] = " + id, con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    itemName.Text = reader[1].ToString();
                    itemName.Attributes["class"] = "itemName";
                    itemInfoDiv.Controls.Add(itemName);
                    itemInfoDiv.Attributes["class"] = "ProductInfo";
                    speed.Text = "Speed: " + reader[4].ToString() + " GHz";
                    size.Text = "Size: " + reader[5].ToString() + " GB";
                    fps.Text = "FPS: " + reader[6].ToString() + "Hz";
                    itemInfoDiv.Controls.Add(speed);
                    itemInfoDiv.Controls.Add(size);
                    itemInfoDiv.Controls.Add(fps);

                    picture.ImageUrl = reader[3].ToString();
                    picture.Height = new Unit(200);
                    picture.Width = new Unit(270);
                    picture.Attributes["class"] = "itemImage";

                    itemPrice.Text = Convert.ToDecimal(reader[2].ToString()).ToString("C2");
                    itemPrice.ID = reader[0].ToString() + "price";
                    priceDiv.Attributes["class"] = "ProductViewPrice";
                    priceDiv.ID = reader[0].ToString() + "priceDiv";
                    priceDiv.Controls.Add(itemPrice);

                    panel.Attributes["class"] = "productDisplay";
                    panel.Controls.Add(picture);
                    panel.Controls.Add(itemInfoDiv);
                    panel.Controls.Add(priceDiv);
                    panel.ID = reader[0].ToString();

                    product.Controls.Add(panel);
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
                    /*Label discountPrice = new Label();
                    Label itemPrice = (Label)Page.FindControl(reader[3].ToString() + "price");

                    price = (float)((float)Convert.ToDouble(reader[2]) / (1 + Convert.ToDouble(reader[4]) / 100));
                    discountPrice.Text = Convert.ToDecimal(price.ToString()).ToString("C2");
                    discountPrice.Attributes.Add("style", "color: red;");
                    itemPrice.Text = Convert.ToDecimal(reader[2].ToString()).ToString("C2");
                    itemPrice.Attributes.Add("style", "text-decoration: line-through;");
                    discountPrice.Attributes["class"] = "price";

                    Page.FindControl(reader[3].ToString() + "priceDiv").Controls.Add(discountPrice);*/
                }
            }
        }
    }
}
