using App.Modules.Core.Shared.Configuration.Settings;
using App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100.Base;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping.Messages.V0100
{
    /// <summary>
    /// Create custom Maps for the Entity and its Dto.
    /// </summary>
    /// <seealso cref="MapBase{ApplicationDescriptionConfigurationSettings, ApplicationDescriptionDto}" />
    public class ObjectMap_ApplicationDescription_ApplicationDescriptionDto 
        :
        MapBase<ApplicationDescriptionConfigurationSettings, ApplicationDescriptionDto>
    {
        /// <summary>
        /// Configures the map from entity to dto.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromEntityToDto(
            IMappingExpression<ApplicationDescriptionConfigurationSettings, ApplicationDescriptionDto> mappingExpression)
        {
            mappingExpression
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))

                // TODO: Find a way to map these across
                .ForMember(t => t.Creator, opt => opt.Ignore())
                .ForMember(t => t.Description, opt => opt.Ignore())
                .ForMember(t => t.Distributor, opt => opt.Ignore())
                ;
            //base.ConfigureMapFromEntityToDto(mappingExpression);
        }


        /// <summary>
        /// Configures the map from dto to entity.
        /// </summary>
        /// <param name="mappingExpression">The mapping expression.</param>
        protected override void ConfigureMapFromDtoToEntity(
            IMappingExpression<ApplicationDescriptionDto, ApplicationDescriptionConfigurationSettings> mappingExpression)
        {

            //base.ConfigureMapFromDtoToEntity(mappingExpression);
        }


    }
}