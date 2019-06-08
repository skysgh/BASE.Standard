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
        protected UntenantedRecordStatedTimestampedGuidIdReferenceDataEntityBase()
        {
            Id = GuidFactory.NewGuid();
        }

        public virtual bool Enabled { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        /// <summary>
        /// Higher numbers are displayed at top.
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }

        // A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        public virtual string DisplayStyleHint { get; set; }
    }


}
