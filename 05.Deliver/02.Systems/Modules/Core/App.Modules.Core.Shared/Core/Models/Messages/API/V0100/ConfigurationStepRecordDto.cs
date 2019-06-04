﻿using System;
using App.Modules.Core.Models.Messages.Enums;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class ConfigurationStepRecordDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public virtual Guid Id { get; set; }
        public virtual DateTimeOffset? DateTime { get; set; }
        public virtual ConfigurationStepType Type { get; set; }
        public virtual string Status { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
    }
}
