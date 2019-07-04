// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using System.Reflection;
using App.Modules.All.Shared.Initialization;
using App.Modules.Core.Infrastructure.Configuration.Services;
using AutoMapper;
using Lamar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.All.AppFacade.DependencyResolution
{
    /// <summary>
    ///     Class invoked from both of the following:
    ///     * Startup's ConfigureContainer method (in App.Host)
    ///     * see DependencyResolutionContainerInitializer
    ///     (when running UnitTests)
    ///     to initialize all that is not specific to HTML.
    /// </summary>
    public class ApplicationDependencyResolutionInitializer : IHasInitialize<ServiceRegistry>
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDependencyResolutionInitializer"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ApplicationDependencyResolutionInitializer(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        ///     Initializes the specified service registry.
        /// </summary>
        /// <param name="serviceRegistry">The service registry.</param>
        public void Initialize(ServiceRegistry serviceRegistry)
        {
            AppDomain.CurrentDomain.LoadAllAppAssemblies();
            Assembly[] appAssemblies = AppDomain.CurrentDomain.GetAppAssemblies().ToArray();
            serviceRegistry.AddAutoMapper(appAssemblies, ServiceLifetime.Singleton);

            // This will of course depend on whether we are coming in from one of:
            // * the app, hosted in a web server
            // * the unit tests
            // TODO: Not yet able to invoke when coming in from design time creation of Migrations
            // unless the Factory is supposed to initialize Container.
            var currentDirectory = Environment.CurrentDirectory;


            // Enabled IMemCache, needed to 
            // back IMemoryCacheService:
            serviceRegistry.AddMemoryCache();

            // Enabled IDistributedCache, needed
            // to back horizontal scalability:

            var redisConfiguration = new DistributedCacheServiceConfiguration();

                _configuration.Bind( "app:modules:core:distributedCacheServiceConfiguration", redisConfiguration);

            try
            {
                if (string.IsNullOrEmpty(redisConfiguration.ConnectionString))
                {
                    serviceRegistry.AddDistributedMemoryCache();
                }
                else
                {
                    serviceRegistry
                        .AddStackExchangeRedisCache(
                            x=> { x.Configuration = redisConfiguration.CompleteConnectionString(); });
                }
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                serviceRegistry.AddDistributedMemoryCache();
            }

            //Depending on env:


            serviceRegistry.AddLogging();

            //DevelopAutoMapperAndRegisterService(serviceRegistry);


            serviceRegistry.Scan(assemblyScanner =>
            {
                // Note that this is the true base registry 
                // (whereas the Controllers may not be relevant here)

                //Where we want to be:
                // Want this scanner to search in all Assemblies related to this system.
                // Which we can see from the dll's name (as long as everybody
                // sticks to the convention of "App...." 
                assemblyScanner.AssembliesFromApplicationBaseDirectory(
                    x => x.IsSameApp());

                // Scan across all known assemblies for Services, Factories, etc.
                // That meet ISomething => Something naming convention:
                assemblyScanner.WithDefaultConventions();

                //This ensures it looks for additional Registries beyond this
                // Core one. In other words, it will scan all known assemblies 
                // (as per first line) for Module specific Registries. Such 
                // as AppModuleRegistry.


                assemblyScanner.LookForRegistries();
            });
        }


        private static void DevelopAutoMapperAndRegisterService(ServiceRegistry serviceRegistry)
        {
            var serviceDescriptor =
                serviceRegistry.Find(x => x.ServiceType == typeof(IMapper));


            if (serviceDescriptor != null)
            {
                return;
            }

            var iMapper =
                new MapperConfiguration(
                        x => x.AddMaps(AppDomain.CurrentDomain.GetAppAssemblies()))
                    .CreateMapper();

            serviceRegistry.For<IMapper>().Use(iMapper);
        }
    }
}