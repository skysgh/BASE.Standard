﻿// Copyright MachineBrains, Inc. 2019

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace App.Modules.Core.AppFacade.ActionFilters
//{
//    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
//    {
//        public override void OnException(HttpActionExecutedContext context)
//        {
//            var e = context.Exception;
//            if (e != null)
//            {
//                var error = new ODataError
//                {
//                    Message = e.Message,
//                };
//                if (e.InnerException != null)
//                {
//                    error.InnerError = new ODataInnerError(e.InnerException)
//                    {
//                        Message = e.InnerException.Message,
//                        StackTrace = e.InnerException.StackTrace,
//                        TypeName = e.InnerException.GetType().ToString()

//                    };
//                    error.Message = Newtonsoft.Json.JsonConvert.SerializeObject(error.InnerError);
//                }

//                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
//            }
//            else
//            {
//                base.OnException(context);
//            }


//        }
//    }
//}

