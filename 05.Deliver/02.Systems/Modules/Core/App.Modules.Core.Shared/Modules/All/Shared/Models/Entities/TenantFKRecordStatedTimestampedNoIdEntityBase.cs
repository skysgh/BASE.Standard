using System;

namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedNoIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTenantFK" />
    public abstract class TenantFKRecordStatedTimestampedNoIdEntityBase :
        UntenantedRecordStatedTimestampedNoIdEntityBase,
        IHasTenantFK
    {
        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        /// <value>
        /// The tenant fk.
        /// </value>
        public virtual Guid TenantFK { get; set; }
    }


}