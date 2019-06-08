using App.Modules.All.Infrastructure.ObjectMapping;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_ExceptionRecord_ExceptionRecordDto
        : MapBase<
            ExceptionRecord,
            ExceptionRecordDto>,
        IHasAutomapperInitializer
    {

        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ExceptionRecord, ExceptionRecordDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                //Does not have RecordState or Tenant.
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.CreatedOnUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                .ForMember(t => t.ThreadId, opt => { opt.MapFrom(s => s.ThreadId); })
                .ForMember(t => t.ClientId, opt => { opt.MapFrom(s => s.ClientId); })
                .ForMember(t => t.Title, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Message); })
                .ForMember(t => t.Stack, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Stack); })
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ExceptionRecordDto, ExceptionRecord> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.CreatedOnUtc))
                .ForMember(t => t.ThreadId, opt => { opt.MapFrom(s => s.ThreadId); })
                .ForMember(t => t.ClientId, opt => { opt.MapFrom(s => s.ClientId); })
                .ForMember(t => t.Message, opt => { opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Stack, opt => { opt.MapFrom(s => s.Stack); })
                ;

            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}