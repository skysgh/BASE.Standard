namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// Whereas <see cref="TenantFKRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// is all about DocuemntStore Id/Text, <see cref="TenantFKKeyedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// is about DocumentStoreId for storage, and Key/Text.
    /// <para>
    /// Note that this Base runs parallel to
    /// <see cref="TenantFKKeyedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    /// <seealso cref="TenantFKRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}" />
    /// <seealso cref="IHasKey" />
    public abstract class TenantFKKeyedRecordStatedTimestampedCustomIdReferenceDataEntityBase<TId> 
        : TenantFKRecordStatedTimestampedCustomIdReferenceDataEntityBase<TId>, IHasKey
        where TId : struct
    {
        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" /></para>.
        /// </summary>
        public virtual string Key { get; set; }
    }
}