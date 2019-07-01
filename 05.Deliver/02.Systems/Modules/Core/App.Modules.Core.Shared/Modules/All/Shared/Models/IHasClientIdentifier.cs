namespace App.Modules.All.Shared.Models
{

    /// <summary>
    /// Contract for <c>IConfigurationObject</c>s
    /// that hold the account identifier
    /// to a remote 3rd party service.
    /// </summary>
    public interface IHasServiceClientIdentifier
    {
        /// <summary>
        /// Gets or sets the service's client account identifier.
        /// <para>
        /// That would be the SMTP service account name,
        /// the account name for a 3rd party malware service, etc.
        /// </para>
        /// </summary>
        string ClientIdentifier { get; set; }
    }
}
