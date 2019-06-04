﻿using System;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class PrincipalPropertyDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasRecordState, IHasKey
    {
        public virtual Guid PrincipalFK { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid Id { get; set; }
        public virtual string Key { get; set; }
        public virtual RecordPersistenceState RecordState { get; set; }
    }
}