using App.Modules.All.Infrastructure.ObjectMapping;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.TKWMODULENAME.Shared.Models.Entities;
using App.Modules.TKWMODULENAME.Shared.Models.Messages;
using AutoMapper;

namespace App.Modules.TKWMODULENAME.Infrastructure.ObjectMapping
{
    public class ObjectMap_Example_ExampleDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<Example, ExampleDto>,
            IHasAutomapperInitializer
    {
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<Example, ExampleDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                ;

            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ExampleDto, Example> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(t => t.Description, opt => opt.MapFrom(s => s.Description))
                ;

            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}