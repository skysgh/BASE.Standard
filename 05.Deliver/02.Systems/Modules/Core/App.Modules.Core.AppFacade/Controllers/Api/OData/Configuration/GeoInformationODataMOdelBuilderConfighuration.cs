using App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace App.Core.Application.Initialization.OData.Implementations
{
    public class GeoInformationODataMOdelBuilderConfighuration : AllModulesODataModelBuilderConfigurationBase<GeoInformationDto>
    {

        public override EntityTypeConfiguration<GeoInformationDto> Define(ODataModelBuilder builder)
        {
            var result = base.Define(builder);
            result.HasKey(x => x.IPAddress);
            return result;
        }
    }
}
