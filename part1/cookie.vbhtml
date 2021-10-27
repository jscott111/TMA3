<html>
  <head>
    <title>Cookie</title>
  </head>
  <body>
    <p>Your IP address is @ServerVariables("REMOTE_ADDR")</p> 
    <p>Your time zone is 
      <script>
        document.write(Intl.DateTimeFormat().resolvedOptions().timeZone);
      </script>
    </p>
  </body>
</html>
