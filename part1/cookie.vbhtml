<html>
  <head>
    <title>Cookie</title>
  </head>
  <body>
<p>Your IP address is @System.Web.HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")</p> 
    <p>Your time zone is 
      <script>
        document.write(Intl.DateTimeFormat().resolvedOptions().timeZone);
      </script>
    </p>
  </body>
</html>
