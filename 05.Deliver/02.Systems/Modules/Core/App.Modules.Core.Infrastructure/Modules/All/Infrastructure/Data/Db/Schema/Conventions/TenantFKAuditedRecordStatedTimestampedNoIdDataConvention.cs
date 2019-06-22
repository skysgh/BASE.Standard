// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema.Conventions
{
    public class TenantFKAuditedRecordStatedTimestampedNoIdDataConvention
    {
        public virtual void Define<T>(ModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTenantFK, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            //ID should go up here.... But will be before.

            modelBuilder.DefineTimestampedRecordStated<T>(ref order, injectedPropertyDefs);
        }
    }
}