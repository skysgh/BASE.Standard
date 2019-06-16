namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// TODO: Enums are evil (offset issue of Interface Localization)
    /// </summary>
    public enum TraceLevel
    {
        /// <summary>
        /// The event is a Critical error.
        /// </summary>
        Critical = 0,
        /// <summary>
        /// The message is about an error.
        /// </summary>
        Error = 1,
        /// <summary>
        /// The message is a warning.
        /// </summary>
        Warn = 2,
        /// <summary>
        /// The message is informational.
        /// </summary>
        Info = 3,
        /// <summary>
        /// The message is a debug message.
        /// </summary>
        Debug = 4,
        /// <summary>
        /// The message is a verbose message.
        /// </summary>
        Verbose = 5
    }
}