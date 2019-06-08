using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Infrastructure.Services.Enums;

    /// <summary>
    /// Base contract for an Infrastructure Service to 
    /// Cache information.
    /// <para>
    /// Only suitable for Immutable information.
    /// Consider Redis Cache Service for Muttable information
    /// shared between devices.
    /// </para>
    /// </summary>
    /// <seealso cref="IInfrastructureService" />
    public interface ICacheItemService : IInfrastructureService
    {
        void Get<T>(CacheType cacheType, string key, string subKey = null);

        //void Register<T>(CacheType cacheType, string key, T value, TimeSpan duration, Func<T> expiredCallback);

        //void Register<T>(CacheType cacheType, string key, T value, TimeSpan duration, Func<T> expiredCallback);
    }

}