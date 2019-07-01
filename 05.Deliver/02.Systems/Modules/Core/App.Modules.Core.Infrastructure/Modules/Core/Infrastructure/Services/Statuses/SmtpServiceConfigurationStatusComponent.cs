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
    public class SmtpServiceConfigurationStatusComponent : ConfigurationStatusComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpServiceConfigurationComponentStatus"/> class.
        /// </summary>
        public SmtpServiceConfigurationStatusComponent() 
            : base(
                "SMTP Service", "Service used to notify users via Email. Used to invite Users to User Groups, etc.",
                "Settings are set in both the Host Settings(AppSettings) and KeyVault.")
        {
        }
    }
}
