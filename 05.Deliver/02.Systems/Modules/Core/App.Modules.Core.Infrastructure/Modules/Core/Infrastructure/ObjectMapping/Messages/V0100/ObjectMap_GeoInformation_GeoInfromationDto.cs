using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Messages;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{



    /// <summary>
    /// Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapBase{GeoInformation, GeoInformationDto}" />
    public class ObjectMap_GeoInformation_GeoInfromationDto
    : MapBase<GeoInformation, GeoInformationDto>
    {
        /// <summary>
        /// Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<GeoInformation, GeoInformationDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.IPAddress, opt => opt.MapFrom(s => s.IPAddress))
                .ForMember(t => t.CountryRegion, opt => opt.MapFrom(s => s.CountryRegion))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        /// Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
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
