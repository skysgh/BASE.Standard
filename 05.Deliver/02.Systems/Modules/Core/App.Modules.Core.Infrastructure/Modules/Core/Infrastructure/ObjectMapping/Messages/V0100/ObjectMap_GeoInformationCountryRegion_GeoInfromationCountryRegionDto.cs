// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Messages;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapBase{TEntity,TDto}" />
    public class ObjectMap_GeoInformationCountryRegion_GeoInfromationCountryRegionDto
        : MapBase<GeoInformationCountryRegion, GeoInformationCountryRegionDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<GeoInformationCountryRegion, GeoInformationCountryRegionDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.IsoCode, opt => opt.MapFrom(s => s.IsoCode))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
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