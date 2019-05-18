﻿using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Controllers.Api.odata.Base
{

    /// <summary>
    /// All Controllers, whatever module,  *should* inherit in one way or another
    /// from this base controller.
    /// <para>
    /// That said, prefer using <see cref="ModulesODataControllerBase"/>
    /// to do that.
    /// </para>
    /// <para>
    /// The advantages include:
    /// * only one class that needs to be updated to .NET Core when we get there.
    /// * ensures that all classes are injected with an implementation of 
    /// <see cref="IDiagnosticsTracingService"/> and <see cref="IPrincipalService"/>
    /// so there is absolutely no excuse for poor diagnostics logs, or security...
    /// (that said, still don't trust developers rushing to meet deadlines to take 
    /// care of ISO-25010/Maintainability or ISO-25010/Security, so we handle 
    /// Security and Logging as GLobal Filters anyway).
    /// </para>
    /// </summary>
    /// <seealso cref="ODataController" />

        /// <para>
        /// Note that <see cref="ODataController"/>
        /// inherits from <see cref="ControllerBase"/>
        /// which is the NonView type of Controller
        /// (as oppossed to <see cref="Controller"/>)
        /// </para>
    [ApiController]
    public abstract class AllModulesODataControllerBase : ODataController
    {
        protected readonly IDiagnosticsTracingService _diagnosticsTracingService;
        protected readonly IPrincipalService _principalService;

        protected AllModulesODataControllerBase(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._principalService = principalService;

            this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"{this.GetType().Name} created.");

        }


        //// Validate to ensure the necessary scopes are present.
        //protected void HasRequiredScopes(string permission)
        //{

        //    this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"HasRequiredScopes: checking: {permission}.");

        //    //The base method just verifies scope
        //    if (!this._principalService.HasRequiredScopes(permission))
        //    {
        //        this._diagnosticsTracingService.Trace(TraceLevel.Debug, $"Throwing exception: The Scope claim does not contain the {permission} permission.");

        //        // this controller still has to raise an exception
        //        throw new HttpResponseException(new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.Unauthorized,
        //            ReasonPhrase = $"The Scope claim does not contain the {permission} permission."
        //        });
        //        var pd = new ProblemDetails();
        //        return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status405MethodNotAllowed);
        //        return Unauthorized();

        //        public async Task<IActionResult> CreateAsync([FromBody] Product product)
        //        {
        //            if (product.Description.Contains("XYZ Widget"))
        //            {
        //                return BadRequest();
        //            }

        //            await _repository.AddProductAsync(product);

        //            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        //        }
        //    }
        //}
    }
}