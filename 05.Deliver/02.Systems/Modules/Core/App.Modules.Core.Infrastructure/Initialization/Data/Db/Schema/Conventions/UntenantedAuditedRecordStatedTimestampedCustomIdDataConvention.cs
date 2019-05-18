namespace App.Modules.Core.Infrastructure.Db.Schema.Conventions
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Shared.Models;
    using App.Modules.Core.Shared.Models.Entities;

    public class UntenantedAuditedRecordStatedTimestampedCustomIdDataConvention
    {

        public virtual void Define<T,TId>(ModelBuilder modelBuilder, ref int order, Func<int, int> injectedPropertyDefs = null)
            where T : class, IHasId<TId>, IHasTimestamp, IHasInRecordAuditability, IHasRecordState
            where TId: struct
        {
            modelBuilder.DefineCustomId<T, TId>(ref order);

            modelBuilder.DefineTimestampedAuditedRecordStated<T>(ref order);

        }
    }

}