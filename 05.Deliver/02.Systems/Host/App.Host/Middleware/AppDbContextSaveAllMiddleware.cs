using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Host.Middleware
{
    /// <summary>
    /// Middleware to ensure Databases
    /// are saved at the end of each request. 
    /// </summary>
    public class AppDbContextSaveAllMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IAppDbContextManagementService _appDbContextManagementService;

#pragma warning disable CS0169 // Remove unused private members
#pragma warning disable IDE0051 // Remove unused private members
        private readonly IDbContextPreCommitService _dbContextPreCommitService;
#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore CS0169 // Remove unused private members

        public AppDbContextSaveAllMiddleware(RequestDelegate next,
                IDiagnosticsTracingService diagnosticsTracingService,
                IAppDbContextManagementService appDbContextManagementService)
        {
            _next = next;
            _diagnosticsTracingService = diagnosticsTracingService;
            _appDbContextManagementService = appDbContextManagementService;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            //await context.Response.WriteAsync("<div> Hello from AppDbContextSaveAllMiddleware </div>");


            await _next(context);

            _appDbContextManagementService.SaveChanges();

            //await context.Response.WriteAsync("<div> Bye from AppDbContextSaveAllMiddleware </div>");
        }
    }
}
