using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Store
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            title.Text = Request.QueryString["ip"] + ": " + Request.QueryString["system"];
        }
    }
}