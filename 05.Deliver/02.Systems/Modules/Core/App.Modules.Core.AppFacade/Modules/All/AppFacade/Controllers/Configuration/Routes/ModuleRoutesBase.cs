﻿// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.All.AppFacade.DependencyResolution;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Messages;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace App.Modules.All.AppFacade.Controllers.Configuration.Routes
{
    /// <summary>
    ///     Base class to simplify
    ///     defining a single Module's
    ///     Controller Routes (ie, Api, Views, OData).
    ///     <para>
    ///     Scanned for and found by <see cref="AllModulesAppFacadeServiceRegistry"/>
    ///     </para>
    ///     <para>
    ///         Then Invoked from the Host's Startup.cs
    ///     </para>
    /// </summary>
    /// <seealso cref="IModuleRoutes" />
    public abstract class ModuleRoutesBase : IModuleRoutes
    {

        /// <summary>
        ///     The dependency resolution service
        /// </summary>
        protected readonly IDependencyResolutionService
            _dependencyResolutionService;
        private readonly ODataConfigurationStatusComponent _configurationStatus;

        /// <summary>
        ///     The route prefix.
        ///     Must be unique.
        ///     Will  be the name of the Module.
        /// </summary>
        protected string _routePrefix;

        /// <summary>
        ///     The Name of this Module ("Core", etc.)
        /// </summary>
        protected string ModuleName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleRoutesBase" /> class.
        /// </summary>
        /// <param name="dependencyResolutionService">The dependency resolution service.</param>
        /// <param name="configurationStatus">The configuration status.</param>
        protected ModuleRoutesBase(
            IDependencyResolutionService dependencyResolutionService,
            ODataConfigurationStatusComponent configurationStatus
            )
        {
            ModuleName = Module.Id(GetType());

            _routePrefix = $"{Module.GetAssemblyNamePrefix(GetType())}.";

            _dependencyResolutionService = dependencyResolutionService;
            this._configurationStatus = configurationStatus;
        }

        /// <summary>
        ///     Initializes the specified MVC route builder.
        /// </summary>
        /// <param name="routeBuilder">The route builder.</param>
        public virtual void Initialize(IRouteBuilder routeBuilder)
        {
            CreateODataRoutes(routeBuilder);
        }

        /// <summary>
        ///     <para>
        ///         Invoked from Startup/Configure method,
        ///         within .AddMvc...
        ///     </para>
        /// </summary>
        /// <param name="routeBuilder"></param>
        protected virtual void CreateODataRoutes(IRouteBuilder routeBuilder)
        {
            //var oqo = new QueryOptionSetting();
            // Teaching it about OData commands.
            routeBuilder.Count().Expand().Filter().MaxTop(100).OrderBy()
                .Select();

            // Use method further down the page 
            // to create a Build Model by reflection, using
            // all OData Model definitions (ie, classes that implement
            // IAllModulesOdataModelBuilderConfiguration)
            // it can find
            var odataModelBuilder =
                BuildODataModelUsingReflectionAcrossAllAssembliesWithinLogicalModule();


            // Use the modelBuilder as the basis of defining routes:
            RegisterRoutesToODataController(routeBuilder, odataModelBuilder);
        }


        /// <summary>
        ///     Builds the o data model using reflection across all assemblies within this logical module.
        /// </summary>
        /// <returns></returns>
        protected virtual ODataConventionModelBuilder
            BuildODataModelUsingReflectionAcrossAllAssembliesWithinLogicalModule()
        {
            var odataModelBuilder =
                new ODataConventionModelBuilder();


            // BUG: Took ages to track down that this was causing
            // output to be truncated. No idea why. Avoid for now!
            // odataModelBuilder.EnableLowerCamelCase();

            var thisAssembly = GetType().Assembly;


            // Get OData Model Definitions
            // Limiting them to this Logical Module's Assembly.
            // TODO: Note that this kicks of instantiation of each type, 
            // when it would be better to select by type *before* instantiation...Oh well...
            IModuleOdataModelBuilderConfiguration[] modelDefinitions =
                _dependencyResolutionService
                    .GetAllInstances<IModuleOdataModelBuilderConfiguration>()
                    .Where(
                        x => x.GetType().IsSameLogicalModuleAs(GetType())
                    )
                    .ToArray();

            var version = new ApiVersion(0, 1);

            foreach (var x in modelDefinitions)
            {
                x.Apply(odataModelBuilder, version);

                _configurationStatus.AddStep(
                    ConfigurationStatusComponentStepType.General,
                    ConfigurationStatusComponentStepStatusType.Pass,
                    $"Register OData model and Controller using {x.GetType().Name}.",
                    "Success"
                );
            }

            // return MB for this Module only
            return odataModelBuilder;
        }


        /// <summary>
        ///     Called after <see cref="BuildODataModelUsingReflectionAcrossAllAssembliesWithinLogicalModule " />
        /// </summary>
        /// <param name="routeBuilder"></param>
        /// <param name="odataModelBuilder"></param>
        private void RegisterRoutesToODataController(
            IRouteBuilder routeBuilder,
            ODataConventionModelBuilder odataModelBuilder)
        {
            // Build the Edm model used to parse commands:
            var edmModel = odataModelBuilder.GetEdmModel();

            //var routingConventions = 
            //    ODataRoutingConventions
            //    .CreateDefaultWithAttributeRouting("x", 
            //    routeBuilder);

            // Create the default collection of built-in conventions.
            IList<IODataRoutingConvention> routingConventions =
                ODataRoutingConventions.CreateDefault();

            var routePrefix = $"odata/{Module.Id(GetType())}";
            // Register the Odata paths
            routeBuilder.MapODataServiceRoute(
                $"{_routePrefix}odata.default",
                routePrefix,
                edmModel
                //,
                //pathHandler: new DefaultODataPathHandler(),
                //routingConventions: routingConventions
            );
        }
    }
}