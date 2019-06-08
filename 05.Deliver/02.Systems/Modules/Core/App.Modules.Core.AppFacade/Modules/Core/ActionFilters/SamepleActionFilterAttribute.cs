using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Modules.Core.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SamepleActionFilterAttribute : ActionFilterAttribute
    {
        public SamepleActionFilterAttribute()
        {

        }
   

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        /// <inheritdoc />
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}


