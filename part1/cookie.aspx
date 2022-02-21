<%@ Page Language="C#" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8" />
        <title>Cookie</title>
        <link rel="stylesheet" href="../styles/TMA3Styles.css"/> 
    </head>
    <body class="cookiesBody">
        <div class="cookieDiv">
            <%
                if(Request.Cookies[Request.UserHostAddress] != null)
                {
                    HttpCookie cookie = Request.Cookies[Request.UserHostAddress];
                    String num = cookie.Value.Substring(cookie.Name.Length + 1);
                    cookie = new HttpCookie(Request.UserHostAddress);
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                    cookie = new HttpCookie(Request.UserHostAddress);
                    int value = Int32.Parse(num);
                    value++;
                    cookie.Values.Add(Request.UserHostAddress, value.ToString());
                    cookie.Expires = DateTime.Now.AddYears(5);
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie(Request.UserHostAddress);
                    cookie.Values.Add(Request.UserHostAddress, "1");
                    cookie.Expires = DateTime.Now.AddYears(5);
                    Response.Cookies.Add(cookie);
                }
            %>
            <p class="cookieText">
                Your IP address is <b><%=Request.UserHostAddress%></b>
            </p>
            <p class="cookieText">
                Your time zone is 
                <b><script>
                    document.write(Intl.DateTimeFormat().resolvedOptions().timeZone);
                </script></b>
            </p>
            <p class="cookieText">You've visited this site <b><%=Request.Cookies[Request.UserHostAddress].Value.Substring(Request.Cookies[Request.UserHostAddress].Name.Length + 1)%></b> times</p>
        </div>
    </body>
</html>



