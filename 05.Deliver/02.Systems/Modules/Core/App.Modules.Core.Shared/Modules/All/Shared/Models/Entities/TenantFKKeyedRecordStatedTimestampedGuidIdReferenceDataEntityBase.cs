// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    ///     Whereas <see cref="TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase" />
    ///     is all about DocumentStore Id/Text,
    ///     <see cref="TenantFKKeyedRecordStatedTimestampedGuidIdReferenceDataEntityBase" />
    ///     is about DocumentStoreId for storage, and Key/Text.
    ///     <para>
    ///         Note that this Base runs parrallel to
    ///         <see cref="TenantFKKeyedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}" />
    ///         (inheritence line is based on Id Type).
    ///     </para>
    /// </summary>
    /// <seealso cref="TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase" />
    /// <seealso cref="IHasKey" />
    public abstract class TenantFKKeyedRecordStatedTimestampedGuidIdReferenceDataEntityBase
        : TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase, IHasKey
    {
        /// <summary>
        ///     Gets or sets the unique key of the object,
        ///     by which it is indexed when persisted
        ///     (in additional to any primary Id).
        ///     <para>
        ///         Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" />
        ///     </para>
        ///     .
        /// </summary>
        public virtual string Key { get; set; }
    }
}