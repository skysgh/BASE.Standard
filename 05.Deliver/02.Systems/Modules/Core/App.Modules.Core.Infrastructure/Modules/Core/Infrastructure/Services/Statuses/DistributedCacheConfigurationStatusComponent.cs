using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Statuses
{
    /// <summary>
    /// An in-memory, singleton, Configuration Status 
    /// summarizing whether a service have been
    /// configured correctly or not (or whether that is still unknown/untested).
    /// <para>
    /// Intended to be invoked
    /// from <see cref="IConfigurationStatusService"/>
    /// to provide information to System Administrators
    /// and developers
    /// as they are configuring the system for the first time.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Messages.ConfigurationStatusComponentBase" />
    public class
        DistributedCacheConfigurationStatusComponent :
            ConfigurationStatusComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DistributedCacheConfigurationStatusComponent" /> class.
        /// </summary>
        public DistributedCacheConfigurationStatusComponent() 
            : base("DistributedCacheService", 
                "Service to provide Distributed Caching across dynamically horizontally scalable servers.", 
                "Using the system's primary KeyVault, provide a ConnectionString to a remote Redis Cache instance. If no connection string provided, falls back to an in-memory implementation of IDistributedCache.")
        {
        }
    }
}
