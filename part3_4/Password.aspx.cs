using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;

namespace Store
{
    public partial class Password : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command;
            bool wrongNumber = true;
            bool access = false;

            if (Request.Form["button"] == "Reset"){
                if(Request.Form["username"] != "" && Request.Form["firstPassword"] != "" && Request.Form["secondPassword"] != "" && Request.Form["phoneNumber"] != "" && Request.Form["username"] != null && Request.Form["firstPassword"] != null && Request.Form["secondPassword"] != null && Request.Form["phoneNumber"] != null){
                    command = new SqlCommand("SELECT COUNT(username) FROM [dbo].[users] WHERE username='" + Request.Form["username"] + "' AND number='" + Request.Form["phoneNumber"] + "'", con);
                    con.Open();
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToInt32(reader[0]) > 0)
                            {
                                wrongNumber = false;
                            }
                            else
                            {
                                incorrect.Text = "Wrong username or phone number";
                            }
                        }
                    }
                    con.Close();

                    bool match = String.Compare(Request.Form["firstPassword"], Request.Form["secondPassword"], false) != 0;

                    if (match)
                    {
                        incorrect.Text = "Passwords don't match";
                    }

                    if (!wrongNumber && !match)
                    {
                        command = new SqlCommand("UPDATE [dbo].[users] SET pw='" + Request.Form["firstPassword"] + "' WHERE username='" + Request.Form["username"] + "'", con);
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                        access = true;
                    }
                }else{
                    incorrect.Text = "Invalid Entry";
                }
            }


            if(access == true)
            {
                Response.Redirect("Orders.aspx?userID=" + Request.Form["username"]);
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
