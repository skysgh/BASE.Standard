using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    public abstract class MapTenantedRecordStatedTimestampedGuidIdBase<TEntity, TDto>
        : MapUntenantedRecordStatedTimestampedNoIdBase<TEntity,TDto>
    where TEntity : TenantFKRecordStatedTimestampedGuidIdEntityBase
    where TDto :IHasGuidId

    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression)
        {
            mappingExpression.ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id));
            // RecordState is not sent out on Dto (it's an internal flag)
            // TenantFK is missing on target Dto, so no need to define it.
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TDto, TEntity> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                // The Dto does not have the Tenant information
                // AND tHe FK will be filled when saving:
                .ForMember(dest => dest.TenantFK, opt => opt.Ignore())
                ;
            // Base handles Timestamp:
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }
    }

}
