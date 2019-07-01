using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Data.Db.ConfigurationStatus
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
    /// <seealso cref="ConfigurationStatusComponentBase" />
    public class DbDatabaseConfigurationStatus : ConfigurationStatusComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbDatabaseConfigurationStatus"/> class.
        /// </summary>
        public DbDatabaseConfigurationStatus(
            ) : base(
            "Module DbContext",
            "Database context for the Module.",
            "Settings are set in both the Host Settings(AppSettings) and KeyVault."
            )
        {
        }
    }
}
