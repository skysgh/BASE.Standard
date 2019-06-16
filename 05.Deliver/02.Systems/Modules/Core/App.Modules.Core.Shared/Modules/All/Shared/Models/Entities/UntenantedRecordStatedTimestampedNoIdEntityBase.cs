using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTimestamp" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
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

        /// <summary>
        /// Gets or sets the logical state of the record.
        /// </summary>
        public virtual RecordPersistenceState RecordState { get; set; }
    }
}