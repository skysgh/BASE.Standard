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
    public class AzureADConfigurationStatusComponent : ConfigurationStatusComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureADConfigurationStatusComponent"/> class.
        /// </summary>
        public AzureADConfigurationStatusComponent() 
            : base("Azure AD Configuration", 
                "Service required to provide authentication between components on the server.",
                $"Settings are set in both the Host Settings(AppSettings) and KeyVault."
                )
        {
        }
    }
}
