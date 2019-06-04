
using App.Modules.Core.Infrastructure.ExtensionMethods;

namespace App.Modules.Core.AppFacade.Controllers.Api.odata.Base
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using App.Modules.Core.AppFacade.Services;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Models;
    using App.Modules.Core.Models.Entities;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.OData;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Just about every controller, whatever module,  
    /// *should* inherit in one way or another
    /// from this base controller.
    /// <para>
    /// The advantages include:
    /// * has a built in concept of Logical Entity and exposed Dto Message equivalent 
    ///   of that Entity, as well as the logic to leverage AutoMapper to pass the linq
    ///   through the layers. ie, the Magic of ProjectTo.
    /// * only one base class that needs to be updated to .NET Core when we get there.
    /// * ensures that all classes are injected with an implementation of 
    /// <see cref="IDiagnosticsTracingService"/> and <see cref="IPrincipalService"/>
    /// so there is absolutely no excuse for poor diagnostics logs, or security...
    /// (that said, still don't trust developers rushing to meet deadlines to take 
    /// care of ISO-25010/Maintainability or ISO-25010/Security, so we handle 
    /// Security and Logging as GLobal Filters anyway).
    /// </para>
    /// </summary>
    /// <seealso cref="System.Web.OData.ODataController" />
    public abstract class MappedCommonODataControllerBase<TDbContext, TEntity, TDto>
        : CommonODataControllerBase
        where TDbContext : DbContext
        where TEntity : class, new()
        where TDto : class, new()

    {
        //protected /*readonly*/ string _dbContextIdentifier;

        protected readonly ITenantService _tenantService;
        protected readonly DbContext _dbContext;
        protected readonly IObjectMappingService _objectMappingService;
        protected readonly ISecureAPIMessageAttributeService _secureApiMessageAttribute;

        protected MappedCommonODataControllerBase(
            IControllerCommonServicesService controllerCommonServicesService,
            DbContext dbContext
            ) :

            base(controllerCommonServicesService.DiagnosticsTracingService,
                controllerCommonServicesService.PrincipalService)
        {
            _dbContext = dbContext;
            _tenantService = controllerCommonServicesService.TenantService;
            _objectMappingService = controllerCommonServicesService.ObjectMappingService;
            _secureApiMessageAttribute = controllerCommonServicesService.SecureApiMessageAttribute;

        }

        [EnableQuery(PageSize = 100)]
        protected virtual IQueryable<TEntity> InternalActiveRecords()
        {
            if (typeof(TEntity).IsSubclassOf(typeof(IHasRecordState)))
            {
                return InternalGetDbSet()
                    .Where(x => ((IHasRecordState)x).RecordState == RecordPersistenceState.Active);
            }
            return InternalGetDbSet();
        }


        //Helper:
        [EnableQuery(PageSize = 100)]
        protected virtual IQueryable<TEntity> InternalGetDbSet()
        {
            if (typeof(TEntity).IsSubclassOf(typeof(IHasTenantFK)))
            {
                Guid tenantFK = GetTenantFK();
                return _dbContext.GetQueryableSet<TEntity>()
                    .Where(x => (((IHasTenantFK)x).TenantFK == tenantFK));
            }
            return _dbContext.GetQueryableSet<TEntity>();
        }



        //protected IActionResult Ok(object content, Type type)
        //{

        //    Type resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);

        //    return Activator.CreateInstance(resultType, content, this) as IActionResult;
        //}



        // PUT api/values/5 
        protected virtual void InternalPut(TDto value)
        {
            //Create a new record:
            var entity = _objectMappingService.Map<TDto, TEntity>(value);

            _dbContext.Add(entity);
        }

        // Limit options for Denial of Service by 
        // excessive resource consumtion conditions:
        [EnableQuery(PageSize = 100)]
        protected virtual IQueryable<TDto> InternalGet(
            params Expression<Func<TDto, object>>[] expandProperties
            )
        {
            IQueryable<TDto> results;
            try
            {
                results =
                    InternalActiveRecords()
                        .ProjectTo(
                        (object)null,
                        expandProperties
                        )
                    ;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw;
            }
            if (_secureApiMessageAttribute.NeedsProcessing(typeof(TDto)))
            {
                // TODO: IMPORTANT: Verify this is not causing double iteration:
                results.ForEach(x => _secureApiMessageAttribute.Process(x));
            }

            return results;
        }




        protected virtual Guid GetTenantFK()
        {
            //this._principalService.t
            var result = this._tenantService.CurrentTenant.Id;
            return result;
        }


    }
}