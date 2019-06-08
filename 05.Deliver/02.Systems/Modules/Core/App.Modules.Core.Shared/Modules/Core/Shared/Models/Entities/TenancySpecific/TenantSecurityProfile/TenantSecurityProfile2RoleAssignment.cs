// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    public class TenantSecurityProfile2RoleAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
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