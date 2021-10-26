<html>
  <head>
    <title>Cookie</title>
  </head>
  <body>
    <p>Your IP address is @Request.UserHostAddress()</p> 
    <p>Your time zone is @TimeZone.CurrentTimeZone.StandardName</p>
    <script>
      document.write("<p>" + Date.getTimezoneOffset + "</p>");
    </script>
  </body>
</html>
