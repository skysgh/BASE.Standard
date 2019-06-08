using App.Modules.All.Infrastructure.ObjectMapping;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Design.Shared.Models.Entities;
using App.Modules.Design.Shared.Models.Messages;
using AutoMapper;

namespace App.Modules.Design.Infrastructure.ObjectMapping
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
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ExampleDto, Example> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.DataClassificationFK, opt => opt.Ignore())
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}