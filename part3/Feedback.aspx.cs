using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class Feedback : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=tcp:jscott11.database.windows.net,1433;Initial Catalog=store;Persist Security Info=False;User ID=jscott11;Password=3557321Joh--;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand command;
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

        public void sendEmail(object sender, System.EventArgs e)
        {
            var smtpClient = new SmtpClient("smtp.sendgrid.net")
            {
                Port = 587,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("apikey", "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"),
                EnableSsl = true
            };

            smtpClient.Send("johnascott14@gmail.com", "johnascott14@gmail.com", "Thanks for the feedback", "Test");
        }
    }
}