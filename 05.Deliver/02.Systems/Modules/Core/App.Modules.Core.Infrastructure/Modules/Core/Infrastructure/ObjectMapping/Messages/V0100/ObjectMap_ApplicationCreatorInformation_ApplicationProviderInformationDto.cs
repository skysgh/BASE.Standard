using App.Modules.Core.Shared.Configuration.Settings;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_ApplicationCreatorInformation_ApplicationProviderInformationDto
        : MapBase<
            ApplicationCreatorInformationConfigurationSettings, 
            ApplicationProviderInformationDto>
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ApplicationCreatorInformationConfigurationSettings, ApplicationProviderInformationDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.SiteUrl, opt => opt.MapFrom(s => s.SiteUrl))
                .ForMember(t => t.ContactUrl, opt => opt.MapFrom(s => s.ContactUrl))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }


        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ApplicationProviderInformationDto, ApplicationCreatorInformationConfigurationSettings> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.SiteUrl, opt => opt.MapFrom(s => s.SiteUrl))
                .ForMember(t => t.ContactUrl, opt => opt.MapFrom(s => s.ContactUrl))
                ;
            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}