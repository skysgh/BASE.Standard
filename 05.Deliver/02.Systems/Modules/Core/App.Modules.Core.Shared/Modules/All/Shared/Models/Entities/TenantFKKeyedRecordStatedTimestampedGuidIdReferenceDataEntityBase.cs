namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// Whereas <see cref="TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase"/>
    /// is all about DocuemntStore Id/Text, <see cref="TenantFKKeyedAuditedTimestampedRecordStatedGuidIdReferenceDataEntityBase"/>
    /// is about DocumentStoreId for storage, and Key/Text.
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKKeyedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Entities.Base.TenantFKTimestampedAuditedRecordStatedCustomIdReferenceDataEntityBase" />
    /// <seealso cref="App.Modules.Core.Shared.Models.IHasKey" />
    public abstract class TenantFKKeyedRecordStatedTimestampedGuidIdReferenceDataEntityBase
        : TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase, IHasKey
    {
        public virtual string Key { get; set; }
    }
}