namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Infrastructure.Services.Enums;
    using App.Modules.Core.Shared.Services;

    /// <summary>
    /// Base contract for an Infrastructure Service to 
    /// Cache information.
    /// <para>
    /// Only suitable for Immutable information.
    /// Consider Redis Cache Service for Muttable information
    /// shared between devices.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IHasAppCoreService" />
    public interface ICacheItemService : IHasAppCoreService
    {
        void Get<T>(CacheType cacheType, string key, string subKey = null);

        //void Register<T>(CacheType cacheType, string key, T value, TimeSpan duration, Func<T> expiredCallback);

        //void Register<T>(CacheType cacheType, string key, T value, TimeSpan duration, Func<T> expiredCallback);
    }

}