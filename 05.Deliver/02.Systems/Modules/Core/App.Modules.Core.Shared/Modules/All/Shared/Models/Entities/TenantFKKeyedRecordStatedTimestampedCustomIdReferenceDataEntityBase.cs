namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// Whereas <see cref="TenantFKRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// is all about DocuemntStore Id/Text, <see cref="TenantFKKeyedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// is about DocumentStoreId for storage, and Key/Text.
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKKeyedAuditedTimestampedRecordStatedGuidIdReferenceDataEntityBase"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Entities.Base.TenantFKRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}" />
    /// <seealso cref="App.Modules.Core.Shared.Models.IHasKey" />
    public abstract class TenantFKKeyedRecordStatedTimestampedCustomIdReferenceDataEntityBase<TId> 
        : TenantFKRecordStatedTimestampedCustomIdReferenceDataEntityBase<TId>, IHasKey
        where TId : struct
    {
        public virtual string Key { get; set; }
    }
}