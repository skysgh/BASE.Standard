// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     Configuration object to describe the DTO and the Controller from which to retrieve it.
    /// </summary>
    /// <seealso
    ///     cref="App.Modules.All.AppFacade.Controllers.Api.OData.Configuration.ModuleGuidIdODataModelBuilderConfigurationBase{ConfigurationStepRecordDto}" />
    public class ConfigurationStepRecordOdataModelBuilderConfiguration
        : ModuleGuidIdODataModelBuilderConfigurationBase<ConfigurationStepRecordDto
        > //, IAppCoreOdataModelBuilderConfiguration
    {
    }
}