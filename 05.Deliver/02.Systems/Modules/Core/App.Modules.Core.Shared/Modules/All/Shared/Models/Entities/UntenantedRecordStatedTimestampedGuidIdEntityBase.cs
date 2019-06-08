using System;
using App.Modules.All.Shared.Factories;

namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="UntenantedRecordStatedTimestampedCustomIdEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// <para>
    /// Implements
    /// <see cref="IHasGuidId"/>,
    /// <see cref="IHasId{T}"/>,
    /// <see cref="IHasTimestamp"/>
    /// <see cref="IHasInRecordAuditability"/>
    /// <see cref="IHasRecordState"/>
    /// </para>    
    /// </summary>
    /// <seealso cref="Guid" />
    /// <seealso cref="IHasGuidId" />
    /// <seealso cref="IHasTimestamp" />
    /// <seealso cref="IHasInRecordAuditability" />
    /// <seealso cref="IHasRecordState" />
    public abstract class UntenantedRecordStatedTimestampedGuidIdEntityBase : 
        UntenantedRecordStatedTimestampedCustomIdEntityBase<Guid>,
        IHasGuidId 
        /*Enherited: IHasId<Guid>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState*/
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UntenantedRecordStatedTimestampedGuidIdEntityBase"/> class.
        /// </summary>
        protected UntenantedRecordStatedTimestampedGuidIdEntityBase()
        {
            this.Id = GuidFactory.NewGuid();
        }
   }
}