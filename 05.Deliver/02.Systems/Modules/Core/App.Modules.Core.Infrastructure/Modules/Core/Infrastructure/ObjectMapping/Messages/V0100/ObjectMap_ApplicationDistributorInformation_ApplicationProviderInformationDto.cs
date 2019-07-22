// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Infrastructure.Services.Configuration;
using App.Modules.Core.Shared.Models.DTOs;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    public class ObjectMap_ApplicationDistributorInformation_ApplicationProviderInformationDto
        : MapBase<ApplicationProviderInformation, ApplicationProviderInformationDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ApplicationProviderInformation, ApplicationProviderInformationDto
            > mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Key, opt => opt.MapFrom(s => s.Key))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.SiteUrl, opt => opt.MapFrom(s => s.SiteUrl))
                .ForMember(t => t.ContactUrl, opt => opt.MapFrom(s => s.ContactUrl))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }


        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ApplicationProviderInformationDto, ApplicationProviderInformation
            > mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Key, opt => opt.MapFrom(s=>s.Key))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.SiteUrl, opt => opt.MapFrom(s => s.SiteUrl))
                .ForMember(t => t.ContactUrl, opt => opt.MapFrom(s => s.ContactUrl))
                ;
            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}