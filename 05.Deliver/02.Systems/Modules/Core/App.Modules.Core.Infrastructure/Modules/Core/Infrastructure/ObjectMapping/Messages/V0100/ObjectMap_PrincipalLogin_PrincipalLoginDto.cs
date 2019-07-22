﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapUntenantedRecordStatedTimestampedNoIdBase{TEntity,TDto}" />
    public class ObjectMap_PrincipalLogin_PrincipalLoginDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<PrincipalLogin, PrincipalLoginDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<PrincipalLogin, PrincipalLoginDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.PrincipalFK, opt => opt.MapFrom(s => s.PrincipalFK))
                .ForMember(t => t.IdPLogin, opt => opt.MapFrom(s => s.IdPLogin))
                .ForMember(t => t.SubLogin, opt => opt.MapFrom(s => s.SubLogin))
                .ForMember(t => t.LastLoggedInUtc, opt => opt.MapFrom(s => s.LastLoggedInUtc))
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<PrincipalLoginDto, PrincipalLogin> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.PrincipalFK, opt => opt.MapFrom(s => s.PrincipalFK))
                .ForMember(t => t.IdPLogin, opt => opt.MapFrom(s => s.IdPLogin))
                .ForMember(t => t.SubLogin, opt => opt.MapFrom(s => s.SubLogin))
                .ForMember(t => t.LastLoggedInUtc, opt => opt.MapFrom(s => s.LastLoggedInUtc))
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}