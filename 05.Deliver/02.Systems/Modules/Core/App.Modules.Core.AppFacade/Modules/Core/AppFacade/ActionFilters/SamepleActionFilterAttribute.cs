// Copyright MachineBrains, Inc. 2019

using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Modules.Core.AppFacade.ActionFilters

{
    /// <summary>
    ///     An example of a Sample filter that can be applied to all Requests.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SamepleActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <inheritdoc />
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