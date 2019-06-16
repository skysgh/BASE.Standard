using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A tenant-specific Role that can be part of a <see cref="TenantSecurityProfileRoleGroup"/>
    /// or assigned directly to a <see cref="TenantSecurityProfile"/>
    /// </summary>
    public class TenantSecurityProfileRole : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TenantSecurityProfileRole"/> class.
        /// </summary>
        public TenantSecurityProfileRole()
        {
            Enabled = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TenantSecurityProfileRole"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }



        /// <summary>
        /// Gets or sets the permissions assigned
        /// to this <see cref="TenantSecurityProfileRole"/>.
        /// </summary>
        public virtual ICollection<TenantSecurityProfileRole2PermissionAssignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<TenantSecurityProfileRole2PermissionAssignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }
        private ICollection<TenantSecurityProfileRole2PermissionAssignment> _permissionsAssignments;


        /// <summary>
        /// Gets or sets the responsibilities assigned
        /// to this <see cref="TenantSecurityProfileRole"/>.
        /// </summary>
        public virtual ICollection<TenantSecurityProfileRole2ResponsibilityAssignment> ResponsibilityAssignments
        {
            get
            {
                return _responsibilityAssignments ?? (_responsibilityAssignments = new Collection<TenantSecurityProfileRole2ResponsibilityAssignment>());
            }
            set
            {
                _responsibilityAssignments = value;
            }
        }
        private ICollection<TenantSecurityProfileRole2ResponsibilityAssignment> _responsibilityAssignments;
    }

}

