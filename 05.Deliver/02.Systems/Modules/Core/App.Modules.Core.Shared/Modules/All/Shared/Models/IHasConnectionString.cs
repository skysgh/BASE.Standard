namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for <c>IConfigurationObject</c>s
    /// for Azure services, in order to specify
    /// a connectionstring.
    /// <para>
    /// Used by configuration objects for
    /// IDistributedCacheService,
    /// AzureRedisCacheService,
    /// etc.
    /// </para>
    /// </summary>
    public interface IHasConnectionString
    {
        /// <summary>
        /// Gets or sets the connection string
        /// to connect to the remote service.
        /// </summary>
        string ConnectionString { get; set; }
    }
}
