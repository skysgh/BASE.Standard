using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities.TenantMember.Profile
{
    public class TenantMemberProfileProperty : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid PrincipalProfileFK { get; set; }

        public Guid GetOwnerFk()
        {
            return PrincipalProfileFK;
        }
    }
}