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
    public class AzureBlobConfigurationStatusComponent : ConfigurationStatusComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureBlobConfigurationStatusComponent"/> class.
        /// </summary>
        public AzureBlobConfigurationStatusComponent() 
            : base("Azure Blob Configuration", 
                "Service to persist media uploaded by end users (after it has been passed through a malware detection service (note that prior to the advent of cloud services, media used to be persisted to the file system).",
                "Settings are set in both the Host Settings(AppSettings) and KeyVault."
                )
        {
        }
    }
}
