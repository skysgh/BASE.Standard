using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_TenantedNavigationRoute_TenantedNavigationRouteDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<TenantedNavigationRoute, TenantedNavigationRouteDto>
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TenantedNavigationRoute, TenantedNavigationRouteDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => opt.MapFrom(s => s.DisplayStyleHint))
                .ForMember(t => t.Children, opt => opt.MapFrom(s => s.Children))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TenantedNavigationRouteDto, TenantedNavigationRoute> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Text))
                    .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                    .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                    .ForMember(t => t.DisplayStyleHint, opt => opt.MapFrom(s => s.DisplayStyleHint))
                    .ForMember(t => t.Children, opt => opt.MapFrom(s => s.Children))
                    .ForMember(t => t.OwnerFK, opt => opt.Ignore())
                    .ForMember(t => t.TenantFK, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}