using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.All.AppFacade.Controllers.Api.OData.Base;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.HOLD.V0100
{
    using System;
    using System.Linq;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    //[WebApiAppAuthorize(Roles = "core_read")]
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="GuidIdCommonODataControllerBase{DbContext, Tenant, TenantDto}" />
    public class TenantsController :
        GuidIdCommonODataControllerBase<
            DbContext,
            Tenant, TenantDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantsController"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        /// <param name="dbContext">The database context.</param>
        public TenantsController(
            IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService,
            ITenantService tenantService,
            IObjectMappingService objectMappingService,
                ISecureAPIMessageAttributeService secureApiMessageAttribute,
            ModuleDbContext dbContext
            ) : base
            (diagnosticsTracingService,
                    principalService,
                    tenantService,
                    objectMappingService,
                    secureApiMessageAttribute,
                    dbContext)
        {
        }



        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
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
        public override ActionResult<IQueryable<TenantDto>> Get()
        {
            var results
                = InternalGet(RecordPersistenceState.Active,
                    x => x.DataClassification,
                    x => x.Properties,
                    x => x.Claims
                );

            return results;
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
        public override ActionResult<TenantDto> Get(Guid key)
        {
            return InternalGet(
                    key,
                    RecordPersistenceState.Active,
                    x => x.DataClassification,
                    x => x.Properties,
                    x => x.Claims
                );
        }

        /// <summary>
        /// Create a new entity.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        //[WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        public override IActionResult Post(TenantDto value)
        {
            return InternalPost(value);
        }

        //[WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        /// <summary>
        /// Updates the specified resource.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="MappedCommonODataControllerBase{TDbContext,TEntity,TDto}.InternalPut"/>
        /// </para>
        /// <para>
        /// If not desired,
        /// throw a <see cref="NotImplementedException"/>.
        /// </para>
        /// <para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <returns></returns>
        public override IActionResult Put(TenantDto value)
        {
            return InternalPut(value);
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