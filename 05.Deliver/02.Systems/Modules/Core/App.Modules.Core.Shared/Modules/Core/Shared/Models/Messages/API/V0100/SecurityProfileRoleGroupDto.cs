using System;
using System.Collections.Generic;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// DTO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class SecurityProfileRoleGroupDto 
        : IHasGuidId, IHasTitle, IHasDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityProfileRoleGroupDto"/> class.
        /// </summary>
        public SecurityProfileRoleGroupDto()
        {
            this.Id = GuidFactory.NewGuid();

        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the model.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the optional displayed description.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        public ICollection<SecurityProfileRoleGroupDto> Groups { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public ICollection<SecurityProfileRoleDto> Roles { get; set; }


    }
}
