namespace App.Modules.Core.Shared.Models.Entities
{
    public class ExceptionRecord : DiagnosticsTraceRecord
    {
        public string Stack { get; set; }
    }
}
