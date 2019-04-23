using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
            var config = new ConfigurationBuilder()
                .AddJsonFile(path:"hostsettings.json", optional:true)
                .Build();

           return WebHost.CreateDefaultBuilder(args)
                // Look how early we define that Dependency Injection is First Class Citizen:
                .UseSetting(WebHostDefaults.DetailedErrorsKey,"true")
                //.CaptureStartupErrors(true)
                .UseShutdownTimeout(TimeSpan.FromSeconds(1))
                .UseLamar()
                .UseKestrel()
                //.UseKestrel()
                //.ConfigureLogging(logging =>
                //{
                //    logging.AddConsole();
                //}
               
                .UseConfiguration(config)
                .UseStartup<Startup>();
        }
    }
}
