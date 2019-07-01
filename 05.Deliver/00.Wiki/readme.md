## Environment ##

* The ASPNETCORE_ENVIRONMENT environment variable is set within the App.Host's 
  Properties' Debug tab.
* THis is how Program.cs/Setup.cs knows what enviornment we're running under.
* And therefore what app.settings.{env}.json to read.