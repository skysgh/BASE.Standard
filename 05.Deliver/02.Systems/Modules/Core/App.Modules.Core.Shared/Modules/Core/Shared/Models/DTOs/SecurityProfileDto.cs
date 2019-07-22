// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     DTO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class SecurityProfileDto
        : IHasGuidId,
            IHasKey
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityProfileDto" /> class.
        /// </summary>
        public SecurityProfileDto()
        {
            GuidFactory.NewGuid();
        }

        /// <summary>
        ///     Gets or sets the account groups.
        /// </summary>
        /// <value>
        ///     The account groups.
        /// </value>
        public ICollection<SecurityProfileRoleGroupDto> AccountGroups { get; set; }

        /// <summary>
        ///     Gets or sets the roles.
        /// </summary>
        /// <value>
        ///     The roles.
        /// </value>
        public ICollection<SecurityProfileRoleDto> Roles { get; set; }

        /// <summary>
        ///     Gets or sets the permissions assignments.
        /// </summary>
        /// <value>
        ///     The permissions assignments.
        /// </value>
        public ICollection<SecurityProfileSecurityProfilePermissionAssignmentDto> PermissionsAssignments { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the unique key of the object,
        ///     by which it is indexed when persisted
        ///     (in additional to any primary Id).
        ///     <para>
        ///         Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" />
        ///     </para>
        ///     .
        /// </summary>
        public string Key { get; set; }
    }
}