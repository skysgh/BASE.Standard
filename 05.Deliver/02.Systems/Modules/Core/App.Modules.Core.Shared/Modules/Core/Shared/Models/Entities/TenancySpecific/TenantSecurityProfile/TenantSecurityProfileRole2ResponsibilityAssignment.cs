// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A Join between <see cref="TenantSecurityProfileRole"/>
    /// and <see cref="TenantSecurityProfileResponsibility"/>.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.TenantFKRecordStatedTimestampedNoIdEntityBase" />
    public class TenantSecurityProfileRole2ResponsibilityAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TenantSecurityProfileRole2ResponsibilityAssignment"/> class.
        /// </summary>
        public TenantSecurityProfileRole2ResponsibilityAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        /// <summary>
        /// Gets or sets the FK of the
        /// <see cref="TenantSecurityProfileRole"/>.
        /// </summary>
        public Guid RoleFK { get; set; }


        /// <summary>
        /// Gets or sets the
        /// <see cref="TenantSecurityProfileRole"/>.
        /// </summary>
        public TenantSecurityProfileRole Role { get; set; }


        /// <summary>
        /// Gets or sets the FK of the
        /// <see cref="TenantSecurityProfileResponsibility"/>
        /// to associate to the parent
        /// <see cref="TenantSecurityProfileRole"/>
        /// </summary>
        public Guid ResponsibilityFK { get; set; }


        /// <summary>
        /// Gets or sets the 
        /// <see cref="TenantSecurityProfileResponsibility"/>
        /// to associate to the parent
        /// <see cref="TenantSecurityProfileRole"/>
        /// </summary>
        public TenantSecurityProfileResponsibility Responsibility { get; set; }

        /// <summary>
        /// Gets or sets the type of the assignment (add/remove).
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }
}