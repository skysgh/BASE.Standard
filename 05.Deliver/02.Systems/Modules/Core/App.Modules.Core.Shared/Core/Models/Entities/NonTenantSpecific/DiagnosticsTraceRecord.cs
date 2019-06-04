using System;
using App.Modules.Core.Factories;
using App.Modules.Core.Models;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Models.Entities
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
