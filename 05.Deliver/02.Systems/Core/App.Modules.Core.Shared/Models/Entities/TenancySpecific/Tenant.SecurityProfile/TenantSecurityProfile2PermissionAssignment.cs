﻿namespace App.Modules.Core.Shared.Models.Entities.TenancySpecific
{
    using App.Modules.Core.Shared.Models.Entities;
    using System;

    /// <summary>
    /// A junction object to assign
    /// <see cref="TenantSecurityProfilePermission"/>s
    /// directly
    /// to <see cref="TenantSecurityProfile"/>s.
    /// </summary>
    public class TenantSecurityProfile2PermissionAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {

        public TenantSecurityProfile2PermissionAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }
        public Guid ProfileFK { get; set; }
        public TenantSecurityProfile Profile { get; set; }

        public Guid PermissionFK { get; set; }
        public TenantSecurityProfilePermission Permission { get; set; }

        /// <summary>
        /// Whether the Assignment is additive, or subtractive
        /// (an Account can be added to Groups to which Roles have been assigned,
        /// or assigned directly to Roles,
        /// and can be assigned Permissions that remove Permissions assigned by 
        /// one of the previous two methods.
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }

}
