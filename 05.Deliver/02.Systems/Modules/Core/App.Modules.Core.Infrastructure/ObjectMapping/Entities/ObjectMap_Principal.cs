using App.Modules.Core.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Entities
{
    public class ObjectMap_Principal : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            var mapping = config.CreateMap<Principal, Principal>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryFK, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.DataClassificationFK, opt => opt.Ignore())
                .ForMember(dest => dest.DataClassification, opt => opt.Ignore());
            MapCollections(mapping);
            mapping
                .ForAllOtherMembers(opt => opt.Condition((src, dest, srcVal, destVal, c) => srcVal != null));
        }

        private void MapCollections(IMappingExpression<Principal, Principal> mappingExpression)
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
