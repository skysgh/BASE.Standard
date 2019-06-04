using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.Base
{
    /// <summary>
    /// Base class for all API Controllers
    /// (as oppossed to OData based controllers, 
    /// which inherit from <see cref="AllModulesODataControllerBase"/>
    /// <para>
    /// Decorated with <code>[Route("api/[controller]")]</code>
    /// </para>
    /// </summary>
    [Route(App.Modules.Core.Shared.Constants.All.Apis.BasePath +"[controller]")]
    [ApiController]
    public abstract class AllModulesApiControllerBase : ControllerBase
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;

        public AllModulesApiControllerBase(
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
