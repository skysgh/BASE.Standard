// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Shared.Models.Entities.TenancySpecific
{
    public class TenantSecurityProfileRoleGroup2RoleAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {

        public TenantSecurityProfileRoleGroup2RoleAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        public Guid GroupFK { get; set; }
        public TenantSecurityProfileRoleGroup Group { get; set; }

        public Guid RoleFK { get; set; }
        public TenantSecurityProfileRole Role { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }
}