using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Configuration.Services;
using App.Modules.Core.Infrastructure.Services.Statuses;
using App.Modules.Core.Shared.Models.Messages;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class DistributedCacheService : IDistributedCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheServiceConfiguration _configuration;
        private readonly DistributedCacheConfigurationStatusComponent _configurationStatus;

        public DistributedCacheService(
            IDistributedCache distributedCache, 
            DistributedCacheServiceConfiguration configuration,
            DistributedCacheConfigurationStatusComponent configurationStatus)
        {
            this._distributedCache = distributedCache;
            this._configuration = configuration;
            this._configurationStatus = configurationStatus;
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
                _configurationStatus.SetToVerified();
            }
            catch (System.Exception e)
            {
                _configurationStatus.SetToError(e);
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
            var tmp = JsonConvert.DeserializeObject(_distributedCache.GetString(key),typeof(T));
            if (tmp == null)
            {
                return default(T);
            }
            return (T)tmp;
        }
    }
}
