// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Models.Entities
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