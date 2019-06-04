
namespace App.Modules.Core.AppFacade.Controllers.Api.odata.Base
{
    using System;
    using System.Linq;
    using App.Modules.Core.AppFacade.Services;
    using App.Modules.Core.Infrastructure.ExtensionMethods;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Models;
    using App.Modules.Core.Models.Entities;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The base class for Tenanted (ie, specific to a certain client) Controllers 
    /// whose DTOs expose 
    /// the internal Guid Id of the logical entities.
    /// <para>
    /// In the past exposing the storage Id was considering
    /// exposing an unecessary amount of information, that could be
    /// maybe leveraged for an attack. 
    /// As a security concern that's basically false concern. On the other hand,
    /// it does cause a contractual dependency to the Guid Id, in between systems,
    /// when a Code would be more appropriate.
    /// </para>
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
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <seealso cref="ActiveRecordStateCommonODataControllerBase{TEntity,TDto}" />
    public abstract class GuidIdCommonODataControllerBase<TDbContext, TEntity, TDto>
        : ComparableIdCommonODataControllerBase<TDbContext, TEntity, TDto, Guid>
        where TDbContext : DbContext
        where TEntity : class, IHasGuidId,
        //IHasRecordState, 
        /*IHasTenantFK,*/
        new()
        where TDto : class, IHasGuidId, new()
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="TenantedGuidIdActiveRecordStateCommonODataControllerBase{TEntity,TDto}"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="repositoryService">The repository service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttributeService">The secure API message attribute.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        protected GuidIdCommonODataControllerBase(
            IControllerCommonServicesService controllerCommonServicesService,
            DbContext dbContext
            )
            : base(
                  controllerCommonServicesService,
                  dbContext
                  )
        {

        }


        // IMPORTANT:
        // The methods are protected (and prefixed with 'Internal') rather than public, 
        // in order to ensure developers don't blindly expose the methods without
        // attaching appropriate security attributes and calls, as well as 
        // (optional) route attributes 


        //// POST api/values 
        protected override void InternalPost(TDto value)
        {
            //Update an existing record:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id == value.Id);

            _objectMappingService.Map(value, entity);
            // Nothing else to do (it's already being tracked)
            //so when committed later, will be saved.
        }

        protected override TDto InternalGet(Guid key)
        {
            var result =
                InternalActiveRecords()
                .ProjectTo<TDto>()
                .SingleOrDefault(x => x.Id == key);

            _secureApiMessageAttribute.Process(result);
            return result;
        }

        protected override void InternalDelete(Guid key)
        {
            //We are doing a logical delete by changing state:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id == key);

            if (typeof(TEntity).IsSubclassOf(typeof(IHasRecordState)))
            {
                // TODO: Maybe this has to check against more states (ie !ToDispose and !Deleted ?)
                if (((IHasRecordState)entity)?.RecordState == RecordPersistenceState.Active)
                {
                    ((IHasRecordState)entity).RecordState = RecordPersistenceState.ToDispose;
                }
            }
            else
            {
                _dbContext.DeleteOnCommit(entity);
            }
        }

    }
}