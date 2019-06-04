using System;

namespace App.Modules.Core.Models.Entities
{
    public class TenantClaim : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Authority { get; set; }
        public virtual string AuthoritySignature { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid TenantFK { get; set; }

        public Guid GetOwnerFk()
        {
            return TenantFK;
        }
    }
}