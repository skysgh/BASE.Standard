// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Shared.Models.Entities.TenancySpecific
{
    public class TenantSecurityProfile2RoleAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        public TenantSecurityProfile2RoleAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        public Guid ProfileFK { get; set; }
        public TenantSecurityProfile Profile { get; set; }

        public Guid RoleFK { get; set; }
        public TenantSecurityProfileRole Role { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }


}