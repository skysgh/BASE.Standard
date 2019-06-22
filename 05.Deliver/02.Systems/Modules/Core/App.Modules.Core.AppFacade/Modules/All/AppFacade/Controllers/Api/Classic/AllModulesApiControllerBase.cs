// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Base;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.All.AppFacade.Controllers.Api.Classic
{
    /// <summary>
    ///     Base class for all API Controllers
    ///     (as opposed to OData based controllers,
    ///     which inherit from <see cref="CommonODataControllerBase" />)
    ///     <para>
    ///         Decorated with <code>[Route("api/[controller]")]</code>
    ///     </para>
    /// </summary>
    [Route(Apis.BasePath + "[controller]")]
    [ApiController]
    public abstract class AllModulesApiControllerBase : ControllerBase
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AllModulesApiControllerBase" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        protected AllModulesApiControllerBase(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
        }


        //// Validate to ensure the necessary scopes are present.
        //protected void HasRequiredScopes(string permission)
        //{
        //    //The base method just verifies scope
        //    if (!this._principalService.HasRequiredScopes(permission))
        //    {
        //        // this controller still has to raise an exception
        //        throw new HttpResponseException(new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.Unauthorized,
        //            ReasonPhrase = $"The Scope claim does not contain the {permission} permission."
        //        });
        //    }
        //}
    }
}