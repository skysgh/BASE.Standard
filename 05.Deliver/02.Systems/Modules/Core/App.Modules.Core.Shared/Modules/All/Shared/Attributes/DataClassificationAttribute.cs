

namespace App.Modules.All.Shared.Attributes
{
    using App.Modules.Core.Shared.Models.Entities;

    /// <summary>
    /// Attribute to attach to Models to *Hint* (it depends on additional factors too, but it's a start) 
    /// as to the risks associated to exposure.
    /// </summary>
    public class DataClassificationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataClassificationAttribute"/> class.
        /// </summary>
        /// <param name="dataClassification">The data classification.</param>
        public DataClassificationAttribute(NZDataClassification dataClassification)
        {
            this.DataClassification = dataClassification;
        }
        /// <summary>
        /// Gets or sets the data classification
        /// to apply to an entity.
        /// </summary>
        /// <value>
        /// The data classification.
        /// </value>
        public NZDataClassification DataClassification { get; set; }
    }
}
