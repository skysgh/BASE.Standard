namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// <para>
    /// Contract for
    /// <c>IConfigurationObject</c>s
    /// to reference remote Services.
    /// </para>
    /// </summary>
    public interface IHasBaseUri
    {
        /// <summary>
        /// Gets or sets the base URI.
        /// <para>
        ///     For http based services, will start with the protocol,
        ///     other protocols (SMTP, Redis, etc.) might not
        ///     (eg: SMTP MTA's it might look like 'smtp.gmail.com')
        /// </para>
        /// </summary>
        /// <value>
        /// The base URI (depending on the service type, with or without the protocol).
        /// </value>
        string BaseUri { get; set; }
    }
}
