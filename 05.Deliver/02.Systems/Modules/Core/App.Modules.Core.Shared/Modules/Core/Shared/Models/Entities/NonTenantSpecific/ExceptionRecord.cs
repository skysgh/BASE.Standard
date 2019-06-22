// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     An exception record.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Entities.DiagnosticsTraceRecord" />
    public class ExceptionRecord : DiagnosticsTraceRecord
    {
        /// <summary>
        ///     Gets or sets the stack at the time of error.
        /// </summary>
        public string Stack { get; set; }
    }
}