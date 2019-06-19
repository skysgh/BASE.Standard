using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;
using App.Modules.Design.Shared.Models.Entities.Enums;

namespace App.Modules.Design.Shared.Models.Entities.NonTenantSpecific
{
    /// <summary>
    /// A design requirement entity.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.Design.Shared.Models.IHasISO25010" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    public class Requirement
        : UntenantedRecordStatedTimestampedGuidIdEntityBase,
            IHasISO25010,
            IHasTitleAndDescription
    {
        /// <summary>
        /// Gets or sets the ISO25010 quality
        /// associated to this item.
        /// </summary>
        public ISO25010 ISO25010Quality { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
