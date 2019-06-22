// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for an Infrastructure Service to
    ///     manage information about the System.
    ///     <para>
    ///         The most common use is for rendering information
    ///         in the header of application interfaces.
    ///     </para>
    /// </summary>
    public interface IApplicationInformationService : IInfrastructureService
    {
        ApplicationDescriptionConfigurationSettings GetApplicationInformation();
        ApplicationCreatorInformationConfigurationSettings GetApplicationCreatorInformation();
        ApplicationDistributorInformationConfigurationSettings GetApplicationDistributorInformation();
    }
}