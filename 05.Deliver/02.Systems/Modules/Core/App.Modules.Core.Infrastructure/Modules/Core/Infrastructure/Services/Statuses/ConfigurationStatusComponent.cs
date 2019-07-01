using System;
using System.Collections.Generic;
using System.Text;
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
    public class ConfigurationStatusComponent : ConfigurationStatusComponentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationStartupConfigurationStatus" /> class.
        /// </summary>
        public ConfigurationStatusComponent()
            : base("Application Startup", "Process Startup File.", "")
        {
            // Note that this specific configuration object is used for two purposes.
            // When instantiated as a singleton, it acts as the Application Startup configuration object
            // referenced from Startup.
            // As OData can only serialize Instances, as opposed to Interfaces, or base classes with 
            // constructors expecting arguments, it also acts as the default base class to which
            // IConfigurationStatusService configures the object before returning the queryable set.
        }
    }
}
