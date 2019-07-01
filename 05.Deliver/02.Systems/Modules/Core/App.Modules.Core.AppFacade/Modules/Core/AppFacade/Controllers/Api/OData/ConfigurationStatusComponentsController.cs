// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.Classic;
using App.Modules.All.AppFacade.Controllers.Api.OData.Base;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Messages;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.Classic
{
    /// <summary>
    /// Controller to return a collection of
    /// configuration elements (derived from
    /// <see cref="ConfigurationStatusComponentBase"/> and <see cref="IConfigurationComponentStatus"/>)
    /// that describe how the system is configured.
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.Base.CommonODataControllerBase" />
    public class ConfigurationStatusComponentsController : CommonODataControllerBase
    {
        private readonly IObjectMappingService _objectMappingService;
        private readonly IConfigurationStatusService _configurationStatusService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStatusComponentsController" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="configurationStatusService">The configuration status service.</param>
        public ConfigurationStatusComponentsController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IObjectMappingService objectMappingService,
            IConfigurationStatusService configurationStatusService
        )
            : base(diagnosticsTracingService, principalService)
        {
            this._objectMappingService = objectMappingService;
            this._configurationStatusService = configurationStatusService;
        }

        /// <summary>
        ///     Return a queryable set of configuration elements.
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        public ActionResult<IQueryable<ConfigurationStatusComponentDto>> Get()
        {
            var g = _configurationStatusService.GetComponents();

            var results =
                _objectMappingService.ProjectTo<ConfigurationStatusComponentDto>(
                    g,
                    (object)null,
                    x=>x.Steps
                        );
            return Ok(results);
        }

        /// <summary>
        /// Gets the specified element.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public ActionResult<IQueryable<ConfigurationStatusComponentDto>> Get(string key)
        {
            var result =
                _objectMappingService.ProjectTo<ConfigurationStatusComponentDto>(
                _configurationStatusService.GetComponents(),
                (object)null,
                x => x.Steps
                ).SingleOrDefault(x => x.Title == key);

            return Ok(result);
        }
    }
}