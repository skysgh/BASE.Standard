// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.DTOs;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     An OData Configuration object to define the shape of an
    ///     <see cref="UserProfileDto" />, and relate it to a Controller.
    /// </summary>
    /// <seealso cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}" />
    public class
        UserProfileODataModelBuilderConfiguration : ModuleGuidIdODataModelBuilderConfigurationBase<UserProfileDto>
    {
    }
}