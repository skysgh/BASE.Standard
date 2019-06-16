using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// A returned Search object.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordIdentifier" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasImageUrl" />
    public class SearchResponseItem:
        IHasRecordIdentifier,
        IHasTitleAndDescription, 
        IHasImageUrl
    {
        /// <summary>
        /// Gets or sets the identifier of the record identifier.
        /// </summary>
        public virtual string RecordTypeIdentifier { get; set; }
        /// <summary>
        /// Gets or sets id of the record.
        /// </summary>
        public virtual string RecordIdentifier { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public virtual string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }


        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        public virtual string ImageUrl { get; set; }
    }
}