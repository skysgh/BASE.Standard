using System;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    [Serializable]
    public class TenantPropertyDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid Id { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual Guid TenantFK { get; set; }
    }
}