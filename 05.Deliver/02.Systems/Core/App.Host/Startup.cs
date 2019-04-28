using App.Modules.Core.Infrastructure.Services;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;
using App.Modules.Core.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace App.Host
{
    /// <summary>
    /// <para>
    /// Invoked from Program.cs
    /// </para>
    /// </summary>
    public class Startup
    {

        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            // Config sequence will be:
            // * appsettings.json
            // * appsettings.json / env specific
            // * env vars
            // * command line
            // So it's a bit surprising that env is *after* appsettings?
            _configuration = configuration;
        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //env.ContentRootPath
            //env.EnvironmentName
            app.UseAppDbContextSaveAllMiddleware();

            // Register Container so we can reuse
            IServiceProvider serviceProvider = app.ApplicationServices;
            // Which in this case is the Lamar container:
            IContainer container = (IContainer)serviceProvider;
            //Which we can register for so that everybody can get to it later:
            container.GetInstance<IDependencyResolutionService>().Initialize(container);
            // The question I have is: how does one get to the same container from other locations
            // in the applications (eg, from unit tests) which don't have access to app?



            // Example of getting custom
            var t = new SomeCustomConfig();
            _configuration.Bind("SomeCustomConfig", t);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Get hands on container


                string s1 = container.WhatDidIScan();
                string s2 = container.WhatDoIHave();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors();

            app.UseStaticFiles();


            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                        name: "MyArea",
                        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // But it is not longer needed now that we use ConfigureContainer method further down.
        public void ConfigureServices(IServiceCollection services)
        {
            // Note: invoked *before* ConfigureContainer (see below)
            // Note: Services that are registered here are available later,
            // but Lamar recommends leveraging ConfigureContainer instead.

            //services.AddMvc()
            //    .AddControllersAsServices()
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            //    ;
            //services.AddSingleton<IExampleInfrastructureService,ExampleInfrastructureService>();
        }

        public void ConfigureContainer(ServiceRegistry serviceRegistry)
        {
            // Note: invoked after ConfigureServices(see below)
            // Note: Already loaded with Framework services, just 
            // not this Application's services, yet.
            // That we offload that work to another class so that 
            // later the UnitTesting Test assemblies can leverage
            // the same initialization sequence.

            serviceRegistry.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                ;

            // All initialization up to this point was specific to ASP Framework
            // The rest can be moved down to a lower assembly that doesn't have
            // any Reference dependency on HTML.
            // This is so that UnitTesting can take advantage of the same setup:
            new ApplicationDependencyResolutionInitializer().Initialize(serviceRegistry);

        }
    }

    public class SomeCustomConfig
    {
        public string Foo { get; set; }
        public int  Biz { get; set; }
        public string Uno { get; set; }
    }
    

}

