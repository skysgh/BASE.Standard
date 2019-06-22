using System;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData
{
    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    /// <summary>
    /// 
    /// </summary>
    /// <seealso
    /// cref="App.Modules.All.AppFacade.Controllers.Api.OData.GuidIdCommonODataControllerBase{DbContext, Principal, PrincipalDto}" />
    public class PrincipalsController
        : GuidIdCommonODataControllerBase<
            DbContext,
            Principal, PrincipalDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrincipalsController"/> class.
        /// </summary>
        /// <param name="diagnosticsTracingService">The diagnostics tracing service.</param>
        /// <param name="principalService">The principal service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="objectMappingService">The object mapping service.</param>
        /// <param name="secureApiMessageAttribute">The secure API message attribute.</param>
        /// <param name="dbContext">The database context.</param>
        public PrincipalsController(
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
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        public override ActionResult<IQueryable<PrincipalDto>> Get()
        {
            return InternalGet(RecordPersistenceState.Active,
                    x => x.DataClassification,
                    x => x.Category,
                    x => x.Tags,
                    x => x.Properties,
                    x => x.Claims
                );
        }

        //[ODataRoute("({key})")]
        /// <summary>
        /// Gets the specified value as per provided key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public override ActionResult<PrincipalDto> Get([FromODataUri] Guid key)
        {
            return InternalGet(key,
                    RecordPersistenceState.Active,
                    x => x.DataClassification,
                    x => x.Category,
                    x => x.Tags,
                    x => x.Properties,
                    x => x.Claims);

        }


        //{
        //public void Post([FromPrincipal]PrincipalDto value)

        //// POST api/values 
        //    _dbConnection.Bodies.Add( Mapper.Map<Principal>(value));
        //}

        //// PUT api/values/5 
        //public void Put(Guid key, [FromPrincipal]PrincipalDto value)
        //{
        //}
    }
}