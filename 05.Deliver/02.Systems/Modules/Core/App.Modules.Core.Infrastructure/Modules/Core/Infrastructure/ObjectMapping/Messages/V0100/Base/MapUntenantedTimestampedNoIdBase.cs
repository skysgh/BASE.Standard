using App.Modules.All.Shared.Models;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    /// <summary>
    /// Base class for mapping
    /// between Dtos and Entities
    /// that have
    /// Timestamps (all Entities do),
    /// and no Tenancy Id attribute,
    /// but not necessarily a defined Id
    /// (see a subclass for that).
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <seealso cref="MapBase{TEntity, TDto}" />
    public abstract class MapUntenantedTimestampedNoIdBase<TEntity, TDto> :
        MapBase<TEntity, TDto>
        where TEntity : IHasTimestamp

    {
        /// <summary>
        /// Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression)
        {
            // Timestamp is missing in target Dto, so no need to define it.
            //.ForMember(dest => dest.Timestamp, opt => opt.Ignore())
        }


        /// <summary>
        /// Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TDto, TEntity> mappingExpression)
        {
            mappingExpression
                // There is no Timestamp on Dto to read:
                .ForMember(dest => dest.Timestamp, opt => opt.Ignore())
                ;
        }
    }

}
