using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models.Entities
{
    public abstract class UntenantedRecordStatedTimestampedNoIdEntityBase : 
        IHasTimestamp,
        IHasRecordState
    {
        /// <summary>
        ///     Gets or sets the datastore concurrency check timestamp.
        ///     <para>
        ///         Note that this is filled in when persisted in the db --
        ///         so it's usable to determine whether Record is New or not.
        ///     </para>
        /// </summary>
        public virtual byte[] Timestamp { get; set; }

        public virtual RecordPersistenceState RecordState { get; set; }
    }
}