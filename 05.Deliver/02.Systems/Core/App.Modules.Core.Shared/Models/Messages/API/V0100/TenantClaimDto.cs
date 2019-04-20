﻿namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using App.Modules.Core.Shared.Models.Entities;

    [Serializable]
    public class TenantClaimDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  : IHasGuidId, IHasTenantFK, IHasRecordState
    {
        public virtual string AuthorityKey { get; set; }
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual string Signature { get; set; }
        public virtual Guid Id { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
        public virtual Guid TenantFK { get; set; }
    }
}