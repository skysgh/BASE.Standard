using System;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Entities
{

    public class DiagnosticsTraceRecord : 
        IHasGuidId,
        //IHasTimestamp,
        IHasDateTimeCreatedUtc
    {
        public DiagnosticsTraceRecord()
        {
            this.Id = GuidFactory.NewGuid();

        }
        public Guid Id { get; set; }


        public DateTime DateTimeCreatedUtc { get; set; }

        public TraceLevel Level { get; set; }

        public string ThreadId { get; set; }

        public string ClientId { get; set; }

        public string Message { get; set; }

    }
}
