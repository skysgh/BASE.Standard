using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    /// Configuration object to describe the DTO and the Controller from which to retrieve it.
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.Configuration.ModuleGuidIdODataModelBuilderConfigurationBase{ConfigurationStepRecordDto}" />
    public class ConfigurationStepRecordOdataModelBuilderConfiguration 
        : ModuleGuidIdODataModelBuilderConfigurationBase<ConfigurationStepRecordDto> //, IAppCoreOdataModelBuilderConfiguration
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStepRecordOdataModelBuilderConfiguration"/> class.
        /// </summary>
        /// <internal>
        /// Remember to make these constructors public or reflection for 
        /// <see cref="IModuleOdataModelBuilderConfiguration"/> won't find them.
        /// </internal>
        public ConfigurationStepRecordOdataModelBuilderConfiguration() : base()
        {

        }

    }
}