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

        public TenantSecurityProfileRole()
        {
            Enabled = true;
        }

        public bool Enabled { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }



        public ICollection<TenantSecurityProfileRole2PermissionAssignment> PermissionsAssignments
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
        public ICollection<TenantSecurityProfileRole2PermissionAssignment> _permissionsAssignments;



        public ICollection<TenantSecurityProfileRole2ResponsibilityAssignment> ResponsibilityAssignments
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
        public ICollection<TenantSecurityProfileRole2ResponsibilityAssignment> _responsibilityAssignments;
    }

}

