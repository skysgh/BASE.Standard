namespace App.Modules.Core.Shared.Models.Entities
{
    using System;

    public class ExceptionRecord : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase
    {
        public TraceLevel Level { get; set; }
        public string Title { get; set; }
        public string Stack { get; set; }
    }
}
