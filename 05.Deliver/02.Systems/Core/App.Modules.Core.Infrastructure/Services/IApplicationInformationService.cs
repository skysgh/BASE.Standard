namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// Contract for an Infrastructure Service to 
    /// manage information about the System. 
    /// <para>
    /// The most common use is for rendering information
    /// in the header of application interfaces.
    /// </para>
    /// </summary>
    public interface IApplicationInformationService : IModuleSpecificService
    {
        ApplicationDescriptionConfigurationSettings GetApplicationInformation();
        ApplicationCreatorInformationConfigurationSettings GetApplicationCreatorInformation();
        ApplicationDistributorInformationConfigurationSettings GetApplicationDistributorInformation();
    }
}
