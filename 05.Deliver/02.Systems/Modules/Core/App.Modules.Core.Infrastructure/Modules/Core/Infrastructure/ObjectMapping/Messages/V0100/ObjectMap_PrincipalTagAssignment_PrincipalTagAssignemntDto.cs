using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_PrincipalTagAssignment_PrincipalTagAssignemntDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<
            PrincipalTagAssignment,
            PrincipalTagAssignmentDto>
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<PrincipalTagAssignment, PrincipalTagAssignmentDto
                >
                mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Principal,
                    opt => opt.MapFrom(s => s.Principal))
                .ForMember(t => t.Tag, opt => opt.MapFrom(s => s.Tag))
                ;
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<PrincipalTagAssignmentDto, PrincipalTagAssignment
            > mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.PrincipalFK,
                    opt => opt.MapFrom(s => s.Principal.Id))
                .ForMember(t => t.Principal,
                    opt => opt.MapFrom(s => s.Principal))
                .ForMember(t => t.TagFK,
                    opt => opt.MapFrom(s => s.Tag.Id))
                .ForMember(t => t.Tag,
                    opt => opt.MapFrom(s => s.Tag))
                ;

        }

    }
}


