using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.KWMODULE.Shared.Models.Messages
{
    /// <summary>
    ///     A DTO for the <see cref="LinkedExampleDto" />
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDataClassification" />
    public class LinkedExampleDto :
        IHasGuidId,
        IHasTitleAndDescription,
        IHasDataClassificationFK
    {
        /// <summary>
        ///     Gets or sets the data classification of this entity.
        /// </summary>
        public DataClassificationDto DataClassification { get; set; }

        /// <summary>
        ///     Gets or sets the FK of the
        ///     data classification.
        /// </summary>
        public NZDataClassification DataClassificationFK { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }
    }
}