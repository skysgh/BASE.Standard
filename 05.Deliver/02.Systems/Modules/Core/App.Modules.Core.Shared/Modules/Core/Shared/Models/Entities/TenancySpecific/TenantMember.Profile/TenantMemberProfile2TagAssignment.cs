// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities.TenantMember.Profile
{
    public class TenantMemberProfile2TagAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
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