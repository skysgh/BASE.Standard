using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for Entities that define a DataClassification.
    /// </summary>
    public interface IHasDataClassificationFK
    {
        /// <summary>
        /// Gets or sets the FK of the
        /// data classification.
        /// </summary>
        NZDataClassification DataClassificationFK { get; set; }
    }




}
