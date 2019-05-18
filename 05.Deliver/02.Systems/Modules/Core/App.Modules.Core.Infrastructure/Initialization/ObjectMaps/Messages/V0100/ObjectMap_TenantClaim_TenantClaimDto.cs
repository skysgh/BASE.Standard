﻿using App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_TenantClaim_TenantClaimDto
        : MapUntenantedAuditedRecordStateBase<TenantClaimDto, TenantClaim>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_TenantClaim_TenantClaimDto(config);
            Map_TenantClaimDto_TenantClaim(config);
        }

        public void Map_TenantClaim_TenantClaimDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<TenantClaim, TenantClaimDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.AuthorityKey, opt => opt.MapFrom(s => s.Authority))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                .ForMember(t => t.Signature, opt => opt.MapFrom(s => s.AuthoritySignature))
                ;
        }

        public void Map_TenantClaimDto_TenantClaim(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<TenantClaimDto, TenantClaim>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                    .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                    .ForMember(t => t.Authority, opt => opt.MapFrom(s => s.AuthorityKey))
                    .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                    .ForMember(t => t.Value, opt => opt.MapFrom(s => s.Value))
                    .ForMember(t => t.AuthoritySignature, opt => opt.MapFrom(s => s.Signature))
                ;
            MapBase(mappingExpression);
        }

    }
}