using System;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions
{
    public class  TenantFKAuditedRecordStatedTimestampedNoIdDataConvention
    {

        public virtual void Define<T>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTenantFK, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            //ID should go up here.... But will be before.

            modelBuilder.DefineTimestampedRecordStated<T>(ref order, injectedPropertyDefs);

        }
    }

}