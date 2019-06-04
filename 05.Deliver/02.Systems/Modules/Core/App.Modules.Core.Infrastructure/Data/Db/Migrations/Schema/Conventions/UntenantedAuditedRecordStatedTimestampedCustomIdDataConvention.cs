using System;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions
{
    public class UntenantedAuditedRecordStatedTimestampedCustomIdDataConvention
    {

        public virtual void Define<T,TId>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasId<TId>, IHasTimestamp, 
            //IHasInRecordAuditability, 
            IHasRecordState
            where TId: struct
        {
            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineTimestampedRecordStated<T>(ref order);

        }
    }

}