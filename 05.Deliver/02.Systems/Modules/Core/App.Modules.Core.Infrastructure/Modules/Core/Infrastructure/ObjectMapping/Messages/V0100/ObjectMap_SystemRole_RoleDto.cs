﻿using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_SystemRole_RoleDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<SystemRole, RoleDto>
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<SystemRole, RoleDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.DataClassification, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.ModuleKey,  opt => opt.MapFrom(s => s.ModuleKey))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<RoleDto, SystemRole> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                    .ForMember(t => t.DataClassification, opt => { opt.MapFrom(s => s.DataClassification); })
                    .ForMember(t => t.ModuleKey, opt => opt.MapFrom(s => s.ModuleKey))
                    .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}