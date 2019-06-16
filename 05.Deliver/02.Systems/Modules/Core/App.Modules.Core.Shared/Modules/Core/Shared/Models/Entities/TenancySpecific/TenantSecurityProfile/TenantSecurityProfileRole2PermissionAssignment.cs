using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A junction object to assign
    /// <see cref="TenantSecurityProfilePermission"/>s
    /// to <see cref="TenantSecurityProfileRole"/>s.
    /// </summary>
    public class TenantSecurityProfileRole2PermissionAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TenantSecurityProfileRole2PermissionAssignment"/> class.
        /// </summary>
        public TenantSecurityProfileRole2PermissionAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        /// <summary>
        /// Gets or sets the FK of the
        /// <see cref="TenantSecurityProfileRole"/>.
        /// </summary>

        /// <summary>
        /// Gets or sets the FK of the parent
        /// <see cref="TenantSecurityProfileRole"/>.
        /// </summary>
        public Guid RoleFK { get; set; }
        /// <summary>
        /// Gets or sets the parent
        /// <see cref="TenantSecurityProfileRole"/>.
        /// </summary>
        public TenantSecurityProfileRole Role { get; set; }

        /// <summary>
        /// Gets or sets the FK of the
        /// <see cref="TenantSecurityProfilePermission"/>
        /// to associate to the <see cref="TenantSecurityProfileRole"/>
        /// </summary>
        public Guid PermissionFK { get; set; }

        /// <summary>
        /// Gets or sets the
        /// <see cref="TenantSecurityProfilePermission"/>
        /// to associate to the <see cref="TenantSecurityProfileRole"/>
        /// </summary>
        public TenantSecurityProfilePermission Permission { get; set; }

        /// <summary>
        /// Gets or sets the type of the assignment (add/remove).
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }
}

