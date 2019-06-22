// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A model of the Join object required to associate
    ///     <see cref="TenantSecurityProfileRoleGroup" />s to parent
    ///     <see cref="TenantSecurityProfile" /> objects.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.TenantFKRecordStatedTimestampedNoIdEntityBase" />
    public class TenantSecurityProfile2RoleGroupAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TenantSecurityProfile2RoleGroupAssignment" /> class.
        /// </summary>
        public TenantSecurityProfile2RoleGroupAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        /// <summary>
        ///     Gets or sets the FK
        ///     of the <see cref="TenantSecurityProfile" />
        ///     this <see cref="TenantSecurityProfileRoleGroup" />
        ///     is assigned to.
        /// </summary>
        public Guid ProfileFK { get; set; }

        /// <summary>
        ///     Gets or sets the
        ///     <see cref="TenantSecurityProfile" />
        ///     this <see cref="TenantSecurityProfileRoleGroup" />
        ///     is assigned to.
        /// </summary>
        public TenantSecurityProfile Profile { get; set; }

        /// <summary>
        ///     Gets or sets the
        ///     FK of the <see cref="TenantSecurityProfileRoleGroup" />
        ///     being associated to the parent
        ///     <see cref="TenantSecurityProfile" />
        /// </summary>
        public Guid RoleGroupFK { get; set; }

        /// <summary>
        ///     Gets or sets the
        ///     <see cref="TenantSecurityProfileRoleGroup" />
        ///     being associated to the parent
        ///     <see cref="TenantSecurityProfile" />
        /// </summary>
        public TenantSecurityProfileRoleGroup RoleGroup { get; set; }

        /// <summary>
        ///     Gets or sets the type of the assignment (Adding/Removing)
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }
}