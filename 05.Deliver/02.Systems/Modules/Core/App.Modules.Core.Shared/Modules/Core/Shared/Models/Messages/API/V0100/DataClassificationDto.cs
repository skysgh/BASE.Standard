using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IHasId{NZDataClassification}" />
    [Serializable]
    public class DataClassificationDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
    : IHasId<NZDataClassification>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// <para>
        /// Decorating this property with [JsonProperty(PropertyName = "id")]
        /// This is needed for entities that will be persisted using DocumentDB.
        /// I'm so far resisting putting a reference on Newtonsoft's library, because
        /// it would cause all downstream assemblies to Reference this lib. Not good practices
        /// if it can be avoided.
        /// IH
        /// </para>
        /// </summary>
        public virtual NZDataClassification Id { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DataClassificationDto"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Enabled { get; set; }
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
        /// Gets or sets the display order hint.
        /// </summary>
        /// <value>
        /// The display order hint.
        /// </value>
        public virtual int DisplayOrderHint { get; set; }
        /// <summary>
        /// Gets or sets the display style hint.
        /// </summary>
        /// <value>
        /// The display style hint.
        /// </value>
        public virtual string DisplayStyleHint { get; set; }
    }


}
