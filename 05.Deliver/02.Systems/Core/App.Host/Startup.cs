using App.Host.Initialization.DependencyResolution;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var container = (IContainer)app.ApplicationServices;

                Modules.Core.Shared.Factories.ServiceLocator.SetLocatorProvider(container);

                string s1 = container.WhatDidIScan();
                string s2 = container.WhatDoIHave();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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

