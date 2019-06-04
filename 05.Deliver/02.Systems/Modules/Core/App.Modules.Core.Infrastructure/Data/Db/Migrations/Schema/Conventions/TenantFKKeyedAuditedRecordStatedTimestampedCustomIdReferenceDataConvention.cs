using System;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions
{
    /// <summary>
    /// Adds the definition of 
    /// Enabled, Key, Text, DisplayOrderHint, DisplayStyleHint
    /// on top of
    /// TenantFK (but not a Tenant object)
    /// on top of
    /// Id, Timestamp, RecordState, CreatedOn/By, LastModifiedOn/By, DeletedOn/By
    /// <para>
    /// NOTE:
    /// I think the deciesion to not enherit from TenantedReferenceDataConventions 
    /// was only done to control the order of columns (so that Key is *after* 
    /// Enabled, rather than before). 
    /// Feels a bit dumb now...
    /// </para>
    /// </summary>
    /// <seealso cref="TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention" />
    public class TenantFKKeyedAuditedRecordStatedTimestampedCustomIdReferenceDataConvention
    {
        public void Define<T,TId>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasKey, IHasDisplayableReferenceData, IHasTenantFK, IHasId<TId>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
            where TId: struct
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineUniqueKey<T>(ref order);

            modelBuilder.DefineTimestampedRecordStated<T>(ref order);

            modelBuilder.DefineDisplayableReferenceData<T>(ref order);







        }
    }
}