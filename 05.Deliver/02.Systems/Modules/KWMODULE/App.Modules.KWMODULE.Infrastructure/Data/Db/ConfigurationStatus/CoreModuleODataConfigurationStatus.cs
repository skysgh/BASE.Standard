using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.ConfigurationStatus
{
    /// <summary>
    /// (Singleton) instance subclass of <see cref="ConfigurationStatusBase"/>
    /// used by <see cref="IConfigurationStatusService"/>
    /// to report to system admins
    /// whether an essential service has been configured or not.
    /// </summary>
    /// <seealso cref="ConfigurationStatusBase" />
    public class ModuleODataConfigurationStatus : ConfigurationStatusBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleODataConfigurationStatus"/> class.
        /// </summary>
        public ModuleODataConfigurationStatus() :
            base("OData Service",
                "OData based API Services provided to Authenticated users.",
                "No configuration required."
                )
        {
        }
    }
}
