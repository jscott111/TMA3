<%@ Page Language="C#" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title></title>    
</head>
<body>
    <p>Your IP address is <%=Request.UserHostAddress%></p> 
    <p>Your time zone is 
    <script>
      document.write(Intl.DateTimeFormat().resolvedOptions().timeZone);
    </script>
    </p>
    <%
            HttpCookie cookie = new HttpCookie("cookie");

            cookie.Values.Add("cook", "1");

            cookie.Expires = DateTime.Now.AddYears(5);

            Response.Cookies.Add(cookie);
    %>
    <%=Request.Cookies["cookie"].Value%>
</body>
</html>

