using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.KWMODULE.Shared.Models.Messages;

namespace App.Modules.KWMODULE.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     OData Configuration to describe the specified DTO,
    ///     and the Controller
    ///     from which to retrieve it.
    /// </summary>
    /// <seealso cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}" />
    public class ExampleOdataModelBuilderConfiguration : ModuleGuidIdODataModelBuilderConfigurationBase<ExampleDto>
    {
    }
}