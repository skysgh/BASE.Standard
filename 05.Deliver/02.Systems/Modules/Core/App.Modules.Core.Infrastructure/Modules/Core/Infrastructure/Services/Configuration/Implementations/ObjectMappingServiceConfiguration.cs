using App.Modules.All.Infrastructure.Contracts;
using App.Modules.All.Infrastructure.Helpers;
using App.Modules.All.Infrastructure.ObjectMapping;
using App.Modules.Core.Infrastructure.ObjectMapping;
using App.Modules.Core.Shared.Models.Messages;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations
{
    public class ObjectMappingServiceConfiguration : IServiceConfigurationObject, IHasInitialized
    {
        private static bool _initialized;

        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IConfigurationStepService _configurationStepService;
        private readonly IDependencyResolutionService _dependencyResolutionService;

        public bool Initialized { get { return _initialized; } }

        public ObjectMappingServiceConfiguration(
        IDiagnosticsTracingService diagnosticsTracingService,
        IConfigurationStepService configurationStepService,
        IDependencyResolutionService dependencyResolutionService
            )
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _configurationStepService = configurationStepService;
            _dependencyResolutionService = dependencyResolutionService;

            Initialize();
        }

        public void Initialize()
        {

            if (_initialized) { return; }
            lock (this)
            {
                if (_initialized) { return; }
                using (var elapsedTime = new ElapsedTime())
                {

                    Mapper.Initialize(cfg =>
                    {
                        // You can initialize Map descriptions manually or by Convention over Configuration 
                        // using a combination of common interface and reflection.
                        _dependencyResolutionService.GetAllInstances<IHasAutomapperInitializer>()
                                    .ForEach(x => x.Initialize(cfg));

                        // Or if convention/reflection/magic is not your cup of tea, you can do it the old way, creating lots of maps (
                        // one map for each direction for each model):
                        //ObjectMap_Example_ExampleDto.Initialize(cfg);
                        // etc... (more maps)
                    });

                    // Verify that model is coherent:
                    Mapper.AssertConfigurationIsValid();
                    //Make it go faster:
                    Mapper.Configuration.CompileMappings();


                    _configurationStepService
                .Register(
                    ConfigurationStepType.General,
                    ConfigurationStepStatus.White,
                    "Automapper",
                    $"Maps have been installed. Took {elapsedTime.ElapsedText}.");

                }

                _initialized = true;
            }
        }
    }
}



