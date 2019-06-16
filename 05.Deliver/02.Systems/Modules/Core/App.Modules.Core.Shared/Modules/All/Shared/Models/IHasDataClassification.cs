using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for entities that define the data classification.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDataClassificationFK" />
    public interface IHasDataClassification : IHasDataClassificationFK
    {
        /// <summary>
        /// Gets or sets the data classification of this entity.
        /// </summary>
        DataClassification DataClassification { get; set; }
    }




}
