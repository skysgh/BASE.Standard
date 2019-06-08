using System;
using App.Modules;
using App.Modules.All.Infrastructure.DependencyResolution;
using App.Modules.Core.ActionFilters;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using App.Modules.Core.Initialization.Startup;
using App.Modules.Core.Initialization.Views;
using Lamar;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

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

            // Microsoft sample took care of this in COnfigureServices 
            // and puts it before AddMvc.
            services.AddOData();

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

            //serviceRegistry.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists"));
            //As per https://stackoverflow.com/q/38184583
            // In order for IHttpContextAccessor to work.
            serviceRegistry.AddHttpContextAccessor();

            //As per https://stackoverflow.com/q/38184583
            // May also have to register IActionContextAccessor, but not yet sure if we need it.




            // Note: invoked after ConfigureServices(see below)
            // Note: Already loaded with Framework services, just 
            // not this Application's services, yet.
            // That we offload that work to another class so that 
            // later the UnitTesting Test assemblies can leverage
            // the same initialization sequence.


            //// Microsoft sample took care of this in COnfigureServices 
            //// and puts it before AddMvc.
            //serviceRegistry.AddOData();


            serviceRegistry.AddMvc(
                    options =>
                    {
                        options.Filters.Add(typeof(SamepleActionFilterAttribute));
                        // As per https://damienbod.com/2018/10/12/odata-with-asp-net-core/

                        //If using CompatibilityVersion.Version_2_2 this shuold be false ?
                        // Or you get InvalidOperationException: Cannot use 'Microsoft.AspNet.OData.Routing.ODataRoute' with Endpoint Routing.
                        options.EnableEndpointRouting = false;
                    }
                    )
                // To make OpenApi output indented:
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                })
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                ;


            //For now (until GEt(1) works
            //serviceRegistry.AddODataQueryFilter();

            //// Register the Swagger generator, defining 1 or more Swagger documents
            //serviceRegistry.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", 
            //        new Info
            //        {
            //            Title = "My API",
            //            Version = "v1",
            //            Description = "A simple example ASP.NET Core Web API",
            //            TermsOfService = "None",
            //            Contact = new Contact
            //            {
            //                Name = "Shayne Boyer",
            //                Email = string.Empty,
            //                Url = "https://twitter.com/skystwt"
            //            },
            //            License = new License
            //            {
            //                Name = "Use under LICX",
            //                Url = "https://example.com/license"
            //            }
            //        });
            //});


            // All initialization up to this point was specific to ASP Framework
            // The rest can be moved down to a lower assembly that doesn't have
            // any Reference dependency on HTML.
            // This is so that UnitTesting can take advantage of the same setup:
            new AllModulesDependencyResolutionInitializer().Initialize(serviceRegistry);



            serviceRegistry.Configure<RazorViewEngineOptions>(options =>
            {
                // Note:
                // Probably won't work because it has only been taught where to scan, 
                // But has not yet scanned...
                _container.GetAllInstances<IAllModulesViewArtifactRegistration>()
                    .ForEach(x => x.Initialize(options));

            });



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
                string s3 = s2;
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseStaticFiles();


            app.UseMvc(
                routeBuilder =>
                {
                    // Needed to get OData running.
                    routeBuilder.EnableDependencyInjection();
                    //Use our helpr methods for setting up routes:
                    ConfigureRouteBuilderForTraditionalApiRoutes(routeBuilder);
                });

            // Use our own method for this:
            //SetupOpenApi(app);

            // Probably not needed, but don't want to lock in only way:
            InvokeAnyCustomConfigurationInOtherModulesFoundByReflection(app, env);

        }


        private void ConfigureRouteBuilderForTraditionalApiRoutes(Microsoft.AspNetCore.Routing.IRouteBuilder routeBuilder)
        {

            // Routes are processed from top to bottom,
            // Looking for *first* match.
            // So register every else first, before falling back to default routes.

            // Look around for any atypical routing:
            _container.GetAllInstances<IModuleRoutes>().ForEach(x => x.Initialize(routeBuilder));

            // ---- Area Based
            routeBuilder.MapRoute(
                name: $"defaultAreaRoute",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: $"defaultApi",
                template: "api/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: $"default",
                template: "{controller=Home}/{action=Index}/{id?}");

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


        private void InvokeAnyCustomConfigurationInOtherModulesFoundByReflection(IApplicationBuilder app, IHostingEnvironment env)
        {
            //May be zero or more custom configuration needed:
            _container.GetAllInstances<IStartupConfigure>().ForEach(x => x.Configure(app, env));
        }


    }

    public class SomeCustomConfig
    {
        public string Foo { get; set; }
        public int Biz { get; set; }
        public string Uno { get; set; }
    }

}

