using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.KWMODULE.Shared.Models.Messages;

namespace App.Modules.KWMODULE.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     Module Specific
    ///     OData Model Definition.
    ///     <para>
    ///         Describes the specified DTO,
    ///         and the Controller
    ///         from which to retrieve it.
    ///     </para>
    ///     <para>
    ///         Invoked by a Model Builder
    ///         during Startup.
    ///     </para>
    /// </summary>
    /// <seealso cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}" />
    public class
        LinkedExampleOdataModelBuilderConfiguration : ModuleGuidIdODataModelBuilderConfigurationBase<LinkedExampleDto>
    {
    }
}