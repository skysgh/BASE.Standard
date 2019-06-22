// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapUntenantedRecordStatedTimestampedNoIdBase{TEntity,TDto}" />
    public class ObjectMap_SessionOperation_SessionOperationDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<SessionOperation, SessionOperationDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
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

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
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