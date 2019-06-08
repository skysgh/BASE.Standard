// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
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