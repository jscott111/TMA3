using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;

namespace Store
{
    public partial class Orders : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command;
            if (Request.QueryString["action"] == "create" && !Page.IsPostBack) { 
                command = new SqlCommand("INSERT INTO [dbo].[orders] (userid) OUTPUT Inserted.ID VALUES ('" + Request.QueryString["userID"] + "')", con);
                int orderID = 0;

                con.Open();
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderID = Convert.ToInt32(reader[0]);
                    }
                }
                con.Close();

                command = new SqlCommand("SELECT system FROM [dbo].[cart] WHERE id = '" + Request.UserHostAddress + "'", con);
                SqlConnection secondCon = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                SqlCommand insertCommand;

                con.Open();
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        insertCommand = new SqlCommand("INSERT INTO [dbo].[orderedItems] (orderID, itemID) VALUES (" + orderID + ", " + Convert.ToInt32(reader[0]) + ")", secondCon);
                        secondCon.Open();
                        insertCommand.ExecuteNonQuery();
                        secondCon.Close();
                    }
                }
                con.Close();

                command = new SqlCommand("DELETE FROM [dbo].[cart] WHERE id = '" + Request.UserHostAddress + "'", con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

                Response.Redirect("Orders.aspx?userID=" + Request.QueryString["userID"]);
            }

            command = new SqlCommand("SELECT id FROM [dbo].[orders] WHERE userid = '" + Request.QueryString["userID"] + "'", con);

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
                    Panel pricePanel = new Panel();

                    itemName.Text = "Order #" + reader[0].ToString();
                    itemName.Attributes["class"] = "itemName";

                    panel.Attributes["class"] = "listItem";
                    panel.Controls.Add(itemName);
                    panel.ID = reader[0].ToString();
                    panel.Attributes["onClick"] = "viewOrder('" + reader[0].ToString() + "', '" + Request.QueryString["userID"] + "')";
                    panel.Attributes["style"] = "cursor: pointer;";

                    contents.Controls.Add(panel);
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
    }
}
