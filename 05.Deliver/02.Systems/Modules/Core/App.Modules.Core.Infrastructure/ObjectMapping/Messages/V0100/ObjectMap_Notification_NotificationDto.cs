using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_Notification_NotificationDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<Notification, NotificationDto>,
            IHasAutomapperInitializer
    {

        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<Notification, NotificationDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                .ForMember(t => t.DateTimeReadUtc, opt => opt.MapFrom(s => s.DateTimeReadUtc))
                .ForMember(t => t.From, opt => opt.MapFrom(s => s.From))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                // If not provided IsRead,Class,ImageUrl can be PostProcessed 
                // and inferred from Type and DateTimeReadUtc
                .ForMember(x => x.IsRead, opt => opt.Ignore())
                .ForMember(t => t.Class, opt => opt.MapFrom(s => s.Class))
                .ForMember(t => t.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<NotificationDto, Notification> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Text))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                .ForMember(x => x.IsRead, opt => opt.MapFrom(s => s.IsRead))
                .ForMember(t => t.Class, opt => opt.MapFrom(s => s.Class))
                .ForMember(t => t.ImageUrl, opt => opt.MapFrom(s => s.ImageUrl))
                .ForMember(t => t.PrincipalFK, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
            // and...
            MapAttributes(mappingExpression);
        }

        private void MapAttributes(IMappingExpression<NotificationDto, Notification> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                .ForMember(t => t.DateTimeReadUtc, opt => opt.MapFrom(s => s.DateTimeReadUtc))
                .ForMember(t => t.From, opt => opt.MapFrom(s => s.From))
                ;
        }
    }
}