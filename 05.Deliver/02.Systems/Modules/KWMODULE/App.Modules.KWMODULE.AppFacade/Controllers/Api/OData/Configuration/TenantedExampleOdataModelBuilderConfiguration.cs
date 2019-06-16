using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.KWMODULE.Shared.Models.Messages;

namespace App.Modules.KWMODULE.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    /// OData Configuration to describe the specified DTO,
    /// and the Controller
    /// from which to retrieve it.
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.Configuration.ModuleGuidIdODataModelBuilderConfigurationBase{App.Modules.KWMODULE.Shared.Models.Messages.TenantedExampleDto}" />
    public class TenantedExampleOdataModelBuilderConfiguration : ModuleGuidIdODataModelBuilderConfigurationBase<TenantedExampleDto>
    {
        public TenantedExampleOdataModelBuilderConfiguration()
        {
        }
    }


}