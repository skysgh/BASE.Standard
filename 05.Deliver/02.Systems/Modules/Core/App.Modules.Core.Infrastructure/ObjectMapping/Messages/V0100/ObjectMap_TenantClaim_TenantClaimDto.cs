using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_TenantClaim_TenantClaimDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<TenantClaim, TenantClaimDto>,
            IHasAutomapperInitializer
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TenantClaim, TenantClaimDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.AuthorityKey, opt => opt.MapFrom(s => s.Authority))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                .ForMember(t => t.Signature, opt => opt.MapFrom(s => s.AuthoritySignature))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TenantClaimDto, TenantClaim> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                    .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                    .ForMember(t => t.Authority, opt => opt.MapFrom(s => s.AuthorityKey))
                    .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                    .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                    .ForMember(t => t.AuthoritySignature, opt => opt.MapFrom(s => s.Signature))
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}