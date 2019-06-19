using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.KWMODULE.Shared.Models.Entities;
using App.Modules.KWMODULE.Shared.Models.Messages;
using AutoMapper;

namespace App.Modules.KWMODULE.Infrastructure.ObjectMapping
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MapTenantedRecordStatedTimestampedGuidIdBase{TenantedExample, TenantedExampleDto}" />
    public class ObjectMap_TenantedExample_TenantedExampleDto
        
        : MapTenantedRecordStatedTimestampedGuidIdBase<TenantedExample, TenantedExampleDto>
    {

        /// <summary>
        /// Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TenantedExample, TenantedExampleDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        /// Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TenantedExampleDto, TenantedExample> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}