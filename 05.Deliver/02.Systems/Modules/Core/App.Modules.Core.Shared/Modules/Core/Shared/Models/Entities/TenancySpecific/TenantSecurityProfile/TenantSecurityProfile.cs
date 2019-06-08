﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A Tenant-specific Security Profile,
    /// defined by nested Groups of Role sets of Permissions
    /// </summary>
    public class TenantSecurityProfile : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {

        public bool Enabled { get; set; }



        public string Title { get; set; }
        public string Description { get; set; }


        public ICollection<TenantSecurityProfile2RoleGroupAssignment> RoleGroupAssignments
        {
            get
            {
                return _roleGroupAssignments ?? (_roleGroupAssignments = new Collection<TenantSecurityProfile2RoleGroupAssignment>());
            }
            set
            {
                _roleGroupAssignments = value;
            }
        }
        public ICollection<TenantSecurityProfile2RoleGroupAssignment> _roleGroupAssignments;


        public ICollection<TenantSecurityProfile2RoleAssignment> RoleAssignents
        {
            get
            {
                return _roleAssignments ?? (_roleAssignments = new Collection<TenantSecurityProfile2RoleAssignment>());
            }
            set
            {
                _roleAssignments = value;
            }
        }
        public ICollection<TenantSecurityProfile2RoleAssignment> _roleAssignments;


        public ICollection<TenantSecurityProfile2PermissionAssignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<TenantSecurityProfile2PermissionAssignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }
        public ICollection<TenantSecurityProfile2PermissionAssignment> _permissionsAssignments;





    }
}