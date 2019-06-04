// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Models.Entities
{
    public class TenantMemberSecurityProfile2PermissionAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {

        public TenantMemberSecurityProfile2PermissionAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        public Guid MemberFK { get; set; }
        public TenantMemberSecurityProfile Member { get; set; }

        public Guid PermissionFK { get; set; }
        public TenantSecurityProfilePermission Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }
}