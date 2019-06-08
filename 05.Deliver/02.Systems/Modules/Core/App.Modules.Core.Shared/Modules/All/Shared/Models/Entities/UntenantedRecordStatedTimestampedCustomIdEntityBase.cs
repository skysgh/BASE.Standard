namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="UntenantedRecordStatedTimestampedGuidIdEntityBase"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// <para>
    /// Implements
    /// <see cref="IHasId{T}"/>,
    /// <see cref="IHasTimestamp"/>
    /// <see cref="IHasInRecordAuditability"/>
    /// <see cref="IHasRecordState"/>
    /// </para>
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="IHasId{T}" />
    /// <seealso cref="IHasTimestamp" />
    /// <seealso cref="IHasInRecordAuditability" />
    /// <seealso cref="IHasRecordState" />
    public abstract class UntenantedRecordStatedTimestampedCustomIdEntityBase<TId> : 
        UntenantedRecordStatedTimestampedNoIdEntityBase,
        IHasId<TId>
        /* Inherited:  IHasTimestamp, IHasInRecordAuditability, IHasRecordState */
        where TId : struct
    {
        protected UntenantedRecordStatedTimestampedCustomIdEntityBase()
        {
            //REMEMBER: ID MUST BE PROVIDED IN THIS CASE...
        }

        public virtual TId Id { get; set; }
    }
}