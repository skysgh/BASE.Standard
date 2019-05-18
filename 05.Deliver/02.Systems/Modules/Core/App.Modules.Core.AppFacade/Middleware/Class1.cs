//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace App.Modules.Core.AppFacade.Middleware
//{
//    public class MyHandlerMiddleware
//    {

//        // Must have constructor with this signature, otherwise exception at run time
//        public MyHandlerMiddleware(RequestDelegate next)
//        {
//            // This is an HTTP Handler, so no need to store next
//        }

//        public async Task Invoke(HttpContext context)
//        {

//                    context.Request.Query[""]
//            //context.Response.ContentType = GetContentType();
//            context.Response.Redirect("/");
//        }

//        // ...
//    }

//    public static class MyHandlerExtensions
//    {
//        public static IApplicationBuilder UseMyHandler(this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<MyHandlerMiddleware>();
//        }
//    }
//}