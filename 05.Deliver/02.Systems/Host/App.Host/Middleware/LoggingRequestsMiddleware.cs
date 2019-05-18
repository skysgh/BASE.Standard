//// Copyright MachineBrains, Inc.

//using Microsoft.AspNetCore.Http;

//namespace App.Host.Middleware
//{
//    public class LoggingRequestsMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public LoggingRequestsMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async System.Threading.Tasks.Task Invoke(HttpContext context)
//        {


//            //await context.Response.WriteAsync("<div> Hello from AppDbContextSaveAllMiddleware </div>");
//            await _next(context);
//            await context.Response.WriteAsync("<div> Bye from AppDbContextSaveAllMiddleware </div>");
//        }
//    }
//}