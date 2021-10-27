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
      @Dim c As New HttpCookie(System.Web.HttpContext.Current.Request.ServerVariables("REMOTE_ADDR"))

      'c.Value = DateTime.Now.ToString()

      'c.Expires = DateTime.Now.AddMonths(2)

      'Response.Cookies.Add(c)
  </body>
</html>
