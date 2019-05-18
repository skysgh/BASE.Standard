// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Shared.Models.Entities.TenancySpecific
{
    public class TenantMemberProfile2TagAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public TenantMemberProfile2TagAssignment()
        {
            //AssignmentType = AssignmentType.Add;
        }

        public Guid TenantPrincipalFK { get; set; }
        public TenantMemberProfile TenantPrincipal { get; set; }

        public Guid TagFK { get; set; }
        public TenantMemberProfileTag Tag { get; set; }
    }
}