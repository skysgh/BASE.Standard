using App.Host.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App //.Host.ExtensionMethods
{
    public static class SomeMiddlewarerExtensions
    {
        public static IApplicationBuilder UseAppDbContextSaveAllMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppDbContextSaveAllMiddleware>();
        }
    }
}
