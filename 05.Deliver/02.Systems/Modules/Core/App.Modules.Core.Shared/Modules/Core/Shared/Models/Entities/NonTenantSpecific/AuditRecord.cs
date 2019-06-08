using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    
    public class AuditRecord : UntenantedRecordStatedTimestampedGuidIdEntityBase,
        IHasInRecordAuditability,
        IHasRecordSerializedIdentifier,
        IHasSerializedObject
    {

        public Guid RecordIdentifier { get; set; }
        public Guid SerializedObjectType { get; set; }
        public SerializedObjectSerializationMethod SerializedObjectSerializationMethod { get; set; }
        public string SerializedObjectValues { get; set; }

        //TODO: Convert to DateTimeOffset?
        public virtual DateTimeOffset? CreatedOnUtc { get; set; }
        public virtual string CreatedByPrincipalId { get; set; }
        public virtual DateTimeOffset? LastModifiedOnUtc { get; set; }
        public virtual string LastModifiedByPrincipalId { get; set; }
        public virtual DateTimeOffset? DeletedOnUtc { get; set; }
        public virtual string DeletedByPrincipalId { get; set; }

    }
}
