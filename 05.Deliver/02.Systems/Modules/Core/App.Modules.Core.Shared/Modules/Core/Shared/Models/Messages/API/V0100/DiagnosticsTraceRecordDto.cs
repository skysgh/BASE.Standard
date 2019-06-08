using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    public class DiagnosticsTraceRecordDto/* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ :
        IHasGuidId
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreatedUtc { get; set; }

        public TraceLevel Level { get; set; }

        public string ThreadId { get; set; }

        public string ClientId { get; set; }

        public string Message { get; set; }

    }
}
