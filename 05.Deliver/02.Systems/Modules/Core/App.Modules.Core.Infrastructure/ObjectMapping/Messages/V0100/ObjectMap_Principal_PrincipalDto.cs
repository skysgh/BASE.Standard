using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_Principal_PrincipalDto 
        : MapUntenantedRecordStatedTimestampedNoIdBase<Principal, PrincipalDto>,
        IHasAutomapperInitializer
    {

        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<Principal, PrincipalDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.Category, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Category); })
                .ForMember(t => t.Tags, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.TagAssignment); })
                .ForMember(t => t.Properties, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Properties); })
                .ForMember(t => t.Claims, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Claims); })
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<PrincipalDto, Principal> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                    .ForMember(t => t.FullName, opt => opt.MapFrom(s => s.FullName))
                    .ForMember(t => t.EnabledBeginningUtc, opt => opt.Ignore())
                    .ForMember(t => t.EnabledEndingUtc, opt => opt.Ignore())
                    .ForMember(t => t.DataClassification, opt => opt.Ignore())
                    .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                    .ForMember(t => t.Category, opt => opt.Ignore())
                    .ForMember(t => t.CategoryFK, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
            // and...
            MapCollections(mappingExpression);
        }

        private void MapCollections(IMappingExpression<PrincipalDto, Principal> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Logins, opt => opt.MapFrom(s => s.Logins))
                .ForMember(t => t.Roles, opt => opt.MapFrom(s => s.Roles))
                .ForMember(t => t.TagAssignment, opt => opt.MapFrom(s => s.Tags))
                .ForMember(t => t.Properties, opt => opt.MapFrom(s => s.Properties))
                .ForMember(t => t.Claims, opt => opt.MapFrom(s => s.Claims));
        }

    }
}