// Copyright MachineBrains, Inc. 2019

using System;
using System.Runtime.Caching;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
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

        public MemoryCachingService(IUniversalDateTimeService dateTimeService, IMemoryCache memoryCache)
        {
            _dateTimeService = dateTimeService;
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            var result = (T) cache[key];
            // Can be null:
            return result;
        }


        //public TItem GetOrCreate<TItem>(this IMemoryCache cache, object key, Func<ICacheEntry, TItem> factory)
        //{


        //    if (!cache.TryGetValue(key, out object value))
        //    {
        //        ICacheEntry cacheEntry = cache.CreateEntry(key);
        //        value = factory(cacheEntry);
        //        cacheEntry.SetValue(value);
        //        cacheEntry.Dispose();
        //    }
        //    return (TItem)value;
        //}


        public void Register<T>(string key, T value, TimeSpan duration, Func<T> expiredCallback)
        {
            if (duration.TotalSeconds < 60)
            {
                duration = TimeSpan.FromSeconds(60);
            }

            //_memoryCache.Set("someKey", "someValue");
            //_memoryCache.Set("someKey", "SomeValue",);
            //MemoryCacheEntryOptions o = new MemoryCacheEntryOptions();
            //o.

            //_memoryCache.Set("someKey", "SomeValue",)


            ObjectCache cache = MemoryCache.Default;

            var cacheItemPolicy =
                new CacheItemPolicy
                {
                    AbsoluteExpiration = _dateTimeService.NowUtc().Add(duration)
                };

            // We want the item to be be self-invoking
            cacheItemPolicy.RemovedCallback = arguments =>
            {
                //Get the current (future) value:
                value = expiredCallback();
                //Reset it, reusing the policy (ie, duration), and callback:
                arguments.Source.Set(arguments.CacheItem.Key, value, cacheItemPolicy);
            };

            cache.Set(key, value, cacheItemPolicy);
        }
    }
}