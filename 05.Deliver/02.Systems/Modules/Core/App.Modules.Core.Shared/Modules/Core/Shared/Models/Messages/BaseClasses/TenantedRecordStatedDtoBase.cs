using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages
{
    public abstract class TenantedRecordStatedDtoBase : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ IHasTenantFK, IHasRecordState
    {
        public virtual RecordPersistenceState RecordState
        {
            get; set;
        }

        public virtual Guid TenantFK
        {
            get; set;
        }
    }
}