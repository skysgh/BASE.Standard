// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema.Conventions
{
    public class UntenantedAuditedRecordStatedTimestampedCustomIdDataConvention
    {
        public virtual void Define<T, TId>(ModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasId<TId>, IHasTimestamp,
            //IHasInRecordAuditability, 
            IHasRecordState
            where TId : struct
        {
            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineTimestampedRecordStated<T>(ref order);
        }
    }
}