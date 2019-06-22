﻿// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Models.Entities
{
    /// <summary>
    ///     <para>
    ///         Note that this Base runs parrallel to
    ///         <see cref="TenantFKRecordStatedTimestampedGuidIdEntityBase" />
    ///         (inheritance line is based on Id Type).
    ///     </para>
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class TenantFKRecordStatedTimestampedCustomIdEntityBase<TId> :
        UntenantedRecordStatedTimestampedCustomIdEntityBase<TId>,
        /* Enherited: , IHasTimestamp, IHasInRecordAuditability, IHasRecordState */
        IHasTenantFK
        where TId : struct
    {
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
        public virtual Guid TenantFK { get; set; }
    }
}