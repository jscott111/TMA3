<html>
  <head>
    <title>Cookie</title>
  </head>
  <body>
    <p>Your IP address is @Request.UserHostAddress()</p> 
    <p>Your time zone is @TimeZone.CurrentTimeZone.StandardName</p>
    <p>Your time is @DateTime.Parse(strDateTime).ToLocalTime()</p>
  </body>
</html>
