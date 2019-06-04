using System;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions
{
    public class  UntenantedAuditedRecordStatedTimestampedNoIdDataConvention
    {

        public virtual void Define<T>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasTimestamp, 
            //IHasInRecordAuditability, 
            IHasRecordState
        {



            modelBuilder.DefineTimestampedRecordStated<T>(ref order, injectedPropertyDefs);

        }
    }

}