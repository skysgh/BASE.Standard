using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Initialization.ObjectMaps;
using App.Modules.Core.Shared.Models.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.Initialization.ObjectMaps.Messages.V0100
{
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Messages;
    using App.Modules.Core.Shared.Models.Messages.API.V0100;
    using AutoMapper;

    public class ObjectMap_ApplicationDescription_ApplicationDescriptionDto : IHasAutomapperInitializer
    {
        public void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<ApplicationDescriptionConfigurationSettings, ApplicationDescriptionDto>()
                .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(s => s.Name))

                // TODO: Find a way to map these across
                .ForMember(t=>t.Creator, opt => opt.Ignore())
                .ForMember(t => t.Description, opt => opt.Ignore())
                .ForMember(t=> t.Distributor, opt=>opt.Ignore())


                ;
        }

    }
}