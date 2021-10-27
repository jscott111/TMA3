<html>
  <head>
    <title>Cookie</title>
  </head>
  <body>
    <p>Your IP address is @System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")</p> 
    <p>Your time zone is 
      <script>
        document.write(Intl.DateTimeFormat().resolvedOptions().timeZone);
      </script>
    </p>
    @{
      HttpCookie cookie = new HttpCookie("cookie");

      'cookie.Values.Add(System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"), "Hello");

      'cookie.Expires = DateTime.Now.AddYears(5);

      'Response.Cookies.Add(cookie);
  
      'string cookieValue = cookie.Values[System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")].ToString();
    }
  </body>
</html>
