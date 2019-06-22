// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Services.Implementations.Base;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IOperationContextService" />
    ///     Infrastructure Service Contract.
    ///     <para>
    ///         Basically provides a value for the duration
    ///         of the request (ie, it's using the HttpContext
    ///         when running within an Http Host)
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IOperationContextService" />
    public class OperationContextService : AppCoreServiceBase, IOperationContextService
    {
        private readonly IConversionService _conversionService;
        private readonly IHttpContextService _httpContextService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OperationContextService" /> class.
        /// </summary>
        /// <param name="httpContextService">The HTTP context service.</param>
        /// <param name="conversionService">The conversion service.</param>
        public OperationContextService(
            IHttpContextService httpContextService,
            IConversionService conversionService)
        {
            _httpContextService = httpContextService;
            _conversionService = conversionService;
        }

        /// <summary>
        ///     Gets the value of the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public T Get<T>(string key, T defaultValue = default)
        {
            if (_httpContextService.Current == null)
            {
                return defaultValue;
            }

            var result = _conversionService.ConvertTo(_httpContextService.Current.Items[key], defaultValue);

            return result;
        }

        /// <summary>
        ///     Sets the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Set<T>(string key, T value)
        {
            if (_httpContextService.Current == null)
            {
                return;
            }

            _httpContextService.Current.Items[key] = value;
        }
    }
}