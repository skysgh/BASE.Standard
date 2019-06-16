using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    /// An OData Configuration object to define the shape of an
    /// <see cref="NotificationDto"/>, and relate it to a Controller.
    /// </summary>
    /// <seealso cref="App.Modules.All.AppFacade.Controllers.Api.OData.Configuration.ModuleGuidIdODataModelBuilderConfigurationBase{NotificationDto}" />
    public class NotificationOdataModelBuilderConfiguration 
        : ModuleGuidIdODataModelBuilderConfigurationBase<NotificationDto>
    {
    }


}