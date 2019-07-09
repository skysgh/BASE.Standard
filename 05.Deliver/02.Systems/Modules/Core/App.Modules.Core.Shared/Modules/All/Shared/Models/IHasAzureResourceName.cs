namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for <c>IConfigurationObject</c>s
    /// for Azure services, in order to specify
    /// the resource name.
    /// </summary>
    public interface IHasAzureResourceName
    {
        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        /// <value>
        /// The name of the resource.
        /// </value>
        string ResourceName { get; set; }
    }
}
