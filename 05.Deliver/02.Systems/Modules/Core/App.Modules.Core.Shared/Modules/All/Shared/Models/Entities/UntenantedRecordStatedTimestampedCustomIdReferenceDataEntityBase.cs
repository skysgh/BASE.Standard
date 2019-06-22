// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    ///     <para>
    ///         Note that this Base runs parrallel to
    ///         <see cref="UntenantedRecordStatedTimestampedGuidIdReferenceDataEntityBase" />
    ///         (inheritence line is based on Id Type).
    ///     </para>
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class UntenantedRecordStatedTimestampedCustomIdReferenceDataEntityBase<TId> :
            UntenantedRecordStatedTimestampedCustomIdEntityBase<TId>,
            IHasEnabled,
            IHasDisplayableReferenceData
        //IHasTitleAndDescription,
        //IHasDisplayOrderHint,
        //IHasDisplayStyleHint
        where TId : struct
    {
        private bool _enabled = true;

        /// <summary>
        ///     Gets or sets the model's title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Gets or sets the model's description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Higher numbers are displayed at top.
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }

        /// <summary>
        ///     A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        /// </summary>
        /// <value>
        ///     The display style hint.
        /// </value>
        public virtual string DisplayStyleHint { get; set; }


        /// <summary>
        ///     Gets or sets a value indicating whether this
        ///     <see cref="UntenantedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}" /> is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }
    }
}