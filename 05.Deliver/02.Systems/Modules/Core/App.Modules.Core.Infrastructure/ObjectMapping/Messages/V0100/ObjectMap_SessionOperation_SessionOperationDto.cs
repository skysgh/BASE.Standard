using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_SessionOperation_SessionOperationDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<SessionOperation, SessionOperationDto>,
            IHasAutomapperInitializer
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<SessionOperation, SessionOperationDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.BeginDateTimeUtc, opt => opt.MapFrom(s => s.BeginDateTimeUtc))
                .ForMember(t => t.EndDateTimeUtc, opt => opt.MapFrom(s => s.EndDateTimeUtc))
                .ForMember(t => t.Duration, opt => opt.MapFrom(s => s.Duration))
                .ForMember(t => t.ClientIp, opt => opt.MapFrom(s => s.ClientIp))
                .ForMember(t => t.Url, opt => opt.MapFrom(s => s.Url))
                .ForMember(t => t.ActionName, opt => opt.MapFrom(s => s.ActionName))
                .ForMember(t => t.ActionArguments, opt => opt.MapFrom(s => s.ActionArguments))
                .ForMember(t => t.ControllerName, opt => opt.MapFrom(s => s.ControllerName))
                .ForMember(t => t.ResponseCode, opt => opt.MapFrom(s => s.ResponseCode))
                //Relationships
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<SessionOperationDto, SessionOperation> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.BeginDateTimeUtc, opt => opt.MapFrom(s => s.BeginDateTimeUtc))
                .ForMember(t => t.EndDateTimeUtc, opt => opt.MapFrom(s => s.EndDateTimeUtc))
                .ForMember(t => t.Duration, opt => opt.MapFrom(s => s.Duration))
                .ForMember(t => t.ClientIp, opt => opt.MapFrom(s => s.ClientIp))
                .ForMember(t => t.Url, opt => opt.MapFrom(s => s.Url))
                .ForMember(t => t.ActionName, opt => opt.MapFrom(s => s.ActionName))
                .ForMember(t => t.ActionArguments, opt => opt.MapFrom(s => s.ActionArguments))
                .ForMember(t => t.ControllerName, opt => opt.MapFrom(s => s.ControllerName))
                .ForMember(t => t.ResponseCode, opt => opt.MapFrom(s => s.ResponseCode))
                .ForMember(t => t.SessionFK, opt => opt.Ignore())
                //Relationships
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}


