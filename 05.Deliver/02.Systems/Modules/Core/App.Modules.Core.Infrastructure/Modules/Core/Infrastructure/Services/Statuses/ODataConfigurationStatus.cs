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
    /// <seealso cref="App.Modules.Core.Shared.Models.Messages.ConfigurationStatusBase" />
    public class ODataConfigurationStatus : ConfigurationStatusBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ODataConfigurationStatus"/> class.
        /// </summary>
        public ODataConfigurationStatus() :
            base("OData Service", 
                "OData based API Services provided to Authenticated users.", 
                "No configuration required."
                )
        {
        }
    }
}
