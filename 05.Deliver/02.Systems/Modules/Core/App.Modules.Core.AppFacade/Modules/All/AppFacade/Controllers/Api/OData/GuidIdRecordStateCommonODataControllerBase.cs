using System;
using System.Linq;
using App.Modules.All.Shared.Models;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.AppFacade.Controllers.Api.OData
{
    /// <summary>
    /// The base class for Tenanted (ie, specific to a certain client) Controllers
    /// whose DTOs expose
    /// the internal Guid Id of the logical entities.
    /// <para>
    /// In the past exposing the storage Id was considering
    /// exposing an unnecessary amount of information, that could be
    /// maybe leveraged for an attack.
    /// As a security concern that's basically false concern. On the other hand,
    /// it does cause a contractual dependency to the Guid Id, in between systems,
    /// when a Code would be more appropriate.
    /// </para><para>
    /// The advantages include:
    /// * has a built in concept of Logical Entity and exposed Dto Message equivalent
    /// of that Entity, as well as the logic to leverage AutoMapper to pass the linq
    /// through the layers. ie, the Magic of ProjectTo.
    /// * only one base class that needs to be updated to .NET Core when we get there.
    /// * ensures that all classes are injected with an implementation of
    /// <see cref="IDiagnosticsTracingService" /> and <see cref="IPrincipalService" />
    /// so there is absolutely no excuse for poor diagnostics logs, or security...
    /// (that said, still don't trust developers rushing to meet deadlines to take
    /// care of ISO-25010/Maintainability or ISO-25010/Security, so we handle
    /// Security and Logging as GLobal Filters anyway).
    /// </para>
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <seealso cref="ComparableIdCommonODataControllerBase{TDbContext, TEntity, TDto, Guid}" />
    /// <seealso cref="Guid" />
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
        /// Initializes a new instance of the
        /// <see cref="GuidIdCommonODataControllerBase{TDbContext, TEntity,TDto}" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
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





        //// POST api/values 
        /// <summary>
        /// Internal method that can be invoked by a subclass,
        /// and that already handles the mapping from Dto to Entity.
        /// <para>
        /// The method is protected and internal to ensure the
        /// subclass' method is created deliberately, to ensure
        /// that security is considered.
        /// </para>
        /// </summary>
        /// <param name="value">The value.</param>
        protected override void InternalPost(TDto value)
        {
            //Update an existing record:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id == value.Id);

            _objectMappingService.Map(value, entity);
            // Nothing else to do (it's already being tracked)
            //so when committed later, will be saved.
        }

        /// <summary>
        /// Internal method that can be invoked by a subclass,
        /// and that already handles the mapping from Entity to Dto.
        /// <para>
        /// The method is protected and internal to ensure the
        /// subclass' method is created deliberately, to ensure
        /// that security is considered.
        /// </para>
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected override TDto InternalGet(Guid key)
        {
            var result =

                //InternalActiveRecords()
                //.ProjectTo<TDto>()
                //.SingleOrDefault(x => x.Id == key);

                _objectMappingService.ProjectTo<TDto>(
                    InternalActiveRecords()
                ).SingleOrDefault(x => x.Id == key);

            _secureApiMessageAttribute.Process(result);
            return result;
        }

        /// <summary>
        /// Internal method that can be invoked by a subclass.
        /// <para>
        /// The method is protected and internal to ensure the
        /// subclass' method is created deliberately, to ensure
        /// that security is considered.
        /// </para>
        /// </summary>
        /// <param name="key">The key.</param>
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