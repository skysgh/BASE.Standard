using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    using System;

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
    public interface IMemoryCachingService : IInfrastructureService
    {
        T Get<T>(string key);

        void Register<T>(string key, T value, TimeSpan duration, Func<T> expiredCallback);
    }

}