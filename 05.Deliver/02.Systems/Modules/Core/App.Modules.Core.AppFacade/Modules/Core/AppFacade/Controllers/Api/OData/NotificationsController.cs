using System;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData
{
    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GuidIdCommonODataControllerBase{DbContext, Notification, NotificationDto}" />
    public class NotificationsController
        : GuidIdCommonODataControllerBase<
            DbContext,
            Notification,
            NotificationDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsController"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        /// <param name="dbContext">The database context.</param>
        public NotificationsController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            ITenantService tenantService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute,
            ModuleDbContext dbContext)
            : base
            (diagnosticsTracingService,
                principalService,
                tenantService,
                objectMappingService,
                secureApiMessageAttribute,
                dbContext)
        {
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


        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        public override ActionResult<IQueryable<NotificationDto>> Get()
        {
            return InternalGet(RecordPersistenceState.Active);
        }

        //[ODataRoute("({key})")]
        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override ActionResult<NotificationDto> Get(Guid key)
        {
            return InternalGet(
                key, 
                RecordPersistenceState.Active);
        }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="valueObject">The value.</param>
        //[WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        //// POST api/values 
        public override IActionResult Post(NotificationDto valueObject)
        {
            return InternalPost(valueObject);
        }


        /// <summary>
        /// Puts the specified value.
        /// </summary>
        /// <param name="valueObject">The value.</param>
        //[WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        //// PUT api/values/5 
        public override IActionResult Put(NotificationDto valueObject)
        {
            return InternalPut(valueObject);
        }

    }
}