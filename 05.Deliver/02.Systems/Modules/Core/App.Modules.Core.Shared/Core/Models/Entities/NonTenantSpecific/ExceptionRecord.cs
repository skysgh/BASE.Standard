using App.Modules.Models.Entities;

namespace App.Modules.Core.Models.Entities
{
    public class ExceptionRecord : DiagnosticsTraceRecord
    {
        public string Stack { get; set; }
    }
}
