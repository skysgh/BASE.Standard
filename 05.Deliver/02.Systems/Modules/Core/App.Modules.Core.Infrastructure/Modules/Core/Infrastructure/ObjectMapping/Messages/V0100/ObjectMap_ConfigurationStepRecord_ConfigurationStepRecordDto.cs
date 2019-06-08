using App.Modules.All.Infrastructure.ObjectMapping;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Messages;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_ConfigurationStepRecord_ConfigurationStepRecordDto
        :
        MapBase<ConfigurationStepRecord, ConfigurationStepRecordDto>,
        IHasAutomapperInitializer
    {

        protected override void ConfigureMapFromEntityToDto(IMappingExpression<ConfigurationStepRecord, ConfigurationStepRecordDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DateTime, opt => opt.MapFrom(s => s.DateTime))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(IMappingExpression<ConfigurationStepRecordDto, ConfigurationStepRecord> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DateTime, opt => opt.MapFrom(s => s.DateTime))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(t => t.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Type, opt => opt.MapFrom(s => s.Type))
                ;
            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}