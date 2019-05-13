﻿namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using App.Modules.Core.Shared.Models.Entities;

    public class ExceptionRecordDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ :  IHasGuidId
    {
        public Guid Id { get; set; }
        //TODO: Convert to DateTimeOffset?
        public DateTimeOffset? DateTimeCreatedUtc { get; set; }
        public TraceLevel Level { get; set; }
        public string Title { get; set; }
        public string Stack { get; set; }
    }
}