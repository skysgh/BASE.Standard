// Copyright MachineBrains, Inc. 2019

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
    public class ObjectMap_Tenant_TenantDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<Tenant, TenantDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<Tenant, TenantDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.HostName, opt => opt.MapFrom(s => s.HostName))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(t => t.DataClassification, opt =>
                {
                    opt.ExplicitExpansion();
                    opt.MapFrom(s => s.DataClassification);
                })
                .ForMember(t => t.Properties, opt =>
                {
                    opt.ExplicitExpansion();
                    opt.MapFrom(s => s.Properties);
                })
                .ForMember(t => t.Claims, opt =>
                {
                    opt.ExplicitExpansion();
                    opt.MapFrom(s => s.Claims);
                })
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TenantDto, Tenant> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.HostName, opt => opt.MapFrom(s => s.HostName))
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.DisplayName, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(t => t.IsDefault, opt => opt.MapFrom(s => s.IsDefault))
                .ForMember(t => t.DataClassification, opt => { opt.MapFrom(s => s.DataClassification); })
                .ForMember(t => t.Properties, opt => { opt.MapFrom(s => s.Properties); })
                .ForMember(t => t.Claims, opt => { opt.MapFrom(s => s.Claims); })
                .ForMember(t => t.DataClassificationFK, opt => { opt.Ignore(); })
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}