namespace App.Modules.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Shared.Models;



    public class  UntenantedAuditedRecordStatedTimestampedNoIdDataConvention
    {

        public virtual void Define<T>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {



            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order, injectedPropertyDefs);

        }
    }

}