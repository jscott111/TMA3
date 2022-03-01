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