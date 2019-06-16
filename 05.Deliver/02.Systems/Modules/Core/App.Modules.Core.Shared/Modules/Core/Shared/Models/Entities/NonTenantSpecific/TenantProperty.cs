using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasOwnerFK" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasKey" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasValue{String}" />
    public class TenantProperty 
        : UntenantedRecordStatedTimestampedGuidIdEntityBase
            , IHasOwnerFK
            , IHasKey
    ,IHasValue<string>
    {
        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" /></para>.
        /// </summary>
        public virtual string Key { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Gets or sets the tenant fk.
        /// </summary>
        /// <value>
        /// The tenant fk.
        /// </value>
        public virtual Guid TenantFK { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public Guid GetOwnerFk()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            return TenantFK;
        }

    }
}