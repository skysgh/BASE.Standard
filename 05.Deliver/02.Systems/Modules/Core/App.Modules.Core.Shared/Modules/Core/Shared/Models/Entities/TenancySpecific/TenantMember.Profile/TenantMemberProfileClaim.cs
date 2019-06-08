using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities.TenantMember.Profile
{
    public class TenantMemberProfileClaim : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasRecordState, IHasOwnerFK
    {
        public virtual string Authority { get; set; }
        public virtual string AuthoritySignature { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid PrincipalProfileFK { get; set; }
        //public virtual RecordPersistenceState RecordState { get; set; }


        public Guid GetOwnerFk()
        {
            return PrincipalProfileFK;
        }
    }
}