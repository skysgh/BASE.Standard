using System;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions
{
    public class TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataConvention
    {
        public virtual void Define<T, TId>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasDisplayableReferenceData, IHasTenantFK, IHasId<TId>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
            where TId : struct
        {
            // Invoke Helpers:

            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineTimestampedRecordStated<T>(ref order);

            modelBuilder.DefineDisplayableReferenceData<T>(ref order);
            

        }


    }
}