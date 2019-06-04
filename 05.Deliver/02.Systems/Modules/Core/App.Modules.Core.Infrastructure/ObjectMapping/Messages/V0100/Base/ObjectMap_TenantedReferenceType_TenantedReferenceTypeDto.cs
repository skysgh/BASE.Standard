using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    public abstract class ObjectMap_TenantedReferenceType_TenantedReferenceTypeDto<TEntity,TDto> 
        : MapBase<TEntity,TDto>
        where TEntity : TenantFKRecordStatedTimestampedGuidIdReferenceDataEntityBase
        where TDto: TenantedRecordStateGuidIdReferenceDtoBase
    {


        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.TenantFK, opt => opt.MapFrom(s => s.TenantFK))
                .ForMember(t => t.RecordState, opt => opt.MapFrom(s => s.RecordState))
                .ForMember(t => t.Text, opt => opt.MapFrom(s => s.Title))
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }

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