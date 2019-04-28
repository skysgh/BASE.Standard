namespace App.Modules.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Shared.Models;
    using App.Modules.Core.Shared.Models.Entities;

    public class UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention
    {
        public virtual void Define<T>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasGuidId, IHasId<Guid>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
        {

            modelBuilder.DefineCustomId<T, Guid>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);


        }
    }


}