namespace App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Messages;
    using App.Modules.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_ConfigurationStepRecord_ConfigurationStepRecordDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            Map_ConfigurationStepRecord_ConfigurationStepRecordDto(config);
            Map_ConfigurationStepRecordDto_ConfigurationStepRecord(config);
        }

        public void Map_ConfigurationStepRecord_ConfigurationStepRecordDto(IMapperConfigurationExpression config)
        {
            config.CreateMap<ConfigurationStepRecord, ConfigurationStepRecordDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DateTime, opt => opt.MapFrom(s => s.DateTime))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                ;
        }

        public void Map_ConfigurationStepRecordDto_ConfigurationStepRecord(IMapperConfigurationExpression config)
        {
            config.CreateMap<ConfigurationStepRecordDto, ConfigurationStepRecord>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DateTime, opt => opt.MapFrom(s => s.DateTime))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                ;
        }

    }
}