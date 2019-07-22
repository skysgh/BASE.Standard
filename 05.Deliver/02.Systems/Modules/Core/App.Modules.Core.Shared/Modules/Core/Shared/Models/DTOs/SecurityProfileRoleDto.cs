// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     TODO: DTO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class SecurityProfileRoleDto
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : IHasGuidId,
            IHasTitle,
            IHasDescription
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SecurityProfileRoleDto" /> class.
        /// </summary>
        public SecurityProfileRoleDto()
        {
            Id = GuidFactory.NewGuid();
        }

        /// <summary>
        ///     Gets or sets the permissions.
        /// </summary>
        /// <value>
        ///     The permissions.
        /// </value>
        public ICollection<SecurityProfilePermissionDto> Permissions { get; set; }

        /// <summary>
        ///     Gets or sets the optional displayed description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the title of the model.
        /// </summary>
        public string Title { get; set; }
    }
}