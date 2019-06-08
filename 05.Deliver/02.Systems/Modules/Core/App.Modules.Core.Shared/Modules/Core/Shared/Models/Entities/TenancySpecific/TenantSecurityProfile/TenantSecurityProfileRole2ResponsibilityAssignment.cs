// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    public class TenantSecurityProfileRole2ResponsibilityAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {

        public TenantSecurityProfileRole2ResponsibilityAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        public Guid RoleFK { get; set; }
        public TenantSecurityProfileRole Role { get; set; }

        public Guid ResponsibilityFK { get; set; }
        public TenantSecurityProfileResponsibility Responsibility { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }
}