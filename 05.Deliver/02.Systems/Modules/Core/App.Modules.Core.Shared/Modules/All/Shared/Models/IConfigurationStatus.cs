namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for an in-memory, singleton, entity,
    /// summarizing whether a service have been
    /// configured correctly or not (or are still
    /// unknown).
    /// <para>
    /// Basically, applications need at the very
    /// least a database service (which is technically
    /// a remote service). And will also need a
    /// cache service,
    /// key vault service,
    /// email service, etc.
    /// before it can be used in production. 
    /// </para>
    /// <para>
    /// Each service that relies on configuration
    /// in turn references a singleton instance
    /// of a configuration object (an named
    /// instance of this object).
    /// </para>
    /// <para>
    /// A service summarizes them and shows them
    /// up on a dashboard of some kind.
    /// </para>
    /// </summary>
    public interface IConfigurationComponentStatus :
        IHasTitleAndDescription,
        IHasImageUrl,
        IHasConfigurationStatus,
        IHasDisplayOrderHint,
        IHasDisplayStyleHint

    {
    }
}
