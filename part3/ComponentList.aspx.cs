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
            motherboard.Visible = false;
            cpu.Visible = false;
            ram.Visible = false;
            display.Visible = false;
            os.Visible = false;
            hd.Visible = false;
            soundcard.Visible = false;
            motherboard1.Visible = false;
            motherboard2.Visible = false;
            motherboard3.Visible = false;
            motherboard4.Visible = false;
            motherboard5.Visible = false;
            motherboard6.Visible = false;
            motherboard7.Visible = false;
            motherboard8.Visible = false;
            motherboard9.Visible = false;
            motherboard10.Visible = false;
            cpu1.Visible = false;
            cpu2.Visible = false;
            cpu3.Visible = false;
            cpu4.Visible = false;
            cpu5.Visible = false;
            cpu6.Visible = false;
            cpu7.Visible = false;
            cpu8.Visible = false;
            cpu9.Visible = false;
            cpu10.Visible = false;
            ram1.Visible = false;
            ram2.Visible = false;
            ram3.Visible = false;
            ram4.Visible = false;
            ram5.Visible = false;
            ram6.Visible = false;
            ram7.Visible = false;
            ram8.Visible = false;
            display1.Visible = false;
            display2.Visible = false;
            display3.Visible = false;
            display4.Visible = false;
            display5.Visible = false;
            display6.Visible = false;
            display7.Visible = false;
            display8.Visible = false;
            os1.Visible = false;
            os2.Visible = false;
            os3.Visible = false;
            os4.Visible = false;
            hd1.Visible = false;
            hd2.Visible = false;
            hd3.Visible = false;
            hd4.Visible = false;
            hd5.Visible = false;
            hd6.Visible = false;
            soundcard1.Visible = false;
            soundcard2.Visible = false;
            soundcard3.Visible = false;
            soundcard4.Visible = false;
            soundcard5.Visible = false;
            soundcard6.Visible = false;
            soundcard7.Visible = false;
            soundcard8.Visible = false;
            soundcard9.Visible = false;
            soundcard10.Visible = false;

            if (Request.QueryString["part"] == "motherboard")
            {
                motherboard.Visible = true;
                if(Request.QueryString["swap"] == "true")
                {
                    motherboard1.OnClientClick = "productView('" + Request.QueryString["system"] + "', '10', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard2.OnClientClick = "productView('" + Request.QueryString["system"] + "', '11', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard3.OnClientClick = "productView('" + Request.QueryString["system"] + "', '12', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard4.OnClientClick = "productView('" + Request.QueryString["system"] + "', '13', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard5.OnClientClick = "productView('" + Request.QueryString["system"] + "', '14', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard6.OnClientClick = "productView('" + Request.QueryString["system"] + "', '15', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard7.OnClientClick = "productView('" + Request.QueryString["system"] + "', '16', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard8.OnClientClick = "productView('" + Request.QueryString["system"] + "', '17', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard9.OnClientClick = "productView('" + Request.QueryString["system"] + "', '18', '" + Request.QueryString["part"] + "', 'true');";
                    motherboard10.OnClientClick = "productView('" + Request.QueryString["system"] + "', '19', '" + Request.QueryString["part"] + "', 'true');";

                    motherboard1.Visible = true;
                    motherboard2.Visible = true;
                    motherboard3.Visible = true;
                    motherboard4.Visible = true;
                    motherboard5.Visible = true;
                    motherboard6.Visible = true;
                    motherboard7.Visible = true;
                    motherboard8.Visible = true;
                    motherboard9.Visible = true;
                    motherboard10.Visible = true;
                }
            }
            else if (Request.QueryString["part"] == "cpu")
            {
                cpu.Visible = true;
                if (Request.QueryString["swap"] == "true")
                {
                    cpu1.OnClientClick = "productView('" + Request.QueryString["system"] + "', '1', '" + Request.QueryString["part"] + "', 'true');";
                    cpu2.OnClientClick = "productView('" + Request.QueryString["system"] + "', '2', '" + Request.QueryString["part"] + "', 'true');";
                    cpu3.OnClientClick = "productView('" + Request.QueryString["system"] + "', '3', '" + Request.QueryString["part"] + "', 'true');";
                    cpu4.OnClientClick = "productView('" + Request.QueryString["system"] + "', '4', '" + Request.QueryString["part"] + "', 'true');";
                    cpu5.OnClientClick = "productView('" + Request.QueryString["system"] + "', '5', '" + Request.QueryString["part"] + "', 'true');";
                    cpu6.OnClientClick = "productView('" + Request.QueryString["system"] + "', '6', '" + Request.QueryString["part"] + "', 'true');";
                    cpu7.OnClientClick = "productView('" + Request.QueryString["system"] + "', '7', '" + Request.QueryString["part"] + "', 'true');";
                    cpu8.OnClientClick = "productView('" + Request.QueryString["system"] + "', '8', '" + Request.QueryString["part"] + "', 'true');";
                    cpu9.OnClientClick = "productView('" + Request.QueryString["system"] + "', '9', '" + Request.QueryString["part"] + "', 'true');";
                    cpu10.OnClientClick = "productView('" + Request.QueryString["system"] + "', '10', '" + Request.QueryString["part"] + "', 'true');";

                    cpu1.Visible = true;
                    cpu2.Visible = true;
                    cpu3.Visible = true;
                    cpu4.Visible = true;
                    cpu5.Visible = true;
                    cpu6.Visible = true;
                    cpu7.Visible = true;
                    cpu8.Visible = true;
                    cpu9.Visible = true;
                    cpu10.Visible = true;
                }
            }
            else if (Request.QueryString["part"] == "ram")
            {
                ram.Visible = true;
                if (Request.QueryString["swap"] == "true")
                {
                    ram1.OnClientClick = "productView('" + Request.QueryString["system"] + "', '1', '" + Request.QueryString["part"] + "', 'true');";
                    ram2.OnClientClick = "productView('" + Request.QueryString["system"] + "', '2', '" + Request.QueryString["part"] + "', 'true');";
                    ram3.OnClientClick = "productView('" + Request.QueryString["system"] + "', '3', '" + Request.QueryString["part"] + "', 'true');";
                    ram4.OnClientClick = "productView('" + Request.QueryString["system"] + "', '4', '" + Request.QueryString["part"] + "', 'true');";
                    ram5.OnClientClick = "productView('" + Request.QueryString["system"] + "', '5', '" + Request.QueryString["part"] + "', 'true');";
                    ram6.OnClientClick = "productView('" + Request.QueryString["system"] + "', '6', '" + Request.QueryString["part"] + "', 'true');";
                    ram7.OnClientClick = "productView('" + Request.QueryString["system"] + "', '7', '" + Request.QueryString["part"] + "', 'true');";
                    ram8.OnClientClick = "productView('" + Request.QueryString["system"] + "', '8', '" + Request.QueryString["part"] + "', 'true');";

                    ram1.Visible = true;
                    ram2.Visible = true;
                    ram3.Visible = true;
                    ram4.Visible = true;
                    ram5.Visible = true;
                    ram6.Visible = true;
                    ram7.Visible = true;
                    ram8.Visible = true;
                }
            }
            else if (Request.QueryString["part"] == "display")
            {
                display.Visible = true;
                if (Request.QueryString["swap"] == "true")
                {
                    display1.OnClientClick = "productView('" + Request.QueryString["system"] + "', '1', '" + Request.QueryString["part"] + "', 'true');";
                    display2.OnClientClick = "productView('" + Request.QueryString["system"] + "', '2', '" + Request.QueryString["part"] + "', 'true');";
                    display3.OnClientClick = "productView('" + Request.QueryString["system"] + "', '3', '" + Request.QueryString["part"] + "', 'true');";
                    display4.OnClientClick = "productView('" + Request.QueryString["system"] + "', '4', '" + Request.QueryString["part"] + "', 'true');";
                    display5.OnClientClick = "productView('" + Request.QueryString["system"] + "', '5', '" + Request.QueryString["part"] + "', 'true');";
                    display6.OnClientClick = "productView('" + Request.QueryString["system"] + "', '6', '" + Request.QueryString["part"] + "', 'true');";
                    display7.OnClientClick = "productView('" + Request.QueryString["system"] + "', '7', '" + Request.QueryString["part"] + "', 'true');";
                    display8.OnClientClick = "productView('" + Request.QueryString["system"] + "', '8', '" + Request.QueryString["part"] + "', 'true');";

                    display1.Visible = true;
                    display2.Visible = true;
                    display3.Visible = true;
                    display4.Visible = true;
                    display5.Visible = true;
                    display6.Visible = true;
                    display7.Visible = true;
                    display8.Visible = true;
                }
            }
            else if (Request.QueryString["part"] == "os")
            {
                os.Visible = true;
                if (Request.QueryString["swap"] == "true")
                {
                    os1.OnClientClick = "productView('" + Request.QueryString["system"] + "', '1', '" + Request.QueryString["part"] + "', 'true');";
                    os2.OnClientClick = "productView('" + Request.QueryString["system"] + "', '2', '" + Request.QueryString["part"] + "', 'true');";
                    os3.OnClientClick = "productView('" + Request.QueryString["system"] + "', '3', '" + Request.QueryString["part"] + "', 'true');";
                    os4.OnClientClick = "productView('" + Request.QueryString["system"] + "', '4', '" + Request.QueryString["part"] + "', 'true');";

                    os1.Visible = true;
                    os2.Visible = true;
                    os3.Visible = true;
                    os4.Visible = true;
                }
            }
            else if (Request.QueryString["part"] == "hd")
            {
                hd.Visible = true;
                if (Request.QueryString["swap"] == "true")
                {
                    hd1.OnClientClick = "productView('" + Request.QueryString["system"] + "', '1', '" + Request.QueryString["part"] + "', 'true');";
                    hd2.OnClientClick = "productView('" + Request.QueryString["system"] + "', '2', '" + Request.QueryString["part"] + "', 'true');";
                    hd3.OnClientClick = "productView('" + Request.QueryString["system"] + "', '3', '" + Request.QueryString["part"] + "', 'true');";
                    hd4.OnClientClick = "productView('" + Request.QueryString["system"] + "', '4', '" + Request.QueryString["part"] + "', 'true');";
                    hd5.OnClientClick = "productView('" + Request.QueryString["system"] + "', '5', '" + Request.QueryString["part"] + "', 'true');";
                    hd6.OnClientClick = "productView('" + Request.QueryString["system"] + "', '6', '" + Request.QueryString["part"] + "', 'true');";

                    hd1.Visible = true;
                    hd2.Visible = true;
                    hd3.Visible = true;
                    hd4.Visible = true;
                    hd5.Visible = true;
                    hd6.Visible = true;
                }
            }
            else if (Request.QueryString["part"] == "soundcard")
            {
                soundcard.Visible = true;
                if (Request.QueryString["swap"] == "true")
                {
                    soundcard1.OnClientClick = "productView('" + Request.QueryString["system"] + "', '10', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard2.OnClientClick = "productView('" + Request.QueryString["system"] + "', '11', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard3.OnClientClick = "productView('" + Request.QueryString["system"] + "', '12', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard4.OnClientClick = "productView('" + Request.QueryString["system"] + "', '13', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard5.OnClientClick = "productView('" + Request.QueryString["system"] + "', '14', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard6.OnClientClick = "productView('" + Request.QueryString["system"] + "', '15', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard7.OnClientClick = "productView('" + Request.QueryString["system"] + "', '16', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard8.OnClientClick = "productView('" + Request.QueryString["system"] + "', '17', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard9.OnClientClick = "productView('" + Request.QueryString["system"] + "', '18', '" + Request.QueryString["part"] + "', 'true');";
                    soundcard10.OnClientClick = "productView('" + Request.QueryString["system"] + "', '19', '" + Request.QueryString["part"] + "', 'true');";

                    soundcard1.Visible = true;
                    soundcard2.Visible = true;
                    soundcard3.Visible = true;
                    soundcard4.Visible = true;
                    soundcard5.Visible = true;
                    soundcard6.Visible = true;
                    soundcard7.Visible = true;
                    soundcard8.Visible = true;
                    soundcard9.Visible = true;
                    soundcard10.Visible = true;
                }
            }
        }
    }
}