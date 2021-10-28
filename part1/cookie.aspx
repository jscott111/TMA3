<%@ Page Language="C#" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8" />
        <title>Cookie</title>    
    </head>
    <body style="height: 532px; margin-bottom: 0px;">
        <div style="width: 565px; margin-left: 436px; margin-right: 453px; height: 143px; margin-top: 175px; margin-bottom: 0px;">
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
            <p style="font-size: xx-large; margin-top: 0px; width: 561px; margin-left: 0px; margin-bottom: 0px;">
                Your IP address is <b><%=Request.UserHostAddress%></b>
            </p>
            <p style="width: 562px; height: 36px; font-size: xx-large; margin-left: 0px; margin-right: 0px; margin-top: 5px; margin-bottom: 0px;">
                Your time zone is 
                <b><script>
                    document.write(Intl.DateTimeFormat().resolvedOptions().timeZone);
                </script></b>
            </p>
            <p style="font-size: xx-large; margin-top: 5px; margin-left: 0px; width: 560px; margin-right: 0px;">You've visited this site <b><%=Request.Cookies[Request.UserHostAddress].Value.Substring(Request.Cookies[Request.UserHostAddress].Name.Length + 1)%></b> times</p>
        </div>
    </body>
</html>


