using System;
using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Attributes;

namespace App.Modules.Core.Infrastructure.Services
{
    [TitleDescription("DistributedCacheService",
        "Service to provide Distributed Caching across dynamically horizontally scalable servers.",
        "Using the system's primary KeyVault, provide a ConnectionString to a remote Redis Cache instance. If no connection string provided, falls back to an in-memory implementation of IDistributedCache.")]
    public interface IDistributedCacheService : IRemoteServiceClientInfrastructureService
    {

        /// <summary>
        /// Sets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="duration">The duration.</param>
        void Set<T>(string key, T value, TimeSpan duration);

        /// <summary>
        /// Gets the specified Typed item (refreshed if it has expired).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// Registers a function to retrieve values when requested.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="expiredCallback">The expired callback.</param>
        void Register<T>(string key, TimeSpan duration, Func<T> expiredCallback);



    }
}
