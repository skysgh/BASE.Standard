using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages.API.V0100;
using App.Modules.Models.Entities;
using App.Modules.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_DiagnosticsTraceRecord_DiagnosticsTraceRecordDto
        : MapBase<
            DiagnosticsTraceRecord,
            DiagnosticsTraceRecordDto>,
        IHasAutomapperInitializer
    {


        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<DiagnosticsTraceRecord, DiagnosticsTraceRecordDto> mappingExpression)
        {

            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                .ForMember(t => t.ThreadId, opt => opt.MapFrom(s => s.ThreadId))
                .ForMember(t => t.ClientId, opt => opt.MapFrom(s => s.ClientId))
                .ForMember(t => t.Message, opt => opt.MapFrom(s => s.Message))
                ;
            //base.ConfigureMapEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(IMappingExpression<DiagnosticsTraceRecordDto, DiagnosticsTraceRecord> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.ThreadId, opt => { opt.MapFrom(s => s.ThreadId); })
                .ForMember(t => t.ClientId, opt => { opt.MapFrom(s => s.ClientId); })
                .ForMember(t => t.ClientId, opt => { opt.MapFrom(s => s.ClientId); })
                .ForMember(t => t.Message, opt => { opt.MapFrom(s => s.Message); })
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

    }
}