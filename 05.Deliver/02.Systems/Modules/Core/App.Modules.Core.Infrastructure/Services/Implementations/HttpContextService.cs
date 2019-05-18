using Microsoft.AspNetCore.Http;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class HttpContextService : AppCoreServiceBase, IHttpContextService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HttpContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public HttpContext Current => _contextAccessor.HttpContext;
    }
}