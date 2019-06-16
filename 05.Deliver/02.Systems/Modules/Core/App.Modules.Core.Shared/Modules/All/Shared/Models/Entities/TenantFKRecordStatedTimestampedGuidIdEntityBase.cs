using System;
using App.Modules.All.Shared.Factories;

namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKRecordStatedTimestampedCustomIdEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// <para>
    /// Implements
    /// <see cref="IHasTenantFK"/>
    /// <see cref="IHasGuidId"/>,
    /// <see cref="IHasId{T}"/>,
    /// <see cref="IHasTimestamp"/>
    /// <see cref="IHasInRecordAuditability"/>
    /// <see cref="IHasRecordState"/>
    /// </para>    
    /// </summary>
    /// <seealso cref="UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="IHasTenantFK" />
    public abstract class TenantFKRecordStatedTimestampedGuidIdEntityBase :
        UntenantedRecordStatedTimestampedCustomIdEntityBase<Guid>,
        IHasTenantFK,
        IHasGuidId
        
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantFKRecordStatedTimestampedGuidIdEntityBase"/> class.
        /// </summary>
        protected TenantFKRecordStatedTimestampedGuidIdEntityBase()
        {
            this.Id = GuidFactory.NewGuid();
        }

        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        public virtual Guid TenantFK { get; set; }
    }


}