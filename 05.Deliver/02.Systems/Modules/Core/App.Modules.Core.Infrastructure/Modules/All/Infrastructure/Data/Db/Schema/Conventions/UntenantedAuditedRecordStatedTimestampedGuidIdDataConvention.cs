using System;
using App.Modules.All.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema.Conventions
{
    public class UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention
    {
        public virtual void Define<T>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasGuidId, IHasId<Guid>, IHasTimestamp, 
            //IHasInRecordAuditability, 
            IHasRecordState
        {

            modelBuilder.DefineCustomId<T, Guid>(ref order);

            modelBuilder.DefineTimestampedRecordStated<T>(ref order);


        }
    }


}