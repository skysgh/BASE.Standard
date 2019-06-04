using System;

namespace App.Modules.Core.Models.Entities
{
    public abstract class TenantFKRecordStatedTimestampedNoIdEntityBase :
        UntenantedRecordStatedTimestampedNoIdEntityBase,
        IHasTenantFK
    {
        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        public virtual Guid TenantFK { get; set; }
    }


}