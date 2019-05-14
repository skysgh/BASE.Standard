using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Infrastructure.Db.Interception.Implementations
{
    using System;
    using App.Core.Infrastructure.Db.Interception.Implementations.Base;

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
    /// <seealso cref="IHasTenantFK" />
    public class
        HasTenantFKAuditabilityDbContextPreCommitStrategy : DbContextPreCommitProcessingStrategyBase<IHasTenantFK>
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly ITenantService _tenantService;

        public HasTenantFKAuditabilityDbContextPreCommitStrategy(IUniversalDateTimeService dateTimeService,
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, ITenantService tenantService) : base(dateTimeService, principalService,
            EntityState.Added)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._tenantService = tenantService;
        }

        protected override void PreProcessEntity(IHasTenantFK entity)
        {
            if (entity.TenantFK.Equals(Guid.Empty))
            {
                try
                {
                    entity.TenantFK = this._tenantService.CurrentTenant.Id;
                }
                catch
                {
                    this._diagnosticsTracingService.Trace(TraceLevel.Error, "TODO: Tenant management has to be sorted out.");
                }
            }
        }
    }
}