using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    public abstract class MapTenantedRecordStatedTimestampedNoIdBase<TEntity, TDto>
        : MapUntenantedRecordStatedTimestampedNoIdBase<TEntity,TDto>
    where TEntity : TenantFKRecordStatedTimestampedNoIdEntityBase

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
                // The Dto does not have the Tenant information
                // AND tHe FK will be filled when saving:
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                ;
            // Base handles Timestamp:
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }

}
