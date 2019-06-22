// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Configuration.Settings;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    public class ObjectMap_ApplicationDistributorInformation_ApplicationProviderInformationDto
        : MapBase<ApplicationDistributorInformationConfigurationSettings, ApplicationProviderInformationDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ApplicationDistributorInformationConfigurationSettings, ApplicationProviderInformationDto
            > mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
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
            IMappingExpression<ApplicationProviderInformationDto, ApplicationDistributorInformationConfigurationSettings
            > mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.SiteUrl, opt => opt.MapFrom(s => s.SiteUrl))
                .ForMember(t => t.ContactUrl, opt => opt.MapFrom(s => s.ContactUrl))
                ;
            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}