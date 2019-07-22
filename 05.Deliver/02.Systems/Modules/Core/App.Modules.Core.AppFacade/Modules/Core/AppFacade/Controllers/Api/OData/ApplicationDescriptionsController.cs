// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Base;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Configuration;
using App.Modules.Core.Shared.Models.DTOs;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData
{
    /// <summary>
    ///     Controller to return DiagnosticsTrace messages
    ///     to authorised users.
    /// </summary>
    /// <seealso cref="CommonODataControllerBase" />
    [ODataRoutePrefix("DiagnosticsTraces")]
    public class ApplicationDescriptionsController
        : CommonODataControllerBase

    {
        private readonly IApplicationDescriptionService _applicationInformationService;
        private readonly IObjectMappingService _objectMappingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticsTracesController" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="applicationInformationService">The application information service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        public ApplicationDescriptionsController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            IApplicationDescriptionService applicationInformationService,
            IObjectMappingService objectMappingService
            )
            : base(diagnosticsTracingService,
            principalService
            )
        {
            this._applicationInformationService = applicationInformationService;
            this._objectMappingService = objectMappingService;
        }


        /// <summary>
        ///     Gets a queryable set of
        ///     <see cref="DiagnosticsTraceRecordDto" />
        ///     objects.
        /// </summary>
        /// <returns></returns>
        public ActionResult<ApplicationDescriptionDto> Get()
        {
            return Ok(
                _objectMappingService
                    .Map<ApplicationDescriptionServiceConfiguration, 
                        ApplicationDescriptionDto>(
                _applicationInformationService.GetApplicationInformation()
            ));
        }

    }
}