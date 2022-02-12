using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;

namespace Store
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            contents.Attributes["class"] = "loginPanel";
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command;
            bool access = false;
            bool usernameExists = false;
            if (Request.Form["button"] == "Log In"){
                command = new SqlCommand("SELECT COUNT(username) FROM [dbo].[users] WHERE username='" + Request.Form["username"] + "' AND pw='" + Request.Form["password"] + "'", con);
                con.Open();
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if(reader[0].ToString() == "1")
                        {
                            access = true;
                        }
                        else
                        {
                            incorrect.Text = "Incorrect Username or password";
                        }
                    }
                }
                con.Close();
            }
            else if (Request.Form["button"] == "Sign Up"){
                command = new SqlCommand("SELECT COUNT(username) FROM [dbo].[users] WHERE username='" + Request.Form["username"] + "'", con);
                con.Open();
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0].ToString() != "0")
                        {
                            usernameExists = true;
                            incorrect.Text = "Username already exists";
                        }
                    }
                }
                con.Close();

                if(usernameExists == false)
                {
                    command = new SqlCommand("INSERT INTO [dbo].[users] (username, pw) VALUES ('" + Request.Form["username"] + "', '" + Request.Form["password"] + "')", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    access = true;
                }
            }

            if(access == true)
            {
                Response.Redirect("Orders.aspx");
            }
            

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
