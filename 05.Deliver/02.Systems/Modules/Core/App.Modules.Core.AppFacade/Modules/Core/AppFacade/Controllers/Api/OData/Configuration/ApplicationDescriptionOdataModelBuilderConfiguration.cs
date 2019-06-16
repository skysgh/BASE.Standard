using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    /// An OData Configuration object to define the shape of an
    /// <see cref="ApplicationDescriptionDto"/>, and relate it to a Controller.
    /// </summary>
    /// <seealso cref="ModuleGuidIdODataModelBuilderConfigurationBase{ApplicationDescriptionDto}" />
    public class ApplicationDescriptionOdataModelBuilderConfiguration 
        : ModuleGuidIdODataModelBuilderConfigurationBase<ApplicationDescriptionDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDescriptionOdataModelBuilderConfiguration"/> class.
        /// </summary>
        public ApplicationDescriptionOdataModelBuilderConfiguration() : base()
        {

        }
    }
}