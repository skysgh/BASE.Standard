using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    public abstract class MapBase<TEntity, TDto> : Profile
    {
        public MapBase()
        {
            ConfigureMapFromEntityToDto(CreateMap<TEntity, TDto>());
            ConfigureMapFromDtoToEntity(CreateMap<TDto, TEntity>());
        }

 
        protected abstract void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression);


        protected abstract void ConfigureMapFromDtoToEntity(
            IMappingExpression<TDto, TEntity> mappingExpression);
    }

}
