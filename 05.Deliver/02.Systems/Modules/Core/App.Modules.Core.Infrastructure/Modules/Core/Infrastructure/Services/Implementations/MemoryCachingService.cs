// Copyright MachineBrains, Inc. 2019

using System;
using System.Runtime.Caching;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Services;
using Microsoft.Extensions.Caching.Memory;
using MemoryCache = System.Runtime.Caching.MemoryCache;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="ICacheItemService" />
    ///     Infrastructure Service Contract
    /// </summary>
    public class MemoryCachingService : AppCoreServiceBase, IMemoryCachingService
    {
        private readonly IUniversalDateTimeService _dateTimeService;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheServiceConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCachingService"/> class.
        /// </summary>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="memoryCache">The memory cache.</param>
        public MemoryCachingService(
            IUniversalDateTimeService dateTimeService, 
            IMemoryCache memoryCache,
            MemoryCacheServiceConfiguration configuration)
        {
            _dateTimeService = dateTimeService;
            _memoryCache = memoryCache;
            this._configuration = configuration;
        }


        /// <summary>
        /// Gets the specified Typed item (refreshed if it has expired).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            T result;
            if (_memoryCache.TryGetValue(key, out result))
            {
                return result;
            }

            if (!_configuration.Exists(key))
            {
                return default(T);
            }

            result = _configuration.Get<T>(key).Invoke();
            _memoryCache.Set(key,result);
            return result;
        }



        /// <summary>
        /// Registers a function to retrieve values when requested.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="expiredCallback">The expired callback.</param>
        public void Register<T>(string key, TimeSpan duration, Func<T> expiredCallback)
        {
            if (duration.TotalSeconds < 60)
            {
                duration = TimeSpan.FromSeconds(60);
            }

            _configuration.Register(key, expiredCallback);
            _memoryCache.Set(key, expiredCallback.Invoke(),duration);
        }



    }
}