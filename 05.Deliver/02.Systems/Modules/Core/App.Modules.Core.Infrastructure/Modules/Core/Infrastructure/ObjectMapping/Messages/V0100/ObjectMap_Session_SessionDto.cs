using App.Modules.All.Infrastructure.ObjectMapping;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_Session_SessionDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<Session, SessionDto>,
            IHasAutomapperInitializer
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<Session, SessionDto> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.StartDateTimeUtc, opt => opt.MapFrom(s => s.DateTimeCreatedUtc))
                    .ForMember(t => t.Principal, opt => opt.MapFrom(s => s.Principal))
                    .ForMember(t => t.Operations, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Operations); })
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<SessionDto, Session> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.DateTimeCreatedUtc, opt => opt.MapFrom(s => s.StartDateTimeUtc))
                    .ForMember(t => t.Principal, opt => opt.MapFrom(s => s.Principal))
                    .ForMember(t => t.Operations, opt => opt.Ignore())
                    .ForMember(t => t.PrincipalFK, opt => opt.Ignore())
                    .ForMember(t => t.UniqueIdentifier, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}