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
    public class ObjectMap_ConfigurationStepRecord_ConfigurationStepRecordDto
        :
            MapBase<ConfigurationStatusComponentStep, ConfigurationStatusStepDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ConfigurationStatusComponentStep, ConfigurationStatusStepDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(x=>x.Id))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.DateTime, opt => opt.MapFrom(s => s.UtcDateTimeCreated))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Task, opt => opt.MapFrom(s => s.Task))
                .ForMember(t => t.Outcome, opt => opt.MapFrom(s => s.Outcome))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ConfigurationStatusStepDto, ConfigurationStatusComponentStep> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(t => t.UtcDateTimeCreated, opt => opt.MapFrom(s => s.DateTime))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Task, opt => opt.MapFrom(s => s.Task))
                .ForMember(t => t.Outcome, opt => opt.MapFrom(s => s.Outcome))
                ;
            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}