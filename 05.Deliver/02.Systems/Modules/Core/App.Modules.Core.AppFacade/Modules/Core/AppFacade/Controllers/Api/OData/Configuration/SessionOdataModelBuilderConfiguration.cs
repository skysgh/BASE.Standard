using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    /// An OData Configuration object to define the shape of an
    /// <see cref="SessionDto"/>, and relate it to a Controller.
    /// <para>
    /// </para>
    /// </summary>
    /// <seealso cref="ModuleGuidIdODataModelBuilderConfigurationBase{SessionDto}" />
    public class SessionOdataModelBuilderConfiguration 
        : ModuleGuidIdODataModelBuilderConfigurationBase<SessionDto>
    {
    }


}