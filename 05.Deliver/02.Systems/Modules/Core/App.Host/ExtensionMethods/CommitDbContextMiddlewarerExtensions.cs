using App.Host.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services;

namespace App //.Host.ExtensionMethods
{
    public static class CommitDbContextMiddlewarerExtensions
    {
        public static IApplicationBuilder UseAppDbContextSaveAllMiddleware(
            this IApplicationBuilder builder,
             IDiagnosticsTracingService diagnosticsTracingService,
        IAppDbContextManagementService appDbContextManagementService)

        {
            return builder.UseMiddleware<AppDbContextSaveAllMiddleware>(
                    diagnosticsTracingService,
                    appDbContextManagementService);
        }
    }
}
