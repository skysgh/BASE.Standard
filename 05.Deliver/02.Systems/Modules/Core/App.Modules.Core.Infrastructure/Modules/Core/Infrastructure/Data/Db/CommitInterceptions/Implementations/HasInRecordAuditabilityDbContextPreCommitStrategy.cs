using App.Modules.All.Infrastructure.Data.Db.CommitInterceptions;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.CommitInterceptions.Implementations
{
    /// <summary>
    /// 
    /// <para>
    /// Invoked when the Request is wrapping up, 
    /// and invokes <see cref="IUnitOfWorkService"/>'s 
    /// commit operation, 
    /// which in turn invokes each DbContext's SaveChanges, 
    /// which are individually overridden, to in turn 
    /// invoke <see cref="IDbContextPreCommitService"/>
    /// which invokes 
    /// all PreCommitProcessingStrategy implementations, such 
    /// as this.
    /// </para>
    /// </summary>
    /// <seealso cref="IHasInRecordAuditability" />
    public class
        HasInRecordAuditabilityDbContextPreCommitStrategy :
            DbContextPreCommitProcessingStrategyBase<IHasInRecordAuditability>
    {
        public HasInRecordAuditabilityDbContextPreCommitStrategy(IUniversalDateTimeService dateTimeService,
            IPrincipalService principalService) :
            base(
                dateTimeService, 
                principalService,
                EntityState.Added,
            EntityState.Modified, EntityState.Deleted)
        {
        }

        protected override void PreProcessEntity(IHasInRecordAuditability entity)
        {
            if (!entity.CreatedOnUtc.HasValue)
            {
                entity.CreatedOnUtc = this._dateTimeService.NowUtc().UtcDateTime;
            }
            if (entity.CreatedByPrincipalId == null)
            {
                entity.CreatedByPrincipalId = this._principalService.CurrentPrincipalIdentifier ?? "ANON";
            }
            entity.LastModifiedOnUtc = this._dateTimeService.NowUtc().UtcDateTime;
            entity.LastModifiedByPrincipalId = this._principalService.CurrentPrincipalIdentifier ?? "ANON";

            if (IsEntityStateSet(entity, EntityState.Deleted))
            {
                entity.DeletedOnUtc = this._dateTimeService.NowUtc().UtcDateTime;
                entity.DeletedByPrincipalId = this._principalService.CurrentPrincipalIdentifier ?? "ANON";
            }
        }
    }
}