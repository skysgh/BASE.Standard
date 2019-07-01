namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// Enumeration of possible
    /// Service states.
    /// <para>
    /// See
    /// <see cref="ConfigurationStatusComponentBase"/>
    /// </para>
    /// </summary>
    public enum ConfigurationStatusComponentStatusType
    {
        /// <summary>
        /// Configuration has not bee read.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Configuration ahs been read,
        /// but not yet verified.
        /// </summary>
        ConfigurationRead = 1,



        /// <summary>
        /// The configuration is verified
        /// as connection to the service
        /// has been established.
        /// </summary>
        ConfigurationVerified = 2,


        /// <summary>
        /// Attempts to connect to
        /// the service failed.
        /// </summary>
        ConfigurationError = 4

    }
}
