// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     An OData Configuration object to define the shape of an
    ///     <see cref="TenantDto" />, and relate it to a Controller.
    /// </summary>
    /// <seealso cref="ModuleGuidIdODataModelBuilderConfigurationBase{T}" />
    public class TenantOdataModelBuilderConfiguration
        : ModuleGuidIdODataModelBuilderConfigurationBase<TenantDto>
    {
    }
}