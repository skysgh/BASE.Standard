﻿using App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100.Base;

namespace App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_ExceptionRecord_ExceptionRecordDto 
        : MapUntenantedAuditedRecordStateBase<ExceptionRecordDto, ExceptionRecord>,
        IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_ExceptionRecord_ExceptionRecordDto(config);
            Map_ExceptionRecordDto_ExceptionRecord(config);
        }

        public void Map_ExceptionRecord_ExceptionRecordDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<ExceptionRecord, ExceptionRecordDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.CreatedOnUtc))
                .ForMember(t => t.Title, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Stack, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Stack); })
                ;
        }

        public void Map_ExceptionRecordDto_ExceptionRecord(IMapperConfigurationExpression config)
        {
            var mappingExpression = config.CreateMap<ExceptionRecordDto, ExceptionRecord>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.CreatedOnUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                .ForMember(t => t.Title, opt => { opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Stack, opt => {  opt.MapFrom(s => s.Stack); })
                ;
            MapBase(mappingExpression);
        }
    }
}