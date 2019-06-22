// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A tenant-specific group of Roles used to define a <see cref="TenantSecurityProfile" />.
    /// </summary>
    public class TenantSecurityProfileRoleGroup : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasTitle,
        IHasTitleAndDescription, IHasOptionalParentFK, IHasParent<TenantSecurityProfileRoleGroup>
    {
        private ICollection<TenantSecurityProfileRoleGroup2RoleAssignment> _roleAssignments;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TenantSecurityProfileRoleGroup" /> class.
        /// </summary>
        public TenantSecurityProfileRoleGroup()
        {
            Enabled = true;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="TenantSecurityProfileRoleGroup" /> is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }


        /// <summary>
        ///     Gets or sets the assigned roles.
        /// </summary>
        /// <value>
        ///     The role assignments.
        /// </value>
        public ICollection<TenantSecurityProfileRoleGroup2RoleAssignment> RoleAssignments
        {
            get => _roleAssignments ??
                   (_roleAssignments = new Collection<TenantSecurityProfileRoleGroup2RoleAssignment>());
            set => _roleAssignments = value;
        }

        /// <summary>
        ///     Gets or sets the FK
        ///     of an optional
        ///     parent.
        /// </summary>
        public Guid? ParentFK { get; set; }

        /// <summary>
        ///     Gets or sets the optional parent object.
        /// </summary>
        public TenantSecurityProfileRoleGroup Parent { get; set; }

        /// <summary>
        ///     Gets or sets the title of the model.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        //TODO: Could get large. Do we want this? Maybe it should only be on Account.
        //public ICollection<Account> Accounts { get; set; } 
    }
}