using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{

    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasInRecordAuditability" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordSerializedIdentifier" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasSerializedObject" />
    public class AuditRecord : UntenantedRecordStatedTimestampedGuidIdEntityBase,
        IHasInRecordAuditability,
        IHasRecordSerializedIdentifier,
        IHasSerializedObject
    {

        /// <summary>
        /// The target Record's Identifier value (almost always a Guid).
        /// <para>
        /// If the target record's key is a Guid, then you can reference that
        /// directly.
        /// But if the target has a composite key, or is an int, that is not feasible.
        /// In which case, you have to convert it to something else (a Type 5 Guid
        /// constructed from the SHA1 hash of a string -- eg a Json of they values).
        /// </para><para>
        /// They can't class as they are different classes
        /// (Type 5 versus 4 for random
        /// versus etc...)
        /// </para><para>
        /// Note that TenantFK information is not addressed
        /// at this level/in this contract.
        /// </para>
        /// </summary>
        public Guid RecordIdentifier { get; set; }
        /// <summary>
        /// Gets or sets the serialized Type of the serialized value (ie, it's Type fullname).
        /// </summary>
        public Guid SerializedObjectType { get; set; }
        /// <summary>
        /// How were the records persisted (
        /// as the years go by, different serializations
        /// come and into vogue -- but you don't want to
        /// have to do massive data migration operations
        /// of live systems...).
        /// </summary>
        public SerializedObjectSerializationMethod SerializedObjectSerializationMethod { get; set; }
        /// <summary>
        /// The string value containing the serialization of the target
        /// object's values.
        /// </summary>
        public string SerializedObjectValues { get; set; }


        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        public virtual DateTimeOffset? CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the Principal who created the record.
        /// </summary>
        public virtual string CreatedByPrincipalId { get; set; }
        /// <summary>
        /// Gets or sets when last modified on.
        /// </summary>
        public virtual DateTimeOffset? LastModifiedOnUtc { get; set; }
        /// <summary>
        /// Gets or sets the who did the last modification.
        /// </summary>
        public virtual string LastModifiedByPrincipalId { get; set; }
        /// <summary>
        /// Gets or sets when deleted.
        /// </summary>
        public virtual DateTimeOffset? DeletedOnUtc { get; set; }
        /// <summary>
        /// Gets or sets who deleted the record.
        /// </summary>
        public virtual string DeletedByPrincipalId { get; set; }

    }
}
