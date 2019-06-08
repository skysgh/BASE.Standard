using System;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace App.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        /*
         TODO: ISO-25010/Maintainability: When ASP.NET Core 3+ is released this will need updating to Generic Host
         As per: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-2.2
         */
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            // By default, config is read from:
            // appsettings.json, appsettings.{Environment Name}.json, 
            // environment variables, command line arguments, 
            //and other configuration sources.
            // But you can add your own.
            //var config = new ConfigurationBuilder()
            //    .AddJsonFile(path:"customSettings.json", optional:true,reloadOnChange:true)
            //    .Build();




            var result =
                WebHost.CreateDefaultBuilder(args)
                 // Look how early we define that Dependency Injection is First Class Citizen:
                 .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
                 //.CaptureStartupErrors(true)
                 .UseShutdownTimeout(TimeSpan.FromSeconds(1))
                 // Enable extended DependencyLocation as soon as possible:
                 .UseLamar()
                 .UseKestrel(x =>
                 {
                     // For Security reasons:
                     x.AddServerHeader = false;
                     x.Limits.MaxRequestHeaderCount = 24;
                     x.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(5);
                     x.Limits.MaxRequestBodySize = (6 * 1024 * 1024);
                 }
                 )
                //.ConfigureLogging(logging =>
                //{
                //    logging.AddConsole();
                //}
                ;

            result
                .ConfigureAppConfiguration((context, config) =>
           {
               //Use the app defined extension method to wire up a keyvault.
               config.AddKeyVaultSettingsConfig(
                   enabled: context.HostingEnvironment.IsProduction());
           });


            result
                //.UseConfiguration(config)
                .UseStartup<Startup>()
                 .CaptureStartupErrors(true);


            return result;
        }
    }
}
