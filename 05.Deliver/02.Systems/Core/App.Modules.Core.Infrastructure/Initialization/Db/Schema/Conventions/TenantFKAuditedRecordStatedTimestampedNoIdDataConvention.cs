namespace App.Modules.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Shared.Models;



    public class  TenantFKAuditedRecordStatedTimestampedNoIdDataConvention
    {

        public virtual void Define<T>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTenantFK, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {
            modelBuilder.DefineTenantFK<T>(ref order);

            //ID should go up here.... But will be before.

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order, injectedPropertyDefs);

        }
    }

}