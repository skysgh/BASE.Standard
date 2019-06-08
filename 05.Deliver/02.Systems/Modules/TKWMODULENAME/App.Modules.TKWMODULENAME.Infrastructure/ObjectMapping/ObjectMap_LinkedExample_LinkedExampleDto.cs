﻿using App.Modules.All.Infrastructure.ObjectMapping;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.TKWMODULENAME.Shared.Models.Entities;
using App.Modules.TKWMODULENAME.Shared.Models.Messages;
using AutoMapper;

namespace App.Modules.TKWMODULENAME.Infrastructure.ObjectMapping
{
    public class ObjectMap_LinkedExample_LinkedExampleDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<LinkedExample, LinkedExampleDto>,
            IHasAutomapperInitializer
    {

        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<LinkedExample, LinkedExampleDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                //More interesting:
                .ForMember(t => t.DataClassificationFK, opt => opt.MapFrom(s => s.DataClassificationFK))
                .ForMember(t => t.DataClassification, opt => opt.MapFrom(s=>s.DataClassification))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<LinkedExampleDto, LinkedExample> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                //More interesting:
                .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}