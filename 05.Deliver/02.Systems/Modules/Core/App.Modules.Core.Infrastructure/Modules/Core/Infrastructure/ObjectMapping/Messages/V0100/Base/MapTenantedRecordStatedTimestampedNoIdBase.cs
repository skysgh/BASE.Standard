using App.Modules.All.Shared.Models.Entities;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    /// <summary>
    /// Base class for mapping
    /// between Dtos and Entities
    /// that have
    /// Timestamps (all Entities do),
    /// and RecordState (most entities do),
    /// but no Tenancy Id attribute,
    /// and not necessarily a defined Id
    /// (see a subclass for that).
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <seealso cref="MapUntenantedRecordStatedTimestampedNoIdBase{TEntity, TDto}" />
    public abstract class MapTenantedRecordStatedTimestampedNoIdBase<TEntity, TDto>
        : MapUntenantedRecordStatedTimestampedNoIdBase<TEntity, TDto>
    where TEntity : TenantFKRecordStatedTimestampedNoIdEntityBase

    {
        /// <summary>
        /// Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression)
        {
            // RecordState is not sent out on Dto (it's an internal flag)
            // TenantFK is missing on target Dto, so no need to define it.
        }

        /// <summary>
        /// Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
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
