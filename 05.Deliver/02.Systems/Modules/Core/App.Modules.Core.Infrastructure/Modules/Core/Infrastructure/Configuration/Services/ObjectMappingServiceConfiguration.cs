// Copyright MachineBrains, Inc. 2019

//using App.Modules.All.Infrastructure.Contracts;
//using App.Modules.All.Infrastructure.Helpers;
//using App.Modules.All.Shared.Initialization;
//using App.Modules.Core.Infrastructure.ObjectMapping;
//using App.Modules.Core.Shared.Models.Messages;
//using AutoMapper;
//using Lamar;

//namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations
//{
//    public class ObjectMappingServiceConfiguration : ConfigurationObjectBase, IHasInitializer, IHasInitialized,
//        IHasInitialize
//    {


//        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
//        private readonly IConfigurationStepService _configurationStepService;
//        private readonly IDependencyResolutionService _dependencyResolutionService;

//        public IMapper IMapper
//        {
//            get { return _mapper; }
//        }

//        public bool Initialized
//        {
//            get { return _mapper != null; }
//        }

//        public IMapper _mapper;

//        public ObjectMappingServiceConfiguration(
//            IDiagnosticsTracingService diagnosticsTracingService,
//            IDependencyResolutionService dependencyResolutionService
//        )
//        {
//            _diagnosticsTracingService = diagnosticsTracingService;
//            _configurationStepService = configurationStepService;
//            _dependencyResolutionService = dependencyResolutionService;

//            Initialize();
//        }

//        public void Initialize()
//        {

//            if (Initialized)
//            {
//                return;
//            }

//            lock (this)
//            {
//                if (Initialized)
//                {
//                    return;
//                }

//                using (var elapsedTime = new ElapsedTime())
//                {

//                    var config = new _objectMappingService.MapperConfiguration(
//                        cfg =>
//                            // You can initialize Map descriptions manually or by Convention over Configuration 
//                            // using a combination of common interface and reflection.
//                            _dependencyResolutionService
//                                .GetAllInstances<Profile>()
//                                .ForEach(x => cfg.AddProfile(x)));

//                    config.AssertConfigurationIsValid();
//                    config.CompileMappings();

//                    // Or if convention/reflection/magic is not your cup of tea, you can do it the old way, creating lots of maps (
//                    // one map for each direction for each model):
//                    //ObjectMap_Example_ExampleDto.Initialize(cfg);
//                    // etc... (more maps)
//                    _mapper = config.CreateMapper();


//                    _configurationStepService
//                        .Register(
//                            ConfigurationStepType.General,
//                            ConfigurationStepStatus.White,
//                            "Automapper",
//                            $"Maps have been installed. Took {elapsedTime.ElapsedText}.");


//                }

//            }
//        }

//    }
//}


