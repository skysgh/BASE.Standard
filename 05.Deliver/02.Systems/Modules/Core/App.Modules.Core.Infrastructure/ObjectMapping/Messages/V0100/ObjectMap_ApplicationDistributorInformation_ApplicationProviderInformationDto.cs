using App.Modules.Core.Configuration.Settings;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class
        ObjectMap_ApplicationDistributorInformation_ApplicationProviderInformationDto
        : MapBase<ApplicationDistributorInformationConfigurationSettings, ApplicationProviderInformationDto>,
        IHasAutomapperInitializer
    {

        protected override void ConfigureMapFromEntityToDto(
    IMappingExpression<ApplicationDistributorInformationConfigurationSettings, ApplicationProviderInformationDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.SiteUrl, opt => opt.MapFrom(s => s.SiteUrl))
                .ForMember(t => t.ContactUrl, opt => opt.MapFrom(s => s.ContactUrl))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }


        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ApplicationProviderInformationDto, ApplicationDistributorInformationConfigurationSettings> mappingExpression)
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