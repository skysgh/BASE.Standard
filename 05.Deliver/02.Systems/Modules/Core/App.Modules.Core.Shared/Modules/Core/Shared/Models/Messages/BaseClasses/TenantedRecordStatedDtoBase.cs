// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     Base class for DTO objects.
    ///     <para>
    ///         Most DTO messages developed in Modules -- bar Core --
    ///         will inherit from this base class.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTenantFK" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    public abstract class TenantedRecordStatedDtoBase
        : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
            IHasTenantFK
            , IHasRecordState
    {
        /// <summary>
        ///     Gets or sets the logical state of the record:
        /// </summary>
        /// <value>
        ///     The state of the record.
        /// </value>
        public virtual RecordPersistenceState RecordState { get; set; }

        /// <summary>
        ///     Gets or sets the FK of the Tenancy this mutable model belongs to.
        ///     <para>
        ///         When referenced from within the Core Module's DbContext
        ///         the TenantFK is logically enforced by the database (normalized),
        ///         whereas from other DbContexts it is not.
        ///         The Logic behind this choice stems from the understanding that
        ///         a Business Model (eg: Foo) has no need to Navigate to a Tenant to which
        ///         the Business Model belongs. It's actually a different Domain Context (System).
        ///         The above logic is actually enforced in EF's natural constraint that a Model
        ///         belong to only one DbContext (one Bounded Context).
        ///         The advantage is natural Domain Separation. In the same way as we trust external
        ///         IdP Services to manage Users.
        ///         THe consideration is that Application logic is required to ensure TenantId
        ///         is applied at the Application Logic tier, as it is not enforced at the database.
        ///         TenantFK is not required on anything else but the TenantProperties entity, and Users
        ///         in order to know which Tenant a user is allowed to be a member of.
        ///     </para>
        /// </summary>
        /// <value>
        ///     The tenant fk.
        /// </value>
        public virtual Guid TenantFK { get; set; }
    }
}