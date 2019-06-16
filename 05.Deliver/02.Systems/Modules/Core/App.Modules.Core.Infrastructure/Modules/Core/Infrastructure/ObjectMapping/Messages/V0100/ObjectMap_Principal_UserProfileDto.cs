using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_Principal_UserProfileDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<Principal, UserProfileDto>
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<Principal, UserProfileDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<UserProfileDto, Principal> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.Ignore())
                    .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                    .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                    .ForMember(t => t.EnabledBeginningUtcDateTime, opt => opt.Ignore())
                    .ForMember(t => t.EnabledEndingUtcDateTime, opt => opt.Ignore())
                    .ForMember(t => t.DataClassification, opt => opt.Ignore())
                    .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                    .ForMember(t => t.Category, opt => opt.Ignore())
                    .ForMember(t => t.CategoryFK, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
            // and...
            MapCollections(mappingExpression);
        }

        private void MapCollections(IMappingExpression<UserProfileDto, Principal> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Logins, opt => opt.Ignore())
                .ForMember(t => t.Roles, opt => opt.Ignore())
                .ForMember(t => t.TagAssignment, opt => opt.Ignore())
                .ForMember(t => t.Properties, opt => opt.Ignore())
                .ForMember(t => t.Claims, opt => opt.Ignore());
        }
    }
}
