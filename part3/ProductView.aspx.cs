using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Store
{
    public partial class ProductView : Page
    {
        public string[,] systems = new string[7, 11]
        {
            {"1", "Falcon", "15", "3", "1", "6", "1", "8", "2345.95", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-190-01.jpg", "3"},
            {"2", "Hawk", "17", "7", "1", "1", "1", "10", "1812.93", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-211-01.jpg", "1"},
            {"3", "Eagle", "14", "1", "1", "7", "1", "6", "1745.93", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-198-01.jpg", "5"},
            {"4", "Owl", "17", "1", "3", "7", "2", "5", "1489.94", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-201-01.jpg", "6"},
            {"5", "Penguin", "13", "3", "4", "6", "3", "1", "1353.95", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-206-01.jpg", "4"},
            {"6", "Stork", "11", "1", "5", "8", "1", "5", "1225.09", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-219-01.jpg", "2"},
            {"7", "Flamingo", "16", "2", "1", "7", "4", "4", "1828.95", "https://c1.neweggimages.com/ProductImageCompressAll300/83-360-195-01.jpg", "4"}
        };
        public string[,] cpu = new string[10, 5]
        {
            {"1", "AMD Ryzen 9 5950X 16-Core", "3.4", "949.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-663-V01.jpg"},
            {"2", "Intel Core i9-11900K", "3.5", "619.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-231-V04.jpg"},
            {"3", "AMD Ryzen 9 5900X", "3.7", "659.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-664-V01.jpg"},
            {"4", "Intel Core i7-11700K", "3.6", "429.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-233-V01.jpg"},
            {"5", "AMD Ryzen 7 5800X", "3.8", "499.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-665-V01.jpg"},
            {"6", "Intel Core i5-11600K", "3.9", "319.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-235-V01.jpg"},
            {"7", "AMD Ryzen 5 5600X", "3.7", "374.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-666-V01.jpg"},
            {"8", "Intel Core i9-11900KF", "3.5", "599.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-259-V01.jpg"},
            {"9", "AMD Ryzen 5 3rd Gen - RYZEN 5 3600", "3.6", "289.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-569-V01.jpg"},
            {"10", "Intel Core i7 10th Gen - Core i7-10700K", "3.8", "419.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-123-V01.jpg"}
        };
        public string[,] display = new string[10, 5]
        {
            {"1", "AMD Ryzen 9 5950X 16-Core", "3.4", "949.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-663-V01.jpg"},
            {"2", "Intel Core i9-11900K", "3.5", "619.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-231-V04.jpg"},
            {"3", "AMD Ryzen 9 5900X", "3.7", "659.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-664-V01.jpg"},
            {"4", "Intel Core i7-11700K", "3.6", "429.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-233-V01.jpg"},
            {"5", "AMD Ryzen 7 5800X", "3.8", "499.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-665-V01.jpg"},
            {"6", "Intel Core i5-11600K", "3.9", "319.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-235-V01.jpg"},
            {"7", "AMD Ryzen 5 5600X", "3.7", "374.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-666-V01.jpg"},
            {"8", "Intel Core i9-11900KF", "3.5", "599.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-259-V01.jpg"},
            {"9", "AMD Ryzen 5 3rd Gen - RYZEN 5 3600", "3.6", "289.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-113-569-V01.jpg"},
            {"10", "Intel Core i7 10th Gen - Core i7-10700K", "3.8", "419.99", "https://c1.neweggimages.com/ProductImageCompressAll300/19-118-123-V01.jpg"}
        };
        public string[,] hd = new string[6, 5]
        {
            {"1", "Seagate BarraCuda ST2000DM008 2TB", "2", "54.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-184-773-V01.jpg"},
            {"2", "Seagate BarraCuda ST4000DM004 4TB", "4", "89.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-179-299-V01.jpg"},
            {"3", "WD Red 4TB NAS Internal Hard Drive", "4", "89.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-234-409-V01.jpg"},
            {"4", "WD Blue 4TB Desktop Hard Disk Drive", "4", "89.99", "https://c1.neweggimages.com/ProductImageCompressAll300/1Z4-0002-01CG2-01.jpg"},
            {"5", "Seagate IronWolf 4TB NAS Hard Drive", "4", "99.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-179-005-V01.jpg"},
            {"6", "Seagate IronWolf 8TB NAS Hard Drive", "8", "254.99", "https://c1.neweggimages.com/ProductImageCompressAll300/22-184-796-V06.jpg"}
        };
        public string[,] motherboard = new string[10, 4]
        {
            {"10", "ASUS TUF Gaming X570-PRO", "269.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-119-353-V04.jpg"},
            {"11", "ASUS ROG STRIX B550-F GAMING", "219.15", "https://c1.neweggimages.com/ProductImageCompressAll300/13-119-311-V03.jpg"},
            {"12", "MSI B560M PRO-VDH WIFI LGA 1200", "149.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-397-V01.jpg"},
            {"13", "MSI MPG B550 GAMING PLUS AM4", "179.57", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-325-V01.jpg"},
            {"14", "ASUS PRIME Z590-V LGA 1200 ATX", "169.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-119-418-V01.jpg"},
            {"15", "GIGABYTE Z590 AORUS ULTRA LGA 1200 ATX ", "329.90", "https://c1.neweggimages.com/ProductImageCompressAll300/13-145-270-01.jpg"},
            {"16", "ASUS ROG STRIX Z590-I GAMING", "369.80", "https://c1.neweggimages.com/ProductImageCompressAll300/13-119-377-V80.jpg"},
            {"17", "MSI MAG B560 TOMAHAWK WIFI LGA 1200", "219.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-393-V01.jpg"},
            {"18", "MSI MAG B560M MORTAR", "199.32", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-395-07.jpg"},
            {"19", "MSI MPG Z590M GAMING EDGE", "279.99", "https://c1.neweggimages.com/ProductImageCompressAll300/13-144-458-V08.jpg"}
        };
        public string[,] os = new string[4, 4]
        {
            {"1", "Microsoft Windows 10 Home, 64-bit", "99.99", "https://c1.neweggimages.com/ProductImageCompressAll300/32-416-892-11.jpg"},
            {"2", "Microsoft Windows 10 Pro 64-bit", "169.99", "https://c1.neweggimages.com/ProductImageCompressAll300/32-588-491-08.jpg"},
            {"3", "Microsoft Windows 11 Pro 64-bit", "189.99", "https://c1.neweggimages.com/ProductImageCompressAll300/32-350-882-V01.jpg"},
            {"4", "Microsoft Windows 11 Home 64-bit", "149.99", "https://c1.neweggimages.com/ProductImageCompressAll300/32-350-881-V01.jpg"}
        };
        public string[,] ram = new string[8, 5]
        {
            {"1", "G.SKILL Ripjaws V Series", "16", "93.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-232-880-V01.jpg"},
            {"2", "CORSAIR Vengeance LPX", "16", "79.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-236-540-S01.jpg"},
            {"3", "CORSAIR Vengeance RGB Pro", "32", "233.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-236-408-01.jpg"},
            {"4", "Kingston FURY Impact 16GB", "16", "84.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-242-624-V02.jpg"},
            {"5", "G.SKILL Ripjaws V Series 16GB", "16", "86.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-232-731-Z01.jpg"},
            {"6", "G.SKILL Trident Z Neo Series", "64", "410.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-232-999-V01.jpg"},
            {"7", "G.SKILL Ripjaws V Series", "32", "132.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-232-091-04.jpg"},
            {"8", "Team T-Force Delta RGB", "32", "149.99", "https://c1.neweggimages.com/ProductImageCompressAll300/20-331-635-V01.jpg"}
        };
        public string[,] soundcard = new string[10, 4]
        {
            {"1", "Creative Sound Blaster Z SE 5.1 Channels", "130.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-110-V01.jpg"},
            {"2", "Creative Sound Blaster Audigy RX 7.1", "79.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-063-07.jpg"},
            {"3", "Creative Sound Blaster AE-9 Sound Card", "429.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-105-V16.jpg"},
            {"4", "Creative Sound Blaster X-Fi Xtreme Audio 7.1 Channels", "79.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-026-01.jpg"},
            {"5", "Creative Sound Blaster Audigy FX 5.1 PCIe", "59.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-102-062-05.jpg"},
            {"6", "ASUS Xonar AE 7.1 Channels PCI Express Interface Sound Card", "101.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-132-084-V02.jpg"},
            {"7", "Creative X-Fi SB0670", "79.99", "https://c1.neweggimages.com/ProductImageCompressAll300/A4RE_132060100264906998K8rT9kp1UI.jpg"},
            {"8", "HT OMEGA Claro Halo", "315", "https://c1.neweggimages.com/ProductImageCompressAll300/29-271-004-03.jpg"},
            {"9", "ASUS Xonar AE 7.1 Channels PCI Express x1 Interface Sound Card", "88.44", "https://c1.neweggimages.com/ProductImageCompressAll300/29-132-085-V06.jpg"},
            {"10", "ASUS Xonar SE 5.1 Channel 192 kHz", "104.99", "https://c1.neweggimages.com/ProductImageCompressAll300/29-132-086-V01.jpg"}
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            string[,] component = new string[7, 5] { 
                { "Motherboard", "motherboard", "", "", "" }, 
                { "CPU", "cpu", "", "", "" }, 
                { "RAM", "ram", "", "", "" }, 
                { "Display", "display", "", "", "" }, 
                { "OS", "os", "", "", "" }, 
                { "Soundcard", "soundcard", "", "", "" },
                { "Hard Drive", "hd", "", "", "" }
            };
            string id = Request.QueryString["system"];
            double total = 0;
            Image picture = new Image();
            Panel panel = new Panel();
            Label itemName = new Label();
            Label itemPrice = new Label();
            Label speed = new Label();
            Label size = new Label();
            Label fps = new Label();
            Label storage = new Label();
            Label tax = new Label();
            Label shipping = new Label();
            Label totalPrice = new Label();
            Panel itemInfoDiv = new Panel();
            Panel priceDiv = new Panel();
            Button cart = new Button();
            int system = Convert.ToInt32(Request.QueryString["system"]) - 1;

            
            if (Request.QueryString["swap"] == "true")
            {
                if(Request.QueryString["part"] == "motherboard")
                {
                    systems[system, 2] = Request.QueryString["partID"];
                }
                else if (Request.QueryString["part"] == "ram")
                {
                    systems[system, 3] = Request.QueryString["partID"];
                }
                else if (Request.QueryString["part"] == "cpu")
                {
                    systems[system, 4] = Request.QueryString["partID"];
                }
                else if (Request.QueryString["part"] == "display")
                {
                    systems[system, 5] = Request.QueryString["partID"];
                }
                else if (Request.QueryString["part"] == "os")
                {
                    systems[system, 6] = Request.QueryString["partID"];
                }
                else if (Request.QueryString["part"] == "soundcard")
                {
                    systems[system, 7] = Request.QueryString["partID"];
                }
                else if (Request.QueryString["part"] == "hd")
                {
                    systems[system, 10] = Request.QueryString["partID"];
                }
            }


            total += Convert.ToDouble(motherboard[Convert.ToInt32(systems[system, 2]) - 10, 2]);
            total += Convert.ToDouble(ram[Convert.ToInt32(systems[system, 3]) - 1, 3]);
            total += Convert.ToDouble(cpu[Convert.ToInt32(systems[system, 4]) - 1, 3]);
            total += Convert.ToDouble(display[Convert.ToInt32(systems[system, 5]) - 1, 3]);
            total += Convert.ToDouble(os[Convert.ToInt32(systems[system, 6]) - 1, 2]);
            total += Convert.ToDouble(soundcard[Convert.ToInt32(systems[system, 7]) - 1, 2]);
            total += Convert.ToDouble(hd[Convert.ToInt32(systems[system, 10]) - 1, 3]);


            itemName.Text = systems[system, 1];
            itemName.Attributes["class"] = "itemName";
            itemInfoDiv.Controls.Add(itemName);
            itemInfoDiv.Attributes["class"] = "productInfo";
            speed.Text = "Speed: " + cpu[Convert.ToInt32(systems[system, 4]), 2] + " GHz";
            size.Text = "Size: " + ram[Convert.ToInt32(systems[system, 3]), 2] + " GB";
            fps.Text = "FPS: " + display[Convert.ToInt32(systems[system, 5]), 2] + "Hz";
            storage.Text = "Storage: " + hd[Convert.ToInt32(systems[system, 10]), 2] + " TB";
            itemInfoDiv.Controls.Add(speed);
            itemInfoDiv.Controls.Add(size);
            itemInfoDiv.Controls.Add(fps);
            itemInfoDiv.Controls.Add(storage);

            picture.ImageUrl = systems[system, 9];
            picture.Height = new Unit(200);
            picture.Width = new Unit(270);
            picture.Attributes["class"] = "itemImage";

            itemPrice.Text = total.ToString("C2");
            itemPrice.ID = system + "price";
            itemPrice.Attributes.Add("style", "font-size: 30px;margin-right: 10px; float: right;");

            cart.Text = "Add to Cart";
            cart.Attributes["class"] = "cartButton";
            cart.OnClientClick = "addToCart('" + system + "')";

            tax.Text = "Taxes:  " + (total * 0.15).ToString("C2");
            tax.Attributes["class"] = "taxAndShippingInfo";

            shipping.Text = "Shipping:  $8.99";
            shipping.Attributes["class"] = "taxAndShippingInfo";
            shipping.Attributes.Add("style", "text-decoration: underline;");

            totalPrice.Text = "Total:  " + ((total * 1.15) + 8.99).ToString("C2");
            totalPrice.Attributes["class"] = "taxAndShippingInfo";
            totalPrice.Attributes.Add("style", "font-weight: bold;");

            priceDiv.Attributes["class"] = "productViewPrice";
            priceDiv.ID = system + "priceDiv";
            priceDiv.Controls.Add(itemPrice);
            priceDiv.Controls.Add(tax);
            priceDiv.Controls.Add(shipping);
            priceDiv.Controls.Add(totalPrice);
            priceDiv.Controls.Add(cart);

            panel.Attributes["class"] = "productDisplay";
            panel.Controls.Add(picture);
            panel.Controls.Add(itemInfoDiv);
            panel.ID = system.ToString();

            product.Controls.Add(panel);
            product.Controls.Add(priceDiv);



            product.Attributes["class"] = "product";

            component[0, 2] = systems[system, 2];
            component[1, 2] = systems[system, 4];
            component[2, 2] = systems[system, 3];
            component[3, 2] = systems[system, 5];
            component[4, 2] = systems[system, 6];
            component[5, 2] = systems[system, 7];
            component[6, 2] = systems[system, 10];

            component[0, 3] = motherboard[Convert.ToInt32(systems[system, 2]) - 10, 3];
            component[1, 3] = cpu[Convert.ToInt32(systems[system, 4]) - 1, 4];
            component[2, 3] = ram[Convert.ToInt32(systems[system, 3]) - 1, 4];
            component[3, 3] = display[Convert.ToInt32(systems[system, 5]) - 1, 4];
            component[4, 3] = os[Convert.ToInt32(systems[system, 6]) - 1, 3];
            component[5, 3] = soundcard[Convert.ToInt32(systems[system, 7]) - 1, 3];
            component[6, 3] = hd[Convert.ToInt32(systems[system, 10]) - 1, 4];

            component[0, 4] = motherboard[Convert.ToInt32(systems[system, 2]) - 10, 1];
            component[1, 4] = cpu[Convert.ToInt32(systems[system, 4]) - 1, 1];
            component[2, 4] = ram[Convert.ToInt32(systems[system, 3]) - 1, 1];
            component[3, 4] = display[Convert.ToInt32(systems[system, 5]) - 1, 1];
            component[4, 4] = os[Convert.ToInt32(systems[system, 6]) - 1, 1];
            component[5, 4] = soundcard[Convert.ToInt32(systems[system, 7]) - 1, 1];
            component[6, 4] = hd[Convert.ToInt32(systems[system, 10]) - 1, 1];

            for (int i = 0; i < 6; i++)
            {
                Image image = new Image();
                Panel box = new Panel();
                Label label = new Label();
                Label name = new Label();
                Button swap = new Button();
                image.ImageUrl = component[i, 3];
                image.Height = new Unit(100);
                image.Width = new Unit(130);
                label.Text = component[i, 0];
                name.Text = component[i, 4];
                swap.OnClientClick = "swapComponent('" + component[i, 1] + "', '" + (system + 1) + "')";
                swap.Text = "Swap";
                swap.CssClass = "swapButton";
                box.Attributes["class"] = "itemDiv";
                box.Attributes["onClick"] = "swapComponent('" + component[i, 1] + "', '" + (system + 1) + "')";
                box.Controls.Add(label);
                box.Controls.Add(swap);
                box.Controls.Add(image);
                box.Controls.Add(name);

                categories.Controls.Add(box);
            }
        }
    }
}