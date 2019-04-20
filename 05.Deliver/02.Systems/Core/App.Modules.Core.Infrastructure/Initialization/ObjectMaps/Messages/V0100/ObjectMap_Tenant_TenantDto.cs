﻿using App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_Tenant_TenantDto
        : MapUntenantedAuditedRecordStateBase<TenantDto, Tenant>,
            IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_Tenant_TenantDto(config);
            Map_TenantDto_Tenant(config);
        }

        public void Map_Tenant_TenantDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<Tenant, TenantDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.HostName, opt => opt.MapFrom(s => s.HostName))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.Properties, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Properties); })
                .ForMember(t => t.Claims, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Claims); })
                ;
        }

        public void Map_TenantDto_Tenant(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<TenantDto, Tenant>()
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.HostName, opt => opt.MapFrom(s => s.HostName))
                    .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                    .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                    .ForMember(t => t.IsDefault, opt => opt.MapFrom(s => s.IsDefault))
                    .ForMember(t => t.DataClassification, opt => {opt.MapFrom(s => s.DataClassification); })
                    .ForMember(t => t.Properties, opt => { opt.MapFrom(s => s.Properties); })
                    .ForMember(t => t.Claims, opt => { opt.MapFrom(s => s.Claims);  })
                    .ForMember(t => t.DataClassificationFK, opt => { opt.Ignore(); })
                ;
            MapBase(mappingExpression);
        }
    }
}