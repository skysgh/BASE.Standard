using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    public abstract class MapUntenantedRecordStatedTimestampedNoIdBase<TEntity, TDto>
        : MapUntenantedTimestampedNoIdBase<TEntity, TDto>
    where TEntity : UntenantedRecordStatedTimestampedNoIdEntityBase

    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression)
        {
            // RecordState is not sent out on Dto (it's an internal flag)
            // TenantFK is missing on target Dto, so no need to define it.
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TDto, TEntity> mappingExpression)
        {
            mappingExpression
                // THere is no RecordState to read on Dto:
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                ;
            // Base handles Timestamp:
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }

}
