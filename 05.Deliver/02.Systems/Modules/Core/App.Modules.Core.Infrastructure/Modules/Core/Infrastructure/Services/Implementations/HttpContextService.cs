// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class HttpContextService : AppCoreServiceBase, IHttpContextService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="HttpContextService" /> class.
        /// </summary>
        /// <param name="contextAccessor">The context accessor.</param>
        public HttpContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public HttpContext Current => _contextAccessor.HttpContext;
    }
}