using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.KWMODULE.Shared.Models.Entities;
using App.Modules.KWMODULE.Shared.Models.Messages;
using AutoMapper;

namespace App.Modules.KWMODULE.Infrastructure.ObjectMapping
{
    public class ObjectMap_Example_ExampleDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<Example, ExampleDto>
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