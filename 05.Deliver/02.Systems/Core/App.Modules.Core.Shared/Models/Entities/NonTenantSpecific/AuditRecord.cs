using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Shared.Models.Entities.NonTenantSpecific
{
    public class AuditRecord: UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public string RecordType { get; set; }
        public string RecordIdentifier { get; set; }

        //TODO: Convert to DateTimeOffset?
        //public virtual DateTimeOffset? CreatedOnUtc { get; set; }
        //public virtual string CreatedByPrincipalId { get; set; }
        //public virtual DateTimeOffset? LastModifiedOnUtc { get; set; }
        //public virtual string LastModifiedByPrincipalId { get; set; }
        //public virtual DateTimeOffset? DeletedOnUtc { get; set; }
        //public virtual string DeletedByPrincipalId { get; set; }
    }
}
