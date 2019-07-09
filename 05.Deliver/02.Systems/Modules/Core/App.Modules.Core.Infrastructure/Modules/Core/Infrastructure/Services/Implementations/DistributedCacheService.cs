using System;
using App.Modules.Core.Infrastructure.Configuration.Services;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class DistributedCacheService : IDistributedCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheServiceConfiguration _configuration;
        private readonly IConfigurationStatusService _configurationStatusService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCacheService"/> class.
        /// </summary>
        /// <param name="distributedCache">The distributed cache.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="configurationStatusService">The configuration status service.</param>
        public DistributedCacheService(
            IDistributedCache distributedCache,
            DistributedCacheServiceConfiguration configuration,
            IConfigurationStatusService configurationStatusService)
        {
            this._distributedCache = distributedCache;
            this._configuration = configuration;
            this._configurationStatusService = configurationStatusService;
        }

        public void Set<T>(string key, T value, TimeSpan duration)
        {

            if (duration.TotalSeconds < 60)
            {
                duration = TimeSpan.FromSeconds(60);
            }

            string tmp = JsonConvert.SerializeObject(value);

            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = duration;
            try
            {
                _distributedCache.SetString(key, tmp, options);
                _configurationStatusService.SetStatusToVerified<IDistributedCacheService>();
            }
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable IDE0059 // Value assigned to symbol is never used
            catch (System.Exception e)
#pragma warning restore IDE0059 // Value assigned to symbol is never used
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw;
            }

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
            _configuration.Register(key, expiredCallback);
            Set(key, expiredCallback.Invoke(), duration);
        }

        public T Get<T>(string key)
        {
            var tmp = JsonConvert.DeserializeObject(_distributedCache.GetString(key), typeof(T));
            if (tmp == null)
            {
                return default(T);
            }
            return (T)tmp;
        }

        public bool Ping()
        {
            if (!_configuration.Enabled)
            {
                return false;
            }

            try
            {
                return true;
            }
            catch
            {
                
            }

            return false;
            // throw new NotImplemented();
        }
    }
}
