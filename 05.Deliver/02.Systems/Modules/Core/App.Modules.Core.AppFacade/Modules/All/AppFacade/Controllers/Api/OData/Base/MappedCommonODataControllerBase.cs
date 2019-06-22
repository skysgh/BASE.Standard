// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using System.Linq.Expressions;
using App.Diagrams.PlantUml.Uml;
using App.Modules.All.Shared.Models;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.AppFacade.Controllers.Api.OData.Base
{
    /// <summary>
    ///     Just about every controller, whatever module,
    ///     *should* inherit in one way or another
    ///     from this base controller.
    ///     <para>
    ///         The advantages include:
    ///         * has a built in concept of Logical Entity and exposed Dto Message equivalent
    ///         of that Entity, as well as the logic to leverage AutoMapper to pass the linq
    ///         through the layers. ie, the Magic of ProjectTo.
    ///         * only one base class that needs to be updated to .NET Core when we get there.
    ///         * ensures that all classes are injected with an implementation of
    ///         <see cref="IDiagnosticsTracingService" /> and <see cref="IPrincipalService" />
    ///         so there is absolutely no excuse for poor diagnostics logs, or security...
    ///         (that said, still don't trust developers rushing to meet deadlines to take
    ///         care of ISO-25010/Maintainability or ISO-25010/Security, so we handle
    ///         Security and Logging as GLobal Filters anyway).
    ///     </para>
    /// </summary>
    /// <seealso cref="ODataController" />
    public abstract class MappedCommonODataControllerBase<TDbContext, TEntity,
            TDto>
        : CommonODataControllerBase
        where TDbContext : DbContext
        where TEntity : class, new()
        where TDto : class, new()

    {
        /// <summary>
        ///     The database context used to retrieve/save objects.
        /// </summary>
        protected readonly DbContext _dbContext;

        /// <summary>
        ///     The object mapping service
        /// </summary>
        protected readonly IObjectMappingService _objectMappingService;

        /// <summary>
        ///     The secure API message attribute service
        ///     used to secure messages before they go out.
        /// </summary>
        protected readonly ISecureAPIMessageAttributeService
            _secureApiMessageAttribute;
        //protected /*readonly*/ string _dbContextIdentifier;

        /// <summary>
        ///     The tenant service
        /// </summary>
        protected readonly ITenantService _tenantService;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MappedCommonODataControllerBase{TDbContext, TEntity, TDto}" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        protected MappedCommonODataControllerBase(
            IControllerCommonServicesService controllerCommonServicesService,
            DbContext dbContext
        ) : this(controllerCommonServicesService.DiagnosticsTracingService,
            controllerCommonServicesService.PrincipalService,
            controllerCommonServicesService.TenantService,
            controllerCommonServicesService.ObjectMappingService,
            controllerCommonServicesService.SecureApiMessageAttribute,
            dbContext
        )
        {
            ControllerCommonServicesService = controllerCommonServicesService;
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="MappedCommonODataControllerBase{TDbContext, TEntity, TDto}" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttributeService">The secure API message attribute service.</param>
        /// <param name="dbContext">The database context.</param>
        protected MappedCommonODataControllerBase(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            ITenantService tenantService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttributeService,
            DbContext dbContext
        ) :
            base(diagnosticsTracingService,
                principalService)
        {
            _tenantService = tenantService;
            _objectMappingService = objectMappingService;
            _secureApiMessageAttribute = secureApiMessageAttributeService;
            _dbContext = dbContext;
        }


        /// <summary>
        ///     Gets the controller common services service.
        /// </summary>
        /// <value>
        ///     The controller common services service.
        /// </value>
        public IControllerCommonServicesService ControllerCommonServicesService
        {
            get;
        }


        /// <summary>
        /// Override to
        /// return a queryable set of
        /// this controller's DTO entities.
        /// <para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        public abstract ActionResult<IQueryable<TDto>> Get();


        /// <summary>
        ///     Internal method that can be invoked by a subclass.
        ///     <para>
        ///         The method is protected and internal to ensure the
        ///         subclass' method is created deliberately, to ensure
        ///         that security is considered.
        ///     </para>
        ///     <para>
        ///         Invoked by <see cref="InternalActiveRecords" />
        ///     </para>
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        protected virtual IQueryable<TEntity> InternalGetDbSet(
            RecordPersistenceState recordState= RecordPersistenceState.Active, 
            Guid? tenantFK=null)
        {
            if (typeof(TEntity).ImplementsInterface<IHasTenantFK>())
            {
                if (tenantFK == null)
                {
                    tenantFK = GetTenantFK();
                }

                if (typeof(TEntity).ImplementsInterface<IHasRecordState>())
                {
                    return _dbContext.GetQueryableSet<TEntity>()
                        .Where(x => 
                            (((IHasTenantFK)x).TenantFK == tenantFK)
                            &&
                            (((IHasRecordState)x).RecordState == recordState)
                            );
                }
                else
                {
                    return _dbContext.GetQueryableSet<TEntity>()
                        .Where(x => ((IHasTenantFK) x).TenantFK == tenantFK);
                }
            }
            else
            {
                if (typeof(TEntity).ImplementsInterface<IHasRecordState>())
                {

                    return _dbContext.GetQueryableSet<TEntity>()
                        .Where(x =>
                            ((IHasRecordState) x).RecordState == recordState
                        );

                }
                else
                {
                    return _dbContext.GetQueryableSet<TEntity>();
                }
            }

        }


        //protected IActionResult Ok(object content, Type type)
        //{

        //    Type resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);

        //    return Activator.CreateInstance(resultType, content, this) as IActionResult;
        //}




        // PUT api/values/5 
        /// <summary>
        ///     Internal method that can be invoked by a subclass.
        ///     <para>
        ///         The method is protected and internal to ensure the
        ///         subclass' method is created deliberately, to ensure
        ///         that security is considered.
        ///     </para>
        /// </summary>
        /// <param name="value">The value.</param>
        protected virtual IActionResult InternalPut(TDto value)
        {
            //Create a new record:
            // Note that tenancy is filled in by pre-save processor.
            var entity = _objectMappingService.Map<TDto, TEntity>(value);

            _dbContext.Add(entity);

            return Ok();
        }

        /// <summary>
        ///     Internal method that can be invoked by a subclass.
        ///     <para>
        ///         The method is protected and internal to ensure the
        ///         subclass' method is created deliberately, to ensure
        ///         that security is considered.
        ///     </para>
        /// </summary>
        // Limit options for Denial of Service by 
        // excessive resource consumption conditions:
        [EnableQuery(PageSize = 100)]
        protected virtual ActionResult<IQueryable<TDto>> InternalGet(
            RecordPersistenceState recordPersistenceState,
            params Expression<Func<TDto, object>>[] expandProperties
        )
        {
            IQueryable<TDto> results;

            results =
                _objectMappingService.ProjectTo(
                    InternalActiveRecords(recordPersistenceState),
                    null,
                    expandProperties
                );
            if (_secureApiMessageAttribute.NeedsProcessing(typeof(TDto)))
            {
                // TODO: IMPORTANT: Verify this is not causing double iteration:
                results.ForEach(x => _secureApiMessageAttribute.Process(x));
            }

            return Ok(results);
        }


        /// <summary>
        ///     Gets only Active records.
        ///     <para>
        ///         Invokes <see cref="InternalGetDbSet" />
        ///     </para>
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        protected virtual IQueryable<TEntity> InternalActiveRecords(
            RecordPersistenceState recordPersistenceState /*= RecordPersistenceState.Active*/)
        {
            // Important:
            // must remain Queryable, as other methods 
            // manipulate results.
                return InternalGetDbSet(recordPersistenceState);

        }


        /// <summary>
        ///     Gets the current Tenant Id (in order to limit
        ///     records retrieved using Get).
        /// </summary>
        /// <returns></returns>
        protected virtual Guid GetTenantFK()
        {
            //this._principalService.t
            var result = _tenantService.CurrentTenant.Id;
            return result;
        }
    }
}