// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A record of a remote IdP
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTimestamp" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasKey" />
    public class IdentityProvider : IHasGuidId, IHasTimestamp, IHasRecordState, IHasKey
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IdentityProvider" /> class.
        /// </summary>
        public IdentityProvider()
        {
            GuidFactory.NewGuid();
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string ProviderKey { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string UserId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the unique key of the object,
        ///     by which it is indexed when persisted
        ///     (in additional to any primary Id).
        ///     <para>
        ///         Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" />
        ///     </para>
        ///     .
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the logical state of the record:
        /// </summary>
        /// <value>
        ///     The state of the record.
        /// </value>
        public RecordPersistenceState RecordState { get; set; }

        /// <summary>
        ///     Gets or sets the datastore concurrency check timestamp.
        ///     <para>
        ///         Note that this is filled in when persisted in the db --
        ///         so it's usable to determine whether Record is New or not.
        ///     </para>
        /// </summary>
        public byte[] Timestamp { get; set; }
    }
}