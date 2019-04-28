﻿//using App.Modules.Core.Infrastructure.Services;
//using App.Modules.Core.Shared.Models.Entities;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace App.Modules.Core.AppFacade.ActionFilters
//{
//    using System;
//    using System.Web;
//    using System.Web.Http.Controllers;
//    using System.Web.Http.Filters;
//    using App.Core.Infrastructure.Constants.Context;
//    using App.Core.Infrastructure.Services;
//    using App.Core.Shared.Models.Entities;
//    using Newtonsoft.Json;

//    /// <summary>
//    ///     Example Filter will intercept all MVC (not WebAPI) actions, and creates a SessionObject record
//    /// that will be later saved by an Filter that runs later.
//    /// <para>
//    /// Filters run in the following sequence:
//    /// AuthorizationFilter, ActionFilter, ResponseFilter, ExceptionFilter
//    /// </para>
//    /// </summary>
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
//    public class SessionOperationWebApiActionFilterAttribute : ActionFilterAttribute
//    {
//        private readonly IPrincipalService _principalService;
//        private readonly ISessionOperationLogService _sessionOperationLogService;
//        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
//        private readonly ISessionManagmentService _sessionManagmentService;

//        public SessionOperationWebApiActionFilterAttribute(IPrincipalService principalService, ISessionManagmentService sessionManagmentService,
//            ISessionOperationLogService sessionOperationLogService, IDiagnosticsTracingService diagnosticsTracingService)
//        {
//            this._principalService = principalService;
//            this._sessionOperationLogService = sessionOperationLogService;
//            this._diagnosticsTracingService = diagnosticsTracingService;
//            _sessionManagmentService = sessionManagmentService;
//        }

//        public override void OnActionExecuting(ActionExecutingContext actionContext)
//        {
//            this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"--------------------------------------------------");
//            this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"Request Start....");

//            SessionOperation sessionOperationLog = _sessionOperationLogService.Current;

//            sessionOperationLog.BeginDateTimeUtc = DateTime.UtcNow;
//            sessionOperationLog.ClientIp = actionContext.HttpContext.RemoteIPChain();
//            //sessionOperationLog.SessionFK = this._principalService.CurrentSessionIdentifier;
//            sessionOperationLog.Url = actionContext.Request.RequestUri.OriginalString;
//            sessionOperationLog.ControllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
//            sessionOperationLog.ActionName = actionContext.ActionDescriptor.ActionName;
//            sessionOperationLog.ActionArguments = "{}"; //todo: FIX this up
//            //actionContext.Request.Content.
//            /*
//            sessionOperationLog.ActionArguments = JsonConvert.SerializeObject(actionContext.ActionArguments,
//                Formatting.Indented, new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
//                */ // When using ODataQueryOptions this throws an outofmemoryException
//            sessionOperationLog.ResponseCode = "-1";

//            //No need to start tracking, and it is allready automatically committed when gotten.


//            base.OnActionExecuting(actionContext);
//        }

//        public override void OnActionExecuted(ActionExecutedContext actionContext)
//        {
//            base.OnActionExecuted(actionContext);

//            SessionOperation sessionOperation = _sessionOperationLogService.Current;

//            sessionOperation.EndDateTimeUtc = DateTime.UtcNow;
//            sessionOperation.Duration =
//                sessionOperation.EndDateTimeUtc.Subtract(sessionOperation.BeginDateTimeUtc);


//            if (actionContext.Response != null)
//            {
//                sessionOperation.ResponseCode = ((int)actionContext.Response.StatusCode).ToString();
//            }
//            else
//            {
//                sessionOperation.ResponseCode = "-1";
//            }
//            if (sessionOperation.Duration.TotalMilliseconds > 2000)
//            {
//                this._diagnosticsTracingService.Trace(TraceLevel.Warn, $"Operation took too long: {sessionOperation.Duration}");
//            }

//            _sessionManagmentService.SaveSessionOperationAsync(sessionOperation, _principalService);
//        }
//    }
//}