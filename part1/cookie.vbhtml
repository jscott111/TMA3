<html>
  <head>
    <title>Cookie</title>
  </head>
  <body>
    @{
      string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];  
      if (string.IsNullOrEmpty(ip))  
      {  
        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];  
      }   
    }
    <p>Your IP address is @ip</p> 
    <p>Your time zone is 
      <script>
        document.write(Intl.DateTimeFormat().resolvedOptions().timeZone);
      </script>
    </p>
  </body>
</html>
