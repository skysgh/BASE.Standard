using System;
using System.IO;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Configuration.Routes;
using App.Modules.All.AppFacade.DependencyResolution;
using App.Modules.All.AppFacade.Initialization;
using App.Modules.All.AppFacade.Views.Configuration;
using App.Modules.Core.AppFacade.ActionFilters;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.DependencyResolution;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Messages;
using AutoMapper;
using Lamar;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace App.Host
{
    /// <summary>
    /// <para>
    /// Invoked from Program.cs
    /// </para>
    /// </summary>
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private IContainer _container;

        private IConfiguration _configuration { get; }

        /// <summary>
        /// Constructor invoked from <see cref="Program" />.
        /// </summary>
        /// <param name="hostingEnvironment">The hosting environment.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="container">The container.</param>
        public Startup(
            IHostingEnvironment hostingEnvironment, 
            IConfiguration configuration, 
            IContainer container)
        {
            this._hostingEnvironment = hostingEnvironment;
            // Config sequence will be:
            // * appsettings.json
            // * appsettings.json / env specific
            // * env vars
            // * command line
            // So it's a bit surprising that env is *after* appsettings?
            _configuration = configuration;
            _container = container;
        }




        /// <summary>
        /// <para>
        /// This method gets called by the runtime before calling other methods in this class. 
        /// Use this method to add services to the container.
        /// But it is not longer needed now that we use ConfigureContainer method further down.
        /// </para>
        /// </summary>
        /// <param name="serviceRegistry"></param>
        public void ConfigureServices(IServiceCollection serviceRegistry)
        {
            //serviceRegistry.AddSingleton<ILoggerFactory>(x =>
            //    new LoggerFactory(
            //        x.GetServices<ILoggerProvider>(),
            //        x.GetRequiredService<IOptionsMonitor<LoggerFilterOptions>>()
            //    ));

            //serviceRegistry.AddSingleton<LoggerFactory>(x =>
            //    new LoggerFactory(
            //        x.GetServices<ILoggerProvider>(),
            //        x.GetRequiredService<IOptionsMonitor<LoggerFilterOptions>>()
            //    ));

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
            // DI will only scan Referenced and in-mem assemblies (too little)
            // So yuo want to bring in everything that could be related
            // (ie, assembies that are part of this system)
            // But not System/Microsoft assemblies (too much):
            var assemblies = AppDomain.CurrentDomain.LoadAllAppAssemblies();



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




            // Microsoft sample took care of this in COnfigureServices 
            // and puts it before AddMvc.
            serviceRegistry.AddOData();

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

            // We place UseMultiTenant before UseMvc,
            // But AddMultiTenant after AddMvc
            serviceRegistry
                .AddMultiTenant()
                .WithInMemoryStore(
                    _configuration.GetSection("InMemoryStoreConfig"))
                .WithHostStrategy()
                .WithRouteStrategy(RouteBuilder)
            .WithFallbackStrategy("tenant1")
            ;


            // All initialization up to this point was specific to ASP Framework
            // The rest can be moved down to a lower assembly that doesn't have
            // any Reference dependency on HTML.
            // This is so that UnitTesting can take advantage of the same setup:
            new ApplicationDependencyResolutionInitializer(_configuration)
                .Initialize(serviceRegistry);


            serviceRegistry.Configure<RazorViewEngineOptions>(options =>
            {
                // Note:
                // Probably won't work because it has only been taught where to scan, 
                // But has not yet scanned...
                _container.GetAllInstances<IAllModulesViewArtifactRegistration>()
                    .ForEach(x => x.Initialize(options));

            });


            // Scan only our assemblies (not everything in bin) for
            // Automapper specific mappers:
            var appAssemblies = AppDomain.CurrentDomain.GetAppAssemblies().ToArray();
            serviceRegistry.AddAutoMapper(appAssemblies, ServiceLifetime.Singleton);



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
            IContainer mvcContainer = (IContainer) serviceProvider;


            var configurationStatus =
                mvcContainer.GetInstance<ConfigurationStatusComponent>();


            //They are not the same. What does that mean?!
            if (!Object.Equals(mvcContainer, _container))
            {
                if (_container != null)
                {
                    configurationStatus.AddStep(
                        ConfigurationStatusComponentStepType.General,
                        ConfigurationStatusComponentStepStatusType.Orange,
                        "Verify Container",
                        "Not the same/expected.");
                }

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

            // Load settings from appsettings, and keyvault
            ConfigureAzureCloudEnvironmentSettings();


            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                configurationStatus.AddStep(
                    ConfigurationStatusComponentStepType.Security,
                    ConfigurationStatusComponentStepStatusType.Orange,
                    "Enable Developer Exception Page",
                    "Enabled (because working in Development environment). Note that Developer Exception Page may leak data if used where Production Data is used.");

                // Get hands on container
                string s1 = _container.WhatDidIScan();
                string s2 = _container.WhatDoIHave();
                string s2a =
                    _container.WhatDoIHave(typeof(IObjectMappingService));
                string s2b = _container.WhatDoIHave(typeof(IMapper));
                string s2c = _container.WhatDoIHave(typeof(LoggerFactory));
                string s3 = s2;


            }
            else if (env.IsEnvironment(EnvironmentName.Staging))
            {
                // read from the appsettings.Staging.json

            }
            else
            {
                app.UseHsts();
                configurationStatus.AddStep(
                    ConfigurationStatusComponentStepType.Security,
                    ConfigurationStatusComponentStepStatusType.Green,
                    "Enable Hsts",
                    "Enabled (working in Production environment).");
            }

            app.UseHttpsRedirection();
            configurationStatus.AddStep(
                ConfigurationStatusComponentStepType.Security,
                ConfigurationStatusComponentStepStatusType.Green,
                "Enable Https Redirection.",
                "Enabled. (note that this does not necessarily guarantee that the Cert is correctly configured).");

            app.UseCors();
            configurationStatus.AddStep(
                ConfigurationStatusComponentStepType.Security,
                ConfigurationStatusComponentStepStatusType.Green,
                "Enabled Cors.",
                "Enabled.");


            ConfigureStaticFileHandler(app, configurationStatus);
            // Place UseMultiTenant before UseMvc:
            app.UseMultiTenant();

            app.UseMvc(routeBuilder =>
            {
                // Needed to get OData running.
                routeBuilder.EnableDependencyInjection();

                RouteBuilder(routeBuilder);
            }
            );

        // Use our own method for this:
            //SetupOpenApi(app);

            // Probably not needed, but don't want to lock in only way:
            InvokeAnyCustomConfigurationInOtherModulesFoundByReflection(app, env);

        }

        private void RouteBuilder(IRouteBuilder routeBuilder)
        {
            //Use our helpr methods for setting up routes:
            ConfigureRouteBuilderForTraditionalApiRoutes(routeBuilder);
        }


        //public void  ConfigureDesignTimeServices(IServiceCollection services)
        //{

        //    //=> services.AddSingleton<EntityTypeWriter, MyEntityTypeWriter>();
        //}

        /// <summary>
        /// Configures the azure cloud environment settings.
        /// <para>
        /// Note that this area of the system -- bar the handling of connection
        /// strings -- is the one with the highest chance of
        /// a developer making a critical security error.
        /// </para>
        /// <para>
        /// How it works is that appsettings.json should only hold information
        /// about how a system is put together, without reference to the
        /// actual environment, or the accounts used to connect them together.
        /// </para>
        /// <para>
        /// As a  rule of thumb, appsettings.json is for general non-secret
        /// settings that don't mention any specific device or srv account.
        /// It is checked in, so anything secret
        /// that is put in this file is automatically a security breach
        /// since GitHub, etc. make code so easily available.
        /// </para>
        /// <para>
        /// appsettings.env.json is for general, non-secret settings like
        /// the above, except that its environment type specific (eg: db size,
        /// azure service SKU, etc.). It is checked in, so anything secret
        /// that is put in this file is automatically a security breach
        /// since GitHub, etc. make code so easily available.
        /// </para>
        /// <para>
        /// appsettings.INSECURE.json and appsettings.env.INSECURE.json
        /// follow the same as above, but are *not* checked in.
        /// Our experience is that it was easier for use to put
        /// developer settings in appsettings.INSECURE.json,
        /// and let the Build Agent fill in appsettings.INSECURE.json
        /// per target environment.
        /// </para>
        /// <para>
        /// We put very few secrets in these files, putting them mostly
        /// in the keyvault that becomes available to developers, etc.
        /// once they have defined what subscription, resourcegroup,
        /// keyVaultResourceName in appsettings.{env}.INSECURE.json
        /// </para>
        /// </summary>
        private void ConfigureAzureCloudEnvironmentSettings()
        {
            var s = _container.GetInstance<IConfigurationService>();

            // By this point, it better have learnt where the KeyVault is:
            var x = s.Get<AzureEnvironmentSettings>();
        }


        private static void ConfigureStaticFileHandler(IApplicationBuilder app,
            ConfigurationStatusComponent configurationStatus)
        {
            string staticFilePath =
                Path.Combine(Directory.GetCurrentDirectory(), "Assets");
            bool created = false;
            if (System.IO.Directory.Exists(staticFilePath))
            {
                created = true;
                System.IO.Directory.CreateDirectory(staticFilePath);
            }

            bool exists = System.IO.Directory.Exists(staticFilePath);
            int count = System.IO.Directory.GetFiles(staticFilePath).Length;

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilePath),
                RequestPath = "/Assets"
            });
            configurationStatus.AddStep(
                ConfigurationStatusComponentStepType.Routing,
                ConfigurationStatusComponentStepStatusType.Green,
                "Enable Static File Handling.",
                $"Enabled. Created={created}, Exists={exists}, Count={count}");
        }


        private void ConfigureRouteBuilderForTraditionalApiRoutes(Microsoft.AspNetCore.Routing.IRouteBuilder routeBuilder)
        {

            // Routes are processed from top to bottom,
            // Looking for *first* match.
            // So register every else first, before falling back to default routes.

            // Look around for any atypical routing:
            _container.GetAllInstances<IModuleRoutes>()
                .ForEach(x => x.Initialize(routeBuilder));

            //// ---- Tenanted
            //routeBuilder.MapRoute(
            //    name: $"defaultTenantedAreaRoute",
            //    template: "{__tenant__=}/{area:exists}/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: $"defaultTenantedApi",
                template: "{__tenant__=}/api/{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute(
                name: $"defaultTenanted",
                template: "{__tenant__=}/{controller=Home}/{action=Index}/{id?}");


            var configurationStatus =
                _container.GetInstance<ConfigurationStatusComponent>();

            configurationStatus.AddStep(
                ConfigurationStatusComponentStepType.Routing,
                ConfigurationStatusComponentStepStatusType.Green,
                "Register Default Controller Routes.",
                "Configured.");
        }



        /// <summary>
        /// Invoked from <see cref="Configure"/>
        /// </summary>
        /// <param name="app"></param>
        private void SetupOpenApi(IApplicationBuilder app)
        {
            string routeTemplate = "api-docs/{documentName}/swagger.json";

            app.UseSwagger(x =>
                x.RouteTemplate = routeTemplate
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

            var configurationStatus =
                _container.GetInstance<ConfigurationStatusComponent>();

            configurationStatus.AddStep(
                ConfigurationStatusComponentStepType.Routing,
                ConfigurationStatusComponentStepStatusType.Green,
                "Enable Swagger.",
                $"Enabled. Route Template: {routeTemplate}");
        }


        private void InvokeAnyCustomConfigurationInOtherModulesFoundByReflection(IApplicationBuilder app, IHostingEnvironment env)
        {
            //May be zero or more custom configuration needed:
            _container.GetAllInstances<IStartupConfigure>().ForEach(x => x.Configure(app, env));
        }


    }

}

