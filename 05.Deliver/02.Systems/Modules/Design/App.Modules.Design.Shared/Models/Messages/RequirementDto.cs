// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Design.Shared.Models.Entities.Enums;

namespace App.Modules.Design.Shared.Models.Messages
{


    /// <summary>
    /// Creates a Dto
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    public class RequirementDto
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : IHasGuidId, IHasTitleAndDescription
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the ISO-25010 quality.
        /// </summary>
        /// <value>
        /// The quality.
        /// </value>
        public ISO25010 Quality { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

    }
}