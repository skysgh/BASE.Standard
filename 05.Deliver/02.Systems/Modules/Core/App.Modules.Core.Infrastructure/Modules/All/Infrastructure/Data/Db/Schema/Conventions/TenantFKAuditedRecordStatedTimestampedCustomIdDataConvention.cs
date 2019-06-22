﻿// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema.Conventions
{
    /// <summary>
    ///     Base Schema Definition
    ///     for any Tenant specific Entity.
    ///     <para>
    ///         Adds the definition of
    ///         TenantFK (but not a Tenant object)
    ///         on top of
    ///         Id, Timestamp, RecordState, CreatedOn/By, LastModifiedOn/By, DeletedOn/By
    ///     </para>
    /// </summary>
    /// <seealso cref="UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention" />
    public class TenantFKAuditedRecordStatedTimestampedCustomIdDataConvention
    {
        public void Define<T, TId>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTenantFK, IHasId<TId>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
            where TId : struct
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineTimestampedRecordStated<T>(ref order);
        }
    }
}