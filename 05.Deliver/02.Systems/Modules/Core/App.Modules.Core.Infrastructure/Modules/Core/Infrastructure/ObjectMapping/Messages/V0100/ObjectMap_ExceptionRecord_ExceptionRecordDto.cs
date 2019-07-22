// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    ///     Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapBase{TEntity,TDto}" />
    public class ObjectMap_ExceptionRecord_ExceptionRecordDto
        : MapBase<
            ExceptionRecord,
            ExceptionRecordDto>
    {
        /// <summary>
        ///     Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ExceptionRecord, ExceptionRecordDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                //Does not have RecordState or Tenant.
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.CreatedOnUtc, opt => opt.MapFrom(s => s.UtcDateTimeCreated))
                .ForMember(t => t.ThreadId, opt => { opt.MapFrom(s => s.ThreadId); })
                .ForMember(t => t.ClientId, opt => { opt.MapFrom(s => s.ClientId); })
                .ForMember(t => t.Title, opt =>
                {
                    opt.ExplicitExpansion();
                    opt.MapFrom(s => s.Message);
                })
                .ForMember(t => t.Stack, opt =>
                {
                    opt.ExplicitExpansion();
                    opt.MapFrom(s => s.Stack);
                })
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        ///     Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ExceptionRecordDto, ExceptionRecord> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Level, opt => opt.MapFrom(s => s.Level))
                .ForMember(t => t.UtcDateTimeCreated, opt => opt.MapFrom(s => s.CreatedOnUtc))
                .ForMember(t => t.ThreadId, opt => { opt.MapFrom(s => s.ThreadId); })
                .ForMember(t => t.ClientId, opt => { opt.MapFrom(s => s.ClientId); })
                .ForMember(t => t.Message, opt => { opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Stack, opt => { opt.MapFrom(s => s.Stack); })
                ;

            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }
}