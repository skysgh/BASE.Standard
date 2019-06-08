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

        public TenantSecurityProfileRole2PermissionAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        public Guid RoleFK { get; set; }
        public TenantSecurityProfileRole Role { get; set; }

        public Guid PermissionFK { get; set; }
        public TenantSecurityProfilePermission Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }
}

