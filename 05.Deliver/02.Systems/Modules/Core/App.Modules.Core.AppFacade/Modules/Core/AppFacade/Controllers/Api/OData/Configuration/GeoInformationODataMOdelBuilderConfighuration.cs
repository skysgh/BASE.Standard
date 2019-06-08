using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    public class GeoInformationODataMOdelBuilderConfighuration 
        : AllModulesODataModelBuilderConfigurationBase<GeoInformationDto>
    {

        public override EntityTypeConfiguration<GeoInformationDto> Define(ODataModelBuilder builder)
        {
            var result = base.Define(builder);
            result.HasKey(x => x.IPAddress);
            return result;
        }
    }
}
