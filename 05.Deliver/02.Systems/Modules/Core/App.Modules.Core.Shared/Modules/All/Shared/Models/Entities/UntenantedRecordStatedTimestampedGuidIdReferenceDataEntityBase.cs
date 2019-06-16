using App.Modules.All.Shared.Factories;

namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="UntenantedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// </summary>
    public abstract class UntenantedRecordStatedTimestampedGuidIdReferenceDataEntityBase :
        UntenantedRecordStatedTimestampedGuidIdEntityBase,
        /*Enherited: IHasGuidId, IHasId<Guid>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState*/
        IHasDisplayableReferenceData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UntenantedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/> class.
        /// <para>
        /// Invokes the <see cref="GuidFactory"/> to set the Id value.
        /// </para>
        /// </summary>
        protected UntenantedRecordStatedTimestampedGuidIdReferenceDataEntityBase()
        {
            Id = GuidFactory.NewGuid();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UntenantedRecordStatedTimestampedGuidIdReferenceDataEntityBase" /> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the model's title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the model's description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Higher numbers are displayed at top.
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }

        /// <summary>
        /// A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        /// </summary>
        public virtual string DisplayStyleHint { get; set; }
    }


}
