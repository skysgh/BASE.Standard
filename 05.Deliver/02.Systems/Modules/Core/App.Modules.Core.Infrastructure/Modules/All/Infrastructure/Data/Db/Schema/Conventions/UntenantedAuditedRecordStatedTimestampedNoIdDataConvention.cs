// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema.Conventions
{
    public class UntenantedAuditedRecordStatedTimestampedNoIdDataConvention
    {
        public virtual void Define<T>(ModelBuilder modelBuilder, ref int order,
            Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTimestamp,
            //IHasInRecordAuditability, 
            IHasRecordState
        {
            modelBuilder.DefineTimestampedRecordStated<T>(ref order, injectedPropertyDefs);
        }
    }
}