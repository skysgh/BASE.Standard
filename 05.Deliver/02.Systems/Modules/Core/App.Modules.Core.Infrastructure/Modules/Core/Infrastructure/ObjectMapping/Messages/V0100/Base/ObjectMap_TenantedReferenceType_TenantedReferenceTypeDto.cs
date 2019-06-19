using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    /// <summary>
    /// Base class for mapping
    /// between
    /// ReferenceData
    /// Dtos and Entities
    /// that have
    /// Timestamps (all Entities do),
    /// and RecordState (most entities do),
    /// and Tenancy Id attribute,
    /// and Guid Id
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TDto">The type of the dto.</typeparam>
    /// <seealso cref="MapBase{TEntity, TDto}" />
    public abstract class ObjectMap_TenantedReferenceType_TenantedReferenceTypeDto<TEntity, TDto>
        : MapBase<TEntity, TDto>
        where TEntity : TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase
        where TDto : TenantedRecordStateGuidIdReferenceDtoBase
    {


        /// <summary>
        /// Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        /// <summary>
        /// Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<TDto, TEntity> mappingExpression)
        {
            mappingExpression
                .ForMember(dest => dest.RecordState, opt => opt.Ignore())
                ;
            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}