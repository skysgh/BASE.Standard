using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Shared.Models;
    using App.Modules.Core.Shared.Models.Entities;

    public class TenantFKAuditedRecordStatedTimestampedCustomIdReferenceDataConvention
    {
        public virtual void Define<T, TId>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasDisplayableReferenceData, IHasTenantFK, IHasId<TId>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
            where TId : struct
        {
            // Invoke Helpers:

            modelBuilder.DefineTenantFK<T>(ref order);

            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);

            modelBuilder.DefineDisplayableReferenceData<T>(ref order);
            

        }


    }
}