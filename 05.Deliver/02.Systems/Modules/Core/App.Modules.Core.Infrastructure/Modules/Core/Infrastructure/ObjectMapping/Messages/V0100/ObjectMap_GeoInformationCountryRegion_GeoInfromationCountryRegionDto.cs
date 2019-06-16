using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Messages;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_GeoInformationCountryRegion_GeoInfromationCountryRegionDto
        : MapBase<GeoInformationCountryRegion, GeoInformationCountryRegionDto>
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<GeoInformationCountryRegion, GeoInformationCountryRegionDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.IsoCode, opt => opt.MapFrom(s => s.IsoCode))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<GeoInformationCountryRegionDto, GeoInformationCountryRegion> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.IsoCode, opt => opt.MapFrom(s => s.IsoCode))
                ;
            //base.ConfigureMapFromDtoToEntity(mappingExpression);

        }
    }

}
