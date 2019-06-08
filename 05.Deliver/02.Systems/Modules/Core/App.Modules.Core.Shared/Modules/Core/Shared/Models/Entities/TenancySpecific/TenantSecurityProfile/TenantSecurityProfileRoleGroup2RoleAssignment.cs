﻿// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    public class TenantSecurityProfileRoleGroup2RoleAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
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