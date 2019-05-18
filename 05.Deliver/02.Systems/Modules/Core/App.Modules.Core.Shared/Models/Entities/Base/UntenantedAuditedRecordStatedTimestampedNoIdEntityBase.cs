namespace App.Modules.Core.Shared.Models.Entities
{
    using System;

    public abstract class UntenantedAuditedRecordStatedTimestampedNoIdEntityBase : IHasTimestamp,
        IHasInRecordAuditability, IHasRecordState
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


        //TODO: Convert to DateTimeOffset?
        public virtual DateTimeOffset? CreatedOnUtc { get; set; }
        public virtual string CreatedByPrincipalId { get; set; }
        public virtual DateTimeOffset? LastModifiedOnUtc { get; set; }
        public virtual string LastModifiedByPrincipalId { get; set; }
        public virtual DateTimeOffset? DeletedOnUtc { get; set; }
        public virtual string DeletedByPrincipalId { get; set; }



    }
}