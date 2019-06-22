// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A Tenant-specific Security Profile,
    ///     defined by nested Groups of Role sets of Permissions
    /// </summary>
    public class TenantSecurityProfile : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {
        private ICollection<TenantSecurityProfile2PermissionAssignment> _permissionsAssignments;
        private ICollection<TenantSecurityProfile2RoleAssignment> _roleAssignments;
        private ICollection<TenantSecurityProfile2RoleGroupAssignment> _roleGroupAssignments;

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="TenantSecurityProfile" /> is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Enabled { get; set; }


        /// <summary>
        ///     Gets or sets the role group assignments.
        /// </summary>
        public ICollection<TenantSecurityProfile2RoleGroupAssignment> RoleGroupAssignments
        {
            get => _roleGroupAssignments ??
                   (_roleGroupAssignments = new Collection<TenantSecurityProfile2RoleGroupAssignment>());
            set => _roleGroupAssignments = value;
        }


        /// <summary>
        ///     Gets or sets the role assignents.
        /// </summary>
        /// <value>
        ///     The role assignents.
        /// </value>
        public ICollection<TenantSecurityProfile2RoleAssignment> RoleAssignents
        {
            get => _roleAssignments ?? (_roleAssignments = new Collection<TenantSecurityProfile2RoleAssignment>());
            set => _roleAssignments = value;
        }


        /// <summary>
        ///     Gets or sets the permissions assignments.
        /// </summary>
        /// <value>
        ///     The permissions assignments.
        /// </value>
        public ICollection<TenantSecurityProfile2PermissionAssignment> PermissionsAssignments
        {
            get => _permissionsAssignments ??
                   (_permissionsAssignments = new Collection<TenantSecurityProfile2PermissionAssignment>());
            set => _permissionsAssignments = value;
        }


        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public virtual string Description { get; set; }
    }
}