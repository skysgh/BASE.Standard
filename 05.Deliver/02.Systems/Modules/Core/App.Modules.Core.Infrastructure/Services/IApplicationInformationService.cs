using App.Modules.Core.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services
{
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
