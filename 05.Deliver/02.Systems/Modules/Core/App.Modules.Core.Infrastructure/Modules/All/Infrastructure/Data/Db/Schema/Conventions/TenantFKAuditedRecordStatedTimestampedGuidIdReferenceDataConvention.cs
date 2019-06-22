// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema.Conventions
{
    /// <summary>
    ///     Adds the definition of
    ///     Enabled, Text, DisplayOrderHint, DisplayStyleHint
    ///     on top of
    ///     TenantFK (but not a Tenant object)
    ///     on top of
    ///     Id, Timestamp, RecordState, CreatedOn/By, LastModifiedOn/By, DeletedOn/By
    /// </summary>
    /// <seealso cref="TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention" />
    public class TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataConvention
    {
        public void Define<T>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasDisplayableReferenceData, IHasTenantFK, IHasGuidId, IHasId<Guid>, IHasTimestamp,
            IHasInRecordAuditability, IHasRecordState
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, Guid>(ref order);

            modelBuilder.DefineTimestampedRecordStated<T>(ref order);

            modelBuilder.DefineDisplayableReferenceData<T>(ref order);
        }
    }
}