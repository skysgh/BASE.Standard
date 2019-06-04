using App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Models.Messages.API.V0100;
using Microsoft.AspNet.OData.Builder;

namespace App.Core.Application.Initialization.OData.Implementations
{
    public class UserProfileODataModelBuilderConfiguration : AllModulesGuidIdODataModelBuilderConfigurationBase<UserProfileDto>
    {
    }
}
