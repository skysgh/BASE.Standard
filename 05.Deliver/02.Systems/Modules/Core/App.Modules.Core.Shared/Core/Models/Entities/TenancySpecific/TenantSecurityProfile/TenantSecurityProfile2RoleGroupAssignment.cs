// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Models.Entities
{
    public class TenantSecurityProfile2RoleGroupAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {
        public TenantSecurityProfile2RoleGroupAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        public Guid ProfileFK { get; set; }
        public TenantSecurityProfile Profile { get; set; }

        public Guid RoleGroupFK { get; set; }
        public TenantSecurityProfileRoleGroup RoleGroup { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }
}