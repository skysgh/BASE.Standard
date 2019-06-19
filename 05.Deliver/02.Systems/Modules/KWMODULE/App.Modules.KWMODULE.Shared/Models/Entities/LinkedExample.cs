using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.KWMODULE.Shared.Models.Entities
{
    /// <summary>
    /// An example of a more complex Entity.
    /// <para>
    /// Note that it has a Navigation Property
    /// to a <see cref="DataClassification"/>
    /// entity defined in the Core logical module.
    /// </para>
    /// <para>
    /// It is important to notice that the entity
    /// in effect is comprised of entities from
    /// two different Logical Modules, and therefore
    /// two different Schemas.
    /// </para>
    /// <para>
    /// This is why the Controller used is the
    /// <c>JoinedModuleDbContext</c> (see this Module's
    /// Infrastructure assembly), and not just
    /// the <c>ModuleDbContext</c> of this logical module, or
    /// the <c>ModuleDbCOntext</c> of the Core logical module.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDataClassification" />
    public class LinkedExample 
        : UntenantedRecordStatedTimestampedGuidIdEntityBase,
            IHasDataClassification
    {
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


        /// <summary>
        /// Gets or sets the FK of the
        /// data classification.
        /// </summary>
        public NZDataClassification DataClassificationFK { get; set; }
        /// <summary>
        /// Gets or sets the data classification of this entity.
        /// </summary>
        public DataClassification DataClassification { get; set; }
    }
}
