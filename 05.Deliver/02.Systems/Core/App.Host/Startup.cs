using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Lamar.Microsoft.DependencyInjection;
using Lamar;

namespace App.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                ;

       
            //services.AddSingleton<IExampleInfrastructureService,ExampleInfrastructureService>();

        }

        public void ConfigureContainer(ServiceRegistry services)
        {
            services.Scan(s =>
            {

                s.TheCallingAssembly();
                s.AssembliesFromApplicationBaseDirectory(x=>x.GetName().Name.StartsWith(App.Modules.Core.Shared.Constants.Application.APPPREFIX));
                s.WithDefaultConventions();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();


               
        }
    }
}
