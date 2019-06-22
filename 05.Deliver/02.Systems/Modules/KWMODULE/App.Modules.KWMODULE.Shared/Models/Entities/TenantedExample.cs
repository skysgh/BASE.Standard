using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.KWMODULE.Shared.Models.Entities
{
    /// <summary>
    ///     Example of an entity that has an Guid
    ///     which will automatically be filled in
    ///     when the entity is saved.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.TenantFKRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    public class TenantedExample : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {
        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }
    }
}