using System;
using App.Modules.All.Shared.Models;
using App.Modules.KWMODULE.Shared.Models.Entities;

namespace App.Modules.KWMODULE.Shared.Models.Messages
{
    /// <summary>
    /// DTO for the <see cref="Example"/> entity.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    public class ExampleDto : IHasGuidId, IHasTitleAndDescription
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

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
