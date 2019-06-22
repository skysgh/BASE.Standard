// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A junction object to assign
    ///     <see cref="TenantSecurityProfilePermission" />s
    ///     directly
    ///     to <see cref="TenantSecurityProfile" />s.
    /// </summary>
    public class TenantSecurityProfile2PermissionAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TenantSecurityProfile2PermissionAssignment" /> class.
        /// </summary>
        public TenantSecurityProfile2PermissionAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        /// <summary>
        ///     Gets or sets the fk of the parent Profile.
        /// </summary>
        public Guid ProfileFK { get; set; }

        /// <summary>
        ///     Gets or sets the parent Profile.
        /// </summary>
        public TenantSecurityProfile Profile { get; set; }


        /// <summary>
        ///     Gets or sets the FK of the permission to assign.
        /// </summary>
        public Guid PermissionFK { get; set; }

        /// <summary>
        ///     Gets or sets the permission to assign.
        /// </summary>
        public TenantSecurityProfilePermission Permission { get; set; }

        /// <summary>
        ///     Whether the Assignment is additive, or subtractive
        ///     (an Account can be added to Groups to which Roles have been assigned,
        ///     or assigned directly to Roles,
        ///     and can be assigned Permissions that remove Permissions assigned by
        ///     one of the previous two methods.
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }
}