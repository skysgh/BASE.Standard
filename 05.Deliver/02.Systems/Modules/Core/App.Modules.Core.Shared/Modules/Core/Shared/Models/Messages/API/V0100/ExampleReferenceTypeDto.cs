using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    public class ExampleReferenceTypeDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : TenantedRecordStateGuidIdReferenceDtoBase, IHasGuidId, IHasTenantFK, IHasRecordState
    {
    }
}


