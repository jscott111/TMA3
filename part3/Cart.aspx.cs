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
            if (Request.QueryString["action"] == "add")
            {
                command = new SqlCommand("INSERT INTO [dbo].[cart] (id, system) VALUES ('" + Request.QueryString["ip"] + "', " + Request.QueryString["system"] + ")", con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            if(Request.QueryString["action"] == "delete")
            {
                title.Text = Request.QueryString["ip"];
            }

            command = new SqlCommand("SELECT system FROM [dbo].[cart] WHERE id = '" + Request.QueryString["ip"] + "'", con);
            con.Open();
            command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    title.Text = reader[0].ToString();
                }
            }
            con.Close();
        }
    }
}
