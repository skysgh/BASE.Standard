// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     TODO
    /// </summary>
    /// <seealso cref="TenantedRecordStateGuidIdReferenceDtoBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTenantFK" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    public class ExampleReferenceTypeDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : TenantedRecordStateGuidIdReferenceDtoBase, IHasGuidId, IHasTenantFK, IHasRecordState
    {
    }
}