using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Application.API.Controllers.V0100
{
    using System;
    using System.Linq;


    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GuidIdCommonODataControllerBase{DbContext, SessionOperation, SessionOperationDto}" />
    public class SessionOperationsController :
        GuidIdCommonODataControllerBase<DbContext, SessionOperation, SessionOperationDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionOperationsController"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        /// <param name="dbContext">The database context.</param>
        public SessionOperationsController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            ITenantService tenantService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute,
            ModuleDbContext dbContext)
            : base(
                  diagnosticsTracingService,
                  principalService,
                  tenantService,
                  objectMappingService,
                  secureApiMessageAttribute,
                  dbContext
                  )
        {
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
        public override ActionResult<IQueryable<SessionOperationDto>> Get()
        {
            return InternalGet(RecordPersistenceState.Active);
        }

        /// <summary>
        /// Gets a single entity, from the given Id.
        /// <para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override ActionResult<SessionOperationDto> Get(Guid key)
        {
            return InternalGet(
                    key,
                    RecordPersistenceState.Active);
        }

        /// <summary>
        /// Creates the specified resource.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.IdCommonODataControllerBase`4.InternalPost(`2)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Post(SessionOperationDto message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified resource.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.Base.MappedCommonODataControllerBase`3.InternalPut(`2)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Put(SessionOperationDto message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the entity specified by the key.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.IdCommonODataControllerBase`4.InternalDelete(`3)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Delete(Guid key)
        {
            throw new NotImplementedException();
        }

    }
}