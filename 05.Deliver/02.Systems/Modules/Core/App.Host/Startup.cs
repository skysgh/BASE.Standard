using App.Modules.Core.Infrastructure.Services;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using App.Modules.Core.AppFacade.ActionFilters;
using App.Modules.Core.AppFacade.Initialization.Mvc;
using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;
using App.Modules.Core.Shared;
using App.Modules.Core.Shared.Contracts;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using App.Modules.Core.Infrastructure.Services.Implementations;

namespace App.Host
{
    /// <summary>
    /// <para>
    /// Invoked from Program.cs
    /// </para>
    /// </summary>
    public class Startup
    {
        private IContainer _container;

        private IConfiguration _configuration { get; }

        /// <summary>
        /// Constructor invoked from <see cref="Program"/>.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration, IContainer container)
        {
            // Config sequence will be:
            // * appsettings.json
            // * appsettings.json / env specific
            // * env vars
            // * command line
            // So it's a bit surprising that env is *after* appsettings?
            _configuration = configuration;
            _container = container;
        }



        private void DemoHowToBindConfiguration()
        {
            // Example of getting custom
            var t = new SomeCustomConfig();
            _configuration.Bind("SomeCustomConfig", t);
        }

        /// <summary>
        /// Invoked from <see cref="Configure"/>
        /// </summary>
        /// <param name="app"></param>
        private static void SetupOpenApi(IApplicationBuilder app)
        {
            app.UseSwagger(x =>
                x.RouteTemplate = "api-docs/{documentName}/swagger.json"
            );
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/api-docs/v1/swagger.json", "My API V1");
                    // To serve the Swagger UI at the app's root:
                    //c.RoutePrefix = string.Empty;


                });
        }

        /// <summary>
        /// <para>
        /// This method gets called by the runtime before calling other methods in this class. 
        /// Use this method to add services to the container.
        /// But it is not longer needed now that we use ConfigureContainer method further down.
        /// </para>
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Note: invoked *before* ConfigureContainer (see below)
            // Note: Services that are registered here are available later,
            // but Lamar recommends leveraging ConfigureContainer instead.
            // See: https://jasperfx.github.io/lamar/documentation/ioc/aspnetcore/

        }



        /// <summary>
        /// Invoked by Lamar *after* <see cref="ConfigureServices"/>,
        /// and before invoking <see cref="Configure"/>
        /// <para>
        /// For some reason Lamar recommends to use this instead
        /// of <see cref="ConfigureServices"/></para>, but then it's hard
        /// to get a handle on the actual 
        /// </summary>
        /// <param name="serviceRegistry"></param>
        public void ConfigureContainer(ServiceRegistry serviceRegistry)
        {

            //As per https://stackoverflow.com/q/38184583
            // In order for IHttpContextAccessor to work.
            serviceRegistry.AddHttpContextAccessor();

            //As per https://stackoverflow.com/q/38184583
            // May also have to register IActionContextAccessor, but not yet sure if we need it.

            serviceRegistry.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(
                    new EmbeddedFileProvider(typeof(App.Modules.Core.AppFacade.Controllers.DescribeTypesController).GetTypeInfo().Assembly));
            });

            // Note: invoked after ConfigureServices(see below)
            // Note: Already loaded with Framework services, just 
            // not this Application's services, yet.
            // That we offload that work to another class so that 
            // later the UnitTesting Test assemblies can leverage
            // the same initialization sequence.


            serviceRegistry.AddOData();


            serviceRegistry.AddMvc(
                    options => options.Filters.Add(typeof(SamepleActionFilterAttribute))
                    )
                // To make OpenApi output indented:
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                })
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                ;

            // Register the Swagger generator, defining 1 or more Swagger documents
            serviceRegistry.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new Info
                    {
                        Title = "My API",
                        Version = "v1",
                        Description = "A simple example ASP.NET Core Web API",
                        TermsOfService = "None",
                        Contact = new Contact
                        {
                            Name = "Shayne Boyer",
                            Email = string.Empty,
                            Url = "https://twitter.com/skystwt"
                        },
                        License = new License
                        {
                            Name = "Use under LICX",
                            Url = "https://example.com/license"
                        }
                    });
            });
            // All initialization up to this point was specific to ASP Framework
            // The rest can be moved down to a lower assembly that doesn't have
            // any Reference dependency on HTML.
            // This is so that UnitTesting can take advantage of the same setup:
            new AllModulesDependencyResolutionInitializer().Initialize(serviceRegistry);

        }

        /// <summary>
        /// <para>
        /// Invoked by the runtime after 
        /// <see cref="ConfigureServices"/>
        /// and <see cref="ConfigureContainer"/>
        ///. Use this method to configure the HTTP request pipeline.
        /// </para>
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Register Container so we can reuse
            IServiceProvider serviceProvider = app.ApplicationServices;
            // Which in this case is the Lamar container:
            IContainer mvcContainer = (IContainer)serviceProvider;

            //They are not the same. What does that mean?!
            if (!Object.Equals(mvcContainer, _container))
            {
                _container = mvcContainer;
            }

            //Which we can register for so that everybody can get to it later:
            DependencyLocator.Current.Initialize(_container);
            // Interesting...this is not the same LamarContainer as the one
            // registered in Container

            // The question I have is: how does one get to the same container from other locations
            // in the applications (eg, from unit tests) which don't have access to app?

            //env.ContentRootPath
            //env.EnvironmentName
            app.UseAppDbContextSaveAllMiddleware(
                _container.GetInstance<IDiagnosticsTracingService>(),
                _container.GetInstance<IAppDbContextManagementService>());

            if (env.IsDevelopment())
            {
                DemoHowToBindConfiguration();

                app.UseDeveloperExceptionPage();

                // Get hands on container
                string s1 = _container.WhatDidIScan();
                string s2 = _container.WhatDoIHave();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseStaticFiles();
            // Use our own method for this:
            SetupOpenApi(app);

            app.UseMvc(
                routeBuilder =>
                {
                    _container.GetAllInstances<IModuleRoutes>().ForEach(x => x.Initialize(routeBuilder));
                });


        }



    }

    public class SomeCustomConfig
    {
        public string Foo { get; set; }
        public int Biz { get; set; }
        public string Uno { get; set; }
    }

}

