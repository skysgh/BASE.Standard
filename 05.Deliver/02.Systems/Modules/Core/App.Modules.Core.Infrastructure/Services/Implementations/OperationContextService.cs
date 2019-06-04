using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using Microsoft.AspNetCore.Http;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using System.Web;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IOperationContextService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IOperationContextService" />
    public class OperationContextService : AppCoreServiceBase, IOperationContextService
    {
        private readonly IHttpContextService _httpContextService;
        private readonly IConversionService _conversionService;

        public OperationContextService(IHttpContextService httpContextService, IConversionService conversionService)
        {
            _httpContextService = httpContextService;
            this._conversionService = conversionService;
        }

        public T Get<T>(string key, T defaultValue = default(T))
        {
            if (_httpContextService.Current == null) { return defaultValue; }
            var result = this._conversionService.ConvertTo(_httpContextService.Current.Items[key], defaultValue);
            return result;
        }

        public void Set<T>(string key, T value)
        {
            if (_httpContextService.Current == null) { return; }
            _httpContextService.Current.Items[key] = value;
        }
    }
}


