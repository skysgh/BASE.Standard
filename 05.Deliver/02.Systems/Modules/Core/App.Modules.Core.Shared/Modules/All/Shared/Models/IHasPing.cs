namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract placed on Services
    /// to handle remote services.
    /// </summary>
    public interface IHasPing
    {
        /// <summary>
        /// Verify connectivity to remote service.
        /// </summary>
        /// <returns></returns>
        bool Ping();
    }
}
