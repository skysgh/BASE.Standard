using App.Modules.All.Infrastructure.ObjectMapping;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base
{
    public abstract class MapBase<TEntity, TDto> : IHasAutomapperInitializer
    {

        public virtual void Initialize(IMapperConfigurationExpression config)
        {
            ConfigureMapFromEntityToDto(config.CreateMap<TEntity,TDto>());
            ConfigureMapFromDtoToEntity(config.CreateMap<TDto,TEntity>());
        }

        protected abstract void ConfigureMapFromEntityToDto(
            IMappingExpression<TEntity, TDto> mappingExpression);


        protected abstract void ConfigureMapFromDtoToEntity(
            IMappingExpression<TDto, TEntity> mappingExpression);
    }

}
