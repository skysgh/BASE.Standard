// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Infrastructure.Services.Configuration;
using App.Modules.Core.Shared.Models.DTOs;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapBase{TEntity,TDto}" />
    public class ObjectMap_ApplicationDescription_ApplicationDescriptionDto
        :
            MapBase<ApplicationDescriptionServiceConfiguration, ApplicationDescriptionDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ApplicationDescriptionServiceConfiguration, ApplicationDescriptionDto>
                mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))

                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.Description, opt => opt.MapFrom(s=>s.Description))

                .ForMember(t => t.Creator, opt => opt.MapFrom(s=>s.Creator))
                .ForMember(t => t.Distributor, opt => opt.MapFrom(s=>s.Distributor))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }


        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ApplicationDescriptionDto, ApplicationDescriptionServiceConfiguration>
                mappingExpression)
        {
            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}