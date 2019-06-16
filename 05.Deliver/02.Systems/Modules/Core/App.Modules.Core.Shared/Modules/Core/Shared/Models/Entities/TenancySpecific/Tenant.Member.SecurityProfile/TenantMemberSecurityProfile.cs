using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A Tenant-specific Member's Security Profile,
    /// pointing to a default Tenant Security Profile.
    /// Allowing for some refinement by adding/removing additional permissions.
    /// </summary>
    public class TenantMemberSecurityProfile : TenantFKRecordStatedTimestampedGuidIdEntityBase
    {

        /// <summary>
        /// Gets or sets a value indicating whether this
        /// <see cref="TenantMemberSecurityProfile"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }


        /// <summary>
        /// Gets or sets the
        /// FK of the
        /// parent <see cref="SecurityProfile"/>
        /// </summary>
        public Guid SecurityProfileFK { get; set; }

        /// <summary>
        /// Gets or sets the parent
        /// <see cref="TenantSecurityProfile"/>.
        /// </summary>
        public TenantSecurityProfile SecurityProfile { get; set; }


        /// <summary>
        /// Gets or sets the permissions assigned to this
        /// <see cref="TenantMemberSecurityProfile"/>
        /// </summary>
        public ICollection<TenantMemberSecurityProfile2PermissionAssignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<TenantMemberSecurityProfile2PermissionAssignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }

        private ICollection<TenantMemberSecurityProfile2PermissionAssignment> _permissionsAssignments;

    }
}
