﻿using App.Core.Application.API.Controllers.Base.CoreModule;
using App.Core.Application.Filters.WebApi;
using App.Core.Shared.Constants;

namespace App.Core.Application.API.Controllers.V0100
{
    using System;
    using System.Linq;
    using System.Web.OData;
    using App.Core.Application.Attributes;
    using App.Core.Application.API.Controllers.Base;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using App.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper.QueryableExtensions;

    // NOTE: Each OData API Endpoint MUST be have a corresponding IOdataModelBuilderConfigurationBase ...

    //[ODataRoutePrefix("body")]
    [ODataPath(Constants.Api.ApiControllerNames.Notification)]
    public class NotificationController : GuidIdActiveRecordStateCoreODataControllerBase<Notification, NotificationDto>
    {
        public NotificationController(
            IDiagnosticsTracingService diagnosticsTracingService, 
            IPrincipalService principalService, 
            IRepositoryService repositoryService,
            IObjectMappingService objectMappingService,
            ISecureAPIMessageAttributeService secureApiMessageAttribute) : base
            (diagnosticsTracingService, principalService, repositoryService, objectMappingService, secureApiMessageAttribute)
        {
        }


        // GET api/values 
        //[ApplyDataContractResolver]
        //[ApplyProxyDataContractResolverAttribute]
        //[ODataRoute()]
        [EnableQuery(PageSize = 100)]
        public IQueryable<NotificationDto> Get()
        {
            return InternalGet();
        }

        //[ODataRoute("({key})")]
        public NotificationDto Get(Guid key)
        {
            return InternalGet(key);
        }

        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        //// POST api/values 
        public void Post(NotificationDto value)
        {
            InternalPost(value);
        }

        [WebApiAppAuthorize(Roles = AppModuleApiScopes.WriteScope)]
        //// PUT api/values/5 
        public void Put(NotificationDto value)
        {
            InternalPut(value);
        }

    }
}