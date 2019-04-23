using App.Host.Initialization.DependencyResolution;
using App.Modules.Core.Infrastructure.Services;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace App.Host
{
    /// <summary>
    /// <para>
    /// Invoked from Program.cs
    /// </para>
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // But it is not longer needed now that we use ConfigureContainer method further down.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc()
        //        .AddControllersAsServices()
        //        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        //        ;
        //    //services.AddSingleton<IExampleInfrastructureService,ExampleInfrastructureService>();
        //}

        public void ConfigureContainer(ServiceRegistry serviceRegistry)
        {
            DependencyResolution.Initialize(serviceRegistry);
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




    }
}

