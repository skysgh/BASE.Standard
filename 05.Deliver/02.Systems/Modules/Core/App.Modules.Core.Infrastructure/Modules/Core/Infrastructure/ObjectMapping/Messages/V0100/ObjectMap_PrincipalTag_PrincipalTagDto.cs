// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{

        /// <summary>
        ///     Create custom Maps for the Entity and its Dto.
        /// </summary>
        /// <seealso cref="MapUntenantedRecordStatedTimestampedNoIdBase{TEntity,TDto}" />
        public class ObjectMap_PrincipalTag_PrincipalTagDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<PrincipalTag, PrincipalTagDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<PrincipalTag, PrincipalTagDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Text, opt => { opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Description, opt => { opt.MapFrom(s => s.Description); })
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => { opt.MapFrom(s => s.DisplayStyleHint); })
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<PrincipalTagDto, PrincipalTag> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Title, opt => { opt.MapFrom(s => s.Text); })
                .ForMember(t => t.Description, opt => { opt.MapFrom(s => s.Description); })
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => { opt.MapFrom(s => s.DisplayStyleHint); })
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}