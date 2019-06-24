using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.All.AppFacade.Controllers.Api.OData.Base;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using CachingFramework.Redis.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.Core.Application.API.Controllers.V0100
{
    public class GeoInformationsController 
        : CommonODataControllerBase
    {
        private readonly IGeoIPService _geoIpService;
        private readonly IObjectMappingService _objectMappingService;
        private readonly IHttpContextService _httpContextService;

        public GeoInformationsController(
            IGeoIPService geoIpService, 
            IObjectMappingService objectMappingService,
            IDiagnosticsTracingService diagnosticsTracingService, 
            IPrincipalService principalService,
            IHttpContextService httpContextService)
            : base(diagnosticsTracingService, principalService)
        {
            _geoIpService = geoIpService;
            _objectMappingService = objectMappingService;
            this._httpContextService = httpContextService;
        }


        public GeoInformationDto Get()
        {
            this._diagnosticsTracingService
                .Trace(TraceLevel.Debug, $"GeoLocationController.Get");

            var geoinfo = _geoIpService.Get(
                _httpContextService.Current.Request.UserHostAddress);

            var result = this._objectMappingService.Map<GeoInformation, GeoInformationDto>(geoinfo);
            return result;
        }
    }
}
