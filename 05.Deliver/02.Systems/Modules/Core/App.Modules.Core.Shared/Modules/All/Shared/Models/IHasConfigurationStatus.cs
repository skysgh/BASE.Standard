using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for Entities that
    /// expose a status as to how
    /// a service has been configured or not.
    /// </summary>
    public interface IHasConfigurationStatus
    {
        /// <summary>
        /// Gets or sets the status of the service.
        /// </summary>
        ConfigurationStatusType Status { get; set; }
    }
}
