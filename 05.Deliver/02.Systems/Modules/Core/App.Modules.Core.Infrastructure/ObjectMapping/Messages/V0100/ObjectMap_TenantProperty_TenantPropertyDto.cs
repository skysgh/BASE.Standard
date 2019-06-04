using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_TenantProperty_TenantPropertyDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<TenantProperty, TenantPropertyDto>,
            IHasAutomapperInitializer
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TenantProperty, TenantPropertyDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TenantPropertyDto, TenantProperty> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}