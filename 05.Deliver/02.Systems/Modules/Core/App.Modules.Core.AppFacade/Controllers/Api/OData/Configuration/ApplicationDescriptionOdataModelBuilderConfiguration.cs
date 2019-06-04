using App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Models.Messages.API.V0100;

namespace App.Core.Application.Initialization.OData.Implementations
{
    public class ApplicationDescriptionOdataModelBuilderConfiguration : AllModulesGuidIdODataModelBuilderConfigurationBase<ApplicationDescriptionDto>
    {
        public ApplicationDescriptionOdataModelBuilderConfiguration() : base()
        {

        }
    }
}