using System;
using App.Modules.Core.Models;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Models.Messages.API.V0100
{
    public class ExceptionRecordDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ :
        IHasGuidId
    {
        public Guid Id { get; set; }
        //TODO: Convert to DateTimeOffset?
        public DateTime CreatedOnUtc { get; set; }
        public TraceLevel Level { get; set; }
        public string ThreadId { get; set; }

        public string ClientId { get; set; }

        public string Title { get; set; }
        public string Stack { get; set; }
    }
}