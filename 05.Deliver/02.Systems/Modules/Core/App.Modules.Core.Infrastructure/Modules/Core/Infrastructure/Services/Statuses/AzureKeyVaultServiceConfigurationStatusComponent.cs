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
    public class AzureKeyVaultServiceConfigurationStatusComponent : ConfigurationStatusComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyVaultServiceConfigurationStatusComponent"/> class.
        /// </summary>
        public AzureKeyVaultServiceConfigurationStatusComponent() 
            : base("Azure KeyVault Service", 
                "Service to store - securely - keys to 3rd party services (Host Settings (eg: 'appSettings') is only appropriate for configuration settings (eg: srv Account name), not configuration secrets (eg: passwords).",
                "Access to the KeyVault is granted to the App's Service Account at deployment."
                )
        {
        }
    }
}
