namespace App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class
        ObjectMap_ApplicationDistributorInformation_ApplicationProviderInformationDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ApplicationDistributorInformationConfigurationSettings, ApplicationProviderInformationDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(t => t.SiteUrl, opt => opt.MapFrom(s => s.SiteUrl))
                .ForMember(t => t.ContactUrl, opt => opt.MapFrom(s => s.ContactUrl))
                ;
        }

    }
}