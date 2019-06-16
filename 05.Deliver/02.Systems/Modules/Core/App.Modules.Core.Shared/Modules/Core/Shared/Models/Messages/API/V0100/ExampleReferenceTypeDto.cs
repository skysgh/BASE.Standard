using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Messages.TenantedRecordStateGuidIdReferenceDtoBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTenantFK" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    public class ExampleReferenceTypeDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : TenantedRecordStateGuidIdReferenceDtoBase, IHasGuidId, IHasTenantFK, IHasRecordState
    {
    }
}


