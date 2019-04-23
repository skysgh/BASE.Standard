using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Host.Middleware
{
    public class AppDbContextSaveAllMiddleware
    {
        private readonly RequestDelegate _next;

        public AppDbContextSaveAllMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            //await context.Response.WriteAsync("<div> Hello from AppDbContextSaveAllMiddleware </div>");
            await _next(context);
            await context.Response.WriteAsync("<div> Bye from AppDbContextSaveAllMiddleware </div>");
        }
    }
}
