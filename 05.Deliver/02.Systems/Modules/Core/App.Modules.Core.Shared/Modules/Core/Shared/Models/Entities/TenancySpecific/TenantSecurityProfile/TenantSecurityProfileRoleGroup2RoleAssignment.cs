// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A complex join object
    /// to associate a
    /// <see cref="TenantSecurityProfileRole"/>
    /// to a 
    /// a <see cref="TenantSecurityProfileRoleGroup"/>
    /// </summary>
    /// <seealso cref="TenantFKRecordStatedTimestampedNoIdEntityBase" />
    public class TenantSecurityProfileRoleGroup2RoleAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantSecurityProfileRoleGroup2RoleAssignment"/> class.
        /// </summary>
        public TenantSecurityProfileRoleGroup2RoleAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        /// <summary>
        /// Gets or sets the FK to
        /// the
        /// parent <see cref="TenantSecurityProfileRoleGroup"/>
        /// </summary>
        /// <summary>
        /// Gets or sets
        /// the
        /// parent <see cref="TenantSecurityProfileRoleGroup"/>
        /// </summary>
        public Guid GroupFK { get; set; }


        /// <summary>
        /// Gets or sets
        /// the
        /// parent <see cref="TenantSecurityProfileRoleGroup"/>
        /// </summary>
        /// <summary>
        /// Gets or sets
        /// the
        /// parent <see cref="TenantSecurityProfileRoleGroup"/>
        /// </summary>
        public TenantSecurityProfileRoleGroup Group { get; set; }



        /// <summary>
        /// Gets or sets the FK to
        /// the
        /// <see cref="TenantSecurityProfileRole"/>
        /// to assign to the parent
        /// <see cref="TenantSecurityProfileRoleGroup"/>
        /// </summary>
        public Guid RoleFK { get; set; }
        /// <summary>
        /// Gets or sets 
        /// the
        /// <see cref="TenantSecurityProfileRole"/>
        /// to assign to the parent
        /// <see cref="TenantSecurityProfileRoleGroup"/>
        /// </summary>
        public TenantSecurityProfileRole Role { get; set; }

        /// <summary>
        /// Gets or sets the type of the assignment (addition/removal)
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }
}