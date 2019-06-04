using App.Modules.Core.Factories;

namespace App.Modules.Core.Models.Entities
{
    /// <summary>
    /// Base abstract class for Mutable 
    /// Reference data. 
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// <para>
    /// Being mutable by end users, it has a Guid id and is specific to a single Tenant.
    /// </para>
    /// <para>
    /// Implements
    /// <see cref="IHasEnabled"/>
    /// <see cref="IHasText"/>
    /// <see cref="IHasDisplayOrderHint"/>
    /// <see cref="IHasDisplayStyleHint"/>
    /// <see cref="IHasTenantFK"/>
    /// <see cref="IHasGuidId"/>,
    /// <see cref="IHasId{T}"/>,
    /// <see cref="IHasTimestamp"/>
    /// <see cref="IHasInRecordAuditability"/>
    /// <see cref="IHasRecordState"/>
    /// </para>    
    /// <para>
    /// Refer to <see cref="UntenantedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/> for Reference data that is shared across Tenants.</para>
    /// </summary>
    /// <seealso cref="TenantFKRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="IHasEnabled" />
    /// <seealso cref="IHasText" />
    /// <seealso cref="IHasDisplayOrderHint" />
    public abstract class TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase : 
        TenantFKRecordStatedTimestampedGuidIdEntityBase,
        IHasMutableDisplayableReferenceData
    {

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase"/> is enabled.
        /// </summary>
        public virtual bool Enabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the reference data's displayed text.
        /// </summary>
        public virtual string Title
        {
            get; set;
        }

        public virtual string Description
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets the display order hint.
        /// </summary>
        public virtual int DisplayOrderHint
        {
            get; set;
        }

        // A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        public virtual string DisplayStyleHint
        {
            get; set;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase"/> class.
        /// </summary>
        protected TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase()
        {
            Id = GuidFactory.NewGuid();
        }



    }
}