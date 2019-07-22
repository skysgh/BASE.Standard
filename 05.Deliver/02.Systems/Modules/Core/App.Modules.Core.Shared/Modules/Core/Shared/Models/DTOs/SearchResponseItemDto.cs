// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     DTO of a <see cref="SearchResponseItem" />
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitle" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDescription" />
    public class SearchResponseItemDto :
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        //IHasGuidId, IHasRecordState, 
        IHasTitle, IHasDescription
    {
        /// <summary>
        ///     Gets or sets the source type key.
        /// </summary>
        /// <value>
        ///     The source type key.
        /// </value>
        public virtual string SourceTypeKey { get; set; }

        //[Key]
        /// <summary>
        ///     Gets or sets the source identifier.
        /// </summary>
        /// <value>
        ///     The source identifier.
        /// </value>
        public virtual string SourceIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets the image URL.
        /// </summary>
        /// <value>
        ///     The image URL.
        /// </value>
        public virtual string ImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public virtual string Title { get; set; }
    }
}