// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     An Assignment Join object between a parent
    ///     <see cref="TenantSecurityProfile" /> and a child
    ///     <see cref="TenantSecurityProfileRole" />
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.TenantFKRecordStatedTimestampedNoIdEntityBase" />
    public class TenantSecurityProfile2RoleAssignment : TenantFKRecordStatedTimestampedNoIdEntityBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TenantSecurityProfile2RoleAssignment" /> class.
        /// </summary>
        public TenantSecurityProfile2RoleAssignment()
        {
            AssignmentType = AssignmentType.Add;
        }

        /// <summary>
        ///     Gets or sets the FK
        ///     of the parent
        ///     <see cref="TenantSecurityProfile" />
        /// </summary>
        public Guid ProfileFK { get; set; }

        /// <summary>
        ///     Gets or sets the
        ///     parent
        ///     <see cref="TenantSecurityProfile" />
        /// </summary>
        public TenantSecurityProfile Profile { get; set; }


        /// <summary>
        ///     Gets or sets the FK
        ///     of the
        ///     <see cref="TenantSecurityProfileRole" />
        ///     to associate to the parent
        ///     <see cref="TenantSecurityProfile" />
        /// </summary>
        public Guid RoleFK { get; set; }

        /// <summary>
        ///     Gets or sets
        ///     the
        ///     <see cref="TenantSecurityProfileRole" />
        ///     to associate to the parent
        ///     <see cref="TenantSecurityProfile" />
        /// </summary>
        public TenantSecurityProfileRole Role { get; set; }

        /// <summary>
        ///     Gets or sets the type of the assignment (add/remove).
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }
}