namespace App.Modules.Core.Shared.Models.Entities.TenancySpecific
{
    using App.Modules.Core.Shared.Models;
    using App.Modules.Core.Shared.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// A tenant-specific group of Roles used to define a <see cref="TenantSecurityProfile"/>.
    /// </summary>
    public class TenantSecurityProfileRoleGroup :TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase , IHasTitle, IHasTitleAndDescription, IHasOptionalParentFK, IHasParent<TenantSecurityProfileRoleGroup>
    {

        public TenantSecurityProfileRoleGroup()
        {
            Enabled = true;
        }

        public bool Enabled { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public Guid? ParentFK { get; set; }
        public TenantSecurityProfileRoleGroup Parent { get; set; }

       

        public ICollection<TenantSecurityProfileRoleGroup2RoleAssignment> RoleAssignments
        {
            get
            {
                return _roleAssignments ?? (_roleAssignments = new Collection<TenantSecurityProfileRoleGroup2RoleAssignment>());
            }
            set
            {
                _roleAssignments = value;
            }
        }
        public ICollection<TenantSecurityProfileRoleGroup2RoleAssignment> _roleAssignments;

        //TODO: Could get large. Do we want this? Maybe it should only be on Account.
        //public ICollection<Account> Accounts { get; set; } 

    }

}

