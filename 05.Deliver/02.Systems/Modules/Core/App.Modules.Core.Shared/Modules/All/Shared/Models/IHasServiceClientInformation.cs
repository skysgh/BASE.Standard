namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Basic Contract for Service client configurations (url, id, secret, etc.)
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasServiceClientIdentifier" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasServiceClientSecret" />
    public interface IHasServiceClientInformation :
        IHasEnabled,
        IHasBaseUri,
        IHasServiceClientIdentifier,
        IHasServiceClientSecret

    {
        /// <summary>
        ///     Gets or sets any misc configuration (generally as a JSON string).
        /// </summary>
        string MiscConfig { get; set; }
    }
}
