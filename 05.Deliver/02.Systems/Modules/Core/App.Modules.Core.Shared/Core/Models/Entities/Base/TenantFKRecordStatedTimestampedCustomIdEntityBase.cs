using System;

namespace App.Modules.Core.Models.Entities
{
    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKRecordStatedTimestampedGuidIdEntityBase"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class TenantFKRecordStatedTimestampedCustomIdEntityBase<TId> :
        UntenantedRecordStatedTimestampedCustomIdEntityBase<TId>,
        /* Enherited: , IHasTimestamp, IHasInRecordAuditability, IHasRecordState */
        IHasTenantFK
        where TId: struct
    {

        public TenantFKRecordStatedTimestampedCustomIdEntityBase() : base()
        {
            //REMEMBER: As not a Guid ID Must be provided somehow...
        }

        public virtual Guid TenantFK { get; set; }
    }
}