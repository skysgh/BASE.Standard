// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.Core.Shared.Models.DTOs;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     An OData Configuration object to define the shape of an
    ///     <see cref="TenantClaimDto" />, and relate it to a Controller.
    /// </summary>
    public class TenantClaimOdataModelBuilderConfiguration
        : ModuleGuidIdODataModelBuilderConfigurationBase<TenantClaimDto>
    {
    }
}