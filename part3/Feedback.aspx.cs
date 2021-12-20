using System;
using System.Collections.Generic;
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

        }

        public void sendEmail(object sender, System.EventArgs e)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("john5sco717@gmail.com", "Joh98Sco!!"),
                EnableSsl = true,
            };

            smtpClient.Send("john5sco717@gmail.com", "johnascott14@gmail.com", "Thanks for the feedback", "Test");
        }
    }
}