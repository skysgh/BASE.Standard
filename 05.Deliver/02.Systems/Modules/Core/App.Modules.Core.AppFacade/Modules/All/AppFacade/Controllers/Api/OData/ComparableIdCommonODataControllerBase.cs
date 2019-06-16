using System;
using System.Linq;
using App.Modules.All.Shared.Models;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.AppFacade.Controllers.Api.OData
{
    /// <summary>
    /// The base class for all OData Controllers
    /// that deal in DTOs mapper from Entities.
    /// <para>
    /// The DTOs (and Entities) have an Id property
    /// whose type could be a Guid, or Enum, or int. 
    /// </para>
    /// <para>
    /// Advantages are that the class handles the mapping automatically.
    /// </para>
    /// <para>
    /// The advantages include:
    /// * has a built in concept of Logical Entity and exposed Dto Message equivalent
    /// of that Entity, as well as the logic to leverage AutoMapper to pass the linq
    /// through the layers. ie, the Magic of ProjectTo.
    /// * only one base class that needs to be updated to .NET Core when we get there.
    /// * ensures that all classes are injected with an implementation of
    /// <see cref="IDiagnosticsTracingService" /> and <see cref="IPrincipalService" />
    /// so there is absolutely no excuse for poor diagnostics logs, or security...
    /// </para>
    /// <para>
    /// that said, still don't trust developers rushing to meet deadlines to take
    /// care of ISO-25010/Maintainability or ISO-25010/Security, so we handle
    /// Security and Logging as GLobal Filters anyway).
    /// </para>
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.MappedCommonODataControllerBase{TDbContext, TEntity, TDto}" />
    public abstract class ComparableIdCommonODataControllerBase<TDbContext, TEntity, TDto, TId>
        : MappedCommonODataControllerBase<TDbContext, TEntity, TDto>
        where TDbContext : DbContext
        where TId : IComparable
        where TEntity : class, IHasId<TId>, new()
        where TDto : class, IHasId<TId>, new()
    {


        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ComparableIdCommonODataControllerBase{TDbContext, TEntity, TDto, TId}" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        protected ComparableIdCommonODataControllerBase(
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

        protected virtual void InternalPost(TDto value)
        {
            //Update an existing record:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id.CompareTo(value.Id) == 0);

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
        protected virtual TDto InternalGet(TId key)
        {
            var result =
                //InternalActiveRecords()
                //.ProjectTo<TDto>()
                //.SingleOrDefault(x => x.Id.CompareTo(key) == 0);

                _objectMappingService.ProjectTo<TDto>(
                    InternalActiveRecords()
                ).SingleOrDefault(x => x.Id.CompareTo(key) == 0);

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
        protected virtual void InternalDelete(Guid key)
        {
            //We are doing a logical delete by changing state:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id.CompareTo(key) == 0);

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
                base._dbContext.DeleteOnCommit(entity);
            }
        }

    }
}