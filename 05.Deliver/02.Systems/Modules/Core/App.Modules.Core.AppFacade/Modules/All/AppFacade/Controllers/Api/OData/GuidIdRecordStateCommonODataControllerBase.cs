// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using System.Linq.Expressions;
using App.Diagrams.PlantUml.Uml;
using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.All.AppFacade.Controllers.Configuration.Routes;
using App.Modules.All.Shared.Models;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.AppFacade.Controllers.Api.OData
{
    /// <summary>
    ///     The common base class for simplifying the building
    ///     of OData Controllers
    ///     that return Queryable DTOs (that implement
    ///     <see cref="IHasGuidId" /> based <c>Id</c> property,
    ///     which is the majority of cases)
    ///     representing internal EF Entities.
    ///     <para>
    ///         Note: creating an ODataController (using this base class
    ///         or using an <see cref="ODataController" /> directly) is only
    ///         a first step. The Dto type, and the controller that returns it (ie this
    ///         controller) first needs to be registered as part of the
    ///         OData Model before routing to it will occur.
    ///         This is achieved by creating a class that implements
    ///         <see cref="IModuleOdataModelBuilderConfiguration" />
    ///         that is discovered at startup by
    ///         (although we recommend deriving/subclassing
    ///         from <see cref="ModuleODataModelBuilderConfigurationBase{T}" />
    ///         to save effort and make long term maintainability easier).
    ///     </para>
    ///     <para>
    ///         Finally, note that registering a model/controller within the OData model
    ///         map doesn't define the Url Path, which is the last part of what has to be setup
    ///         (Path, Controller, Dto, Entity).
    ///         OData Paths can be defined by convention, overridden using ODataPath something.
    ///         The convention is:
    ///         "/"
    ///         + "odata/" (as defined in All.Constants)
    ///         + "logicalModuleName/" (as determined by AssemblyName)
    ///         + "controllerName/" (as defined in using <see cref="IModuleOdataModelBuilderConfiguration"/>).
    ///         and this is configured in each Module's subclass of
    ///         <see cref="ModuleRoutesBase"/> (which implements <see cref="IModuleRoutes"/>,
    ///         which is how initialization finds it, and uses it to configure routes *per Module*.
    ///     </para>
    ///     <para>
    ///         Tip: If the <c>Id</c> is a <see cref="Guid" />,
    ///         consider using instead
    ///         <see cref="IdCommonODataControllerBase{TDbContext,TEntity,TDto, TId}" />
    ///         sibling of this class, as it is uses the more flexible
    ///         <c>CompareTo()</c>, making it suitable for enum, int, string based Keys).
    ///     </para>
    ///     <para>
    ///         Using this base class provides several advantages
    ///         which speed up development:
    ///     </para>
    ///     <para>
    ///         * has a built in concept of Logical Entity and exposed Dto Message equivalent
    ///         of that Entity, as well as the logic to leverage AutoMapper to pass the linq
    ///         through the layers. ie, the Magic of ProjectTo.
    ///     </para>
    ///     <para>
    ///         * only one base class that needs to be updated to .NET Core when we get there.
    ///     </para>
    ///     <para>
    ///         * ensures that all classes are injected with an implementation of
    ///         <see cref="IDiagnosticsTracingService" /> and <see cref="IPrincipalService" />
    ///         so there is absolutely no excuse for poor diagnostics logs, or security...
    ///     </para>
    ///     <para>
    ///         that said, still don't trust developers rushing to meet deadlines to take
    ///         care of ISO-25010/Maintainability or ISO-25010/Security, so we handle
    ///         Security and Logging as Global Filters anyway).
    ///     </para>
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <seealso cref="IdCommonODataControllerBase{TDbContext, TEntity, TDto, Guid}" />
    /// <seealso cref="Guid" />
    public abstract class GuidIdCommonODataControllerBase<TDbContext, TEntity,
            TDto>
        : IdCommonODataControllerBase<TDbContext, TEntity, TDto, Guid>
        where TDbContext : DbContext
        where TEntity : class, IHasGuidId,
        //IHasRecordState, 
        /*IHasTenantFK,*/
        new()
        where TDto : class, IHasGuidId, new()
    {
        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="GuidIdCommonODataControllerBase{TDbContext, TEntity,TDto}" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        protected GuidIdCommonODataControllerBase(
            IControllerCommonServicesService controllerCommonServicesService,
            DbContext dbContext
        )
            : this(
                controllerCommonServicesService.DiagnosticsTracingService,
                controllerCommonServicesService.PrincipalService,
                controllerCommonServicesService.TenantService,
                controllerCommonServicesService.ObjectMappingService,
                controllerCommonServicesService.SecureApiMessageAttribute,
                dbContext
            )
        {
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="GuidIdCommonODataControllerBase{TDbContext, TEntity, TDto}" /> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttributeService">The secure API message attribute service.</param>
        /// <param name="dbContext">The database context.</param>
        protected GuidIdCommonODataControllerBase(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            ITenantService tenantService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttributeService,
            DbContext dbContext
        ) :
            base(diagnosticsTracingService,
                principalService,
                tenantService,
                objectMappingService,
                secureApiMessageAttributeService,
                dbContext)
        {
        }





        //// POST api/values 
        /// <summary>
        ///     Internal method that can be invoked by a subclass,
        ///     and that already handles the mapping from Dto to Entity.
        ///     <para>
        ///         The method is protected and internal to ensure the
        ///         subclass' method is created deliberately, to ensure
        ///         that security is considered.
        ///     </para>
        /// </summary>
        /// <param name="value">The value.</param>
        protected override IActionResult InternalPost(TDto value)
        {
            //Update an existing record:
            var entity = InternalGetDbSet()
                .SingleOrDefault(x => x.Id == value.Id);

            _objectMappingService.Map(value, entity);
            // Nothing else to do (it's already being tracked)
            //so when committed later, will be saved.
            return Ok();
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
        /// <param name="key">The key. Note: the Property is called key to align with OData conventions.</param>
        /// <param name="recordPersistenceState">State of the record persistence.</param>
        /// <param name="expandProperties">The optional expand properties.</param>
        /// <returns></returns>
        protected override ActionResult<TDto> InternalGet(
            Guid key, 
            RecordPersistenceState recordPersistenceState, 
            params Expression<Func<TDto, object>>[] expandProperties)
        {
            
            var result =
                _objectMappingService.ProjectTo<TDto>(
                    InternalActiveRecords(recordPersistenceState)
                ).SingleOrDefault(x => x.Id == key);

            _secureApiMessageAttribute.Process(result);

            return Ok(result);
        }

        /// <summary>
        ///     Internal method that can be invoked by a subclass.
        ///     <para>
        ///         The method is protected and internal to ensure the
        ///         subclass' method is created deliberately, to ensure
        ///         that security is considered.
        ///     </para>
        /// </summary>
        /// <param name="key">The key.</param>
        protected override IActionResult InternalDelete(Guid key)
        {
            //We are doing a logical delete by changing state:
            var entity = InternalGetDbSet().SingleOrDefault(x => x.Id == key);

            if (typeof(TEntity).ImplementsInterface<IHasRecordState>())
            {
                // Soft delete if possible
                // TODO: Maybe this has to check against more states (ie !ToDispose and !Deleted ?)
                if (((IHasRecordState) entity)?.RecordState ==
                    RecordPersistenceState.Active)
                {
                    ((IHasRecordState) entity).RecordState =
                        RecordPersistenceState.ToDispose;
                }
            }
            else
            {
                // Hard delete
                _dbContext.DeleteOnCommit(entity);
            }

            return Ok();
        }
    }
}