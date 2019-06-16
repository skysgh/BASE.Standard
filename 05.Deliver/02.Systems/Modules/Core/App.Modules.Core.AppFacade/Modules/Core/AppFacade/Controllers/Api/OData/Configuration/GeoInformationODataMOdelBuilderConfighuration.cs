using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    /// An OData Configuration object to define the shape of an
    /// <see cref="GeoInformationDto"/>, and relate it to a Controller.
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.Configuration.ModuleODataModelBuilderConfigurationBase{GeoInformationDto}" />
    public class GeoInformationODataMOdelBuilderConfighuration 
        : ModuleODataModelBuilderConfigurationBase<GeoInformationDto>
    {

        /// <summary>
        /// Defines the entity set for T,
        /// and sets the Id.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public override EntityTypeConfiguration<GeoInformationDto> Define(ODataModelBuilder builder)
        {
            // Use the default base:
            var result = base.Define(builder);
            
            //Then override the Key by redefining it as the IPAddress:
            result.HasKey(x => x.IPAddress);

            return result;
        }
    }
}
