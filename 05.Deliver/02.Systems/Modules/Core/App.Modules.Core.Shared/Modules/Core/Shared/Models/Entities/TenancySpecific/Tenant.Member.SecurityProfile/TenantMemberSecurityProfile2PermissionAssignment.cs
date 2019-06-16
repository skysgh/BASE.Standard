// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A Join assignment object between the
    /// a parent <see cref="TenantMemberSecurityProfile"/>
    /// and child <see cref="TenantSecurityProfilePermission"/>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.TenantFKRecordStatedTimestampedNoIdEntityBase" />
    public class TenantMemberSecurityProfile2PermissionAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TenantMemberSecurityProfile2PermissionAssignment"/> class.
        /// </summary>
        public TenantMemberSecurityProfile2PermissionAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        /// <summary>
        /// Gets or sets the FK
        /// of the associated
        /// <see cref="TenantMemberSecurityProfile"/>
        /// </summary>
        public Guid MemberFK { get; set; }


        /// <summary>
        /// Gets or sets the
        /// FK of the
        /// parent <see cref="TenantMemberSecurityProfile"/>.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public TenantMemberSecurityProfile Member { get; set; }

        /// <summary>
        /// Gets or sets the FK
        /// of the <see cref="TenantSecurityProfilePermission"/>.
        /// being assigned to the parent
        /// <see cref="TenantMemberSecurityProfile"/>
        /// </summary>
        public Guid PermissionFK { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TenantSecurityProfilePermission"/>.
        /// being assigned to the parent
        /// <see cref="TenantMemberSecurityProfile"/>
        /// </summary>
        public TenantSecurityProfilePermission Permission { get; set; }

        /// <summary>
        /// Gets or sets the type of the assignment (add/remove)
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }
}