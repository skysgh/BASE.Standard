// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Messages;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapBase{TEntity,TDto}" />
    public class ObjectMap_ConfigurationStatus_ConfigurationStatusDto
        :
            MapBase<ConfigurationStatus, ConfigurationStatusDto>
    {

        
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ConfigurationStatus, ConfigurationStatusDto> mappingExpression)
        {

            mappingExpression
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Components, opt =>
                {
                    //opt.ExplicitExpansion();
                    opt.MapFrom(s => s.Components);
                })
                ;
            ;
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ConfigurationStatusDto, ConfigurationStatus> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Components, opt =>
                {
                    //opt.ExplicitExpansion();
                    opt.MapFrom(s => s.Components);
                })
                ;

        }
    }
}