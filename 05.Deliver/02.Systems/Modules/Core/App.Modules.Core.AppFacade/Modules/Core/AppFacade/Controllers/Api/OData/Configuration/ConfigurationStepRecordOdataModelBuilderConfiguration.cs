using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    public class ConfigurationStepRecordOdataModelBuilderConfiguration 
        : AllModulesGuidIdODataModelBuilderConfigurationBase<ConfigurationStepRecordDto> //, IAppCoreOdataModelBuilderConfiguration
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStepRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IAppCoreOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public ConfigurationStepRecordOdataModelBuilderConfiguration() : base()
        {

        }

    }
}