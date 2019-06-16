using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    public class ObjectMap_PrincipalCategory_PrincipalCategoryDto
        : MapUntenantedRecordStatedTimestampedNoIdBase<PrincipalCategory, PrincipalCategoryDto>
    {

        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<PrincipalCategory, PrincipalCategoryDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Text, opt => { opt.MapFrom(s => s.Title); })
                .ForMember(t => t.Description, opt => { opt.MapFrom(s => s.Description); })
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => { opt.MapFrom(s => s.DisplayStyleHint); })
                ;
            base.ConfigureMapFromEntityToDto(mappingExpression);
        }

        protected override void ConfigureMapFromDtoToEntity (IMappingExpression<PrincipalCategoryDto, PrincipalCategory> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Enabled, opt => opt.MapFrom(s => s.Enabled))
                .ForMember(t => t.Title, opt => { opt.MapFrom(s => s.Text); })
                .ForMember(t => t.Description, opt => { opt.MapFrom(s => s.Description); })
                .ForMember(t => t.DisplayOrderHint, opt => opt.MapFrom(s => s.DisplayOrderHint))
                .ForMember(t => t.DisplayStyleHint, opt => { opt.MapFrom(s => s.DisplayStyleHint); })
                ;
            base.ConfigureMapFromDtoToEntity(mappingExpression);
        }

    }
}