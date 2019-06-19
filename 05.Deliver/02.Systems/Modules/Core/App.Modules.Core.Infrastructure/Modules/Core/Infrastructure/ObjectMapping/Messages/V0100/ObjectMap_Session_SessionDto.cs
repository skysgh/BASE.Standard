using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    /// Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapUntenantedRecordStatedTimestampedNoIdBase{Session, SessionDto}" />
    public class ObjectMap_Session_SessionDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<Session, SessionDto>
    {
        /// <summary>
        /// Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<Session, SessionDto> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.StartDateTimeUtc, opt => opt.MapFrom(s => s.UtcDateTimeCreated))
                    .ForMember(t => t.Principal, opt => opt.MapFrom(s => s.Principal))
                    .ForMember(t => t.Operations, opt => { opt.ExplicitExpansion(); opt.MapFrom(s => s.Operations); })
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        /// Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<SessionDto, Session> mappingExpression)
        {
            mappingExpression
                    .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                    .ForMember(t => t.UtcDateTimeCreated, opt => opt.MapFrom(s => s.StartDateTimeUtc))
                    .ForMember(t => t.Principal, opt => opt.MapFrom(s => s.Principal))
                    .ForMember(t => t.Operations, opt => opt.Ignore())
                    .ForMember(t => t.PrincipalFK, opt => opt.Ignore())
                    .ForMember(t => t.UniqueIdentifier, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}