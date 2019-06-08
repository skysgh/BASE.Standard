using App.Modules.All.Infrastructure.ObjectMapping;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Messages;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{



    public class ObjectMap_GeoInformation_GeoInfromationDto
    : MapBase<GeoInformation, GeoInformationDto>
    , IHasAutomapperInitializer
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<GeoInformation, GeoInformationDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.IPAddress, opt => opt.MapFrom(s => s.IPAddress))
                .ForMember(t => t.CountryRegion, opt => opt.MapFrom(s => s.CountryRegion))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<GeoInformationDto, GeoInformation> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.IPAddress, opt => opt.MapFrom(s => s.IPAddress))
                .ForMember(t => t.CountryRegion, opt => opt.MapFrom(s => s.CountryRegion))
                ;

            //base.ConfigureMapFromDtoToEntity(mappingExpression);

        }
    }

}
