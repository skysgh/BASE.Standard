using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    public abstract class MapUntenantedTimestampedNoIdBase<TEntity, TDto> :
        MapBase<TEntity, TDto>
        where TEntity : IHasTimestamp

    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression)
        {
            // Timestamp is missing in target Dto, so no need to define it.
            //.ForMember(dest => dest.Timestamp, opt => opt.Ignore())
        }


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
