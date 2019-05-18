using App.Modules.Core.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Shared.Models.Entities.TenancySpecific
{
    /// <summary>
    /// A Tenant-specific Member's Security Profile,
    /// pointing to a default Tenant Security Profile.
    /// Allowing for some refinement by adding/removing additional permissions.
    /// </summary>
    public class TenantMemberSecurityProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase
    {

        public bool Enabled { get; set; }


        // Points to default pre-established SecurityProfile,
        // adjusted minorly after that.

        public Guid SecurityProfileFK { get; set; }
        public TenantSecurityProfile SecurityProfile { get; set; }

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
        public ICollection<TenantMemberSecurityProfile2PermissionAssignment> _permissionsAssignments;

    }
}
