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
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UntenantedRecordStatedTimestampedCustomIdEntityBase{TId}"/> class.
        /// </summary>
        protected UntenantedRecordStatedTimestampedCustomIdEntityBase()
        {
            //REMEMBER: ID MUST BE PROVIDED IN THIS CASE...
        }

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
        public virtual TId Id { get; set; }
    }
}