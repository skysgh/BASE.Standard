// Copyright MachineBrains, Inc. 2019

using App.Diagrams.PlantUml.Uml;
using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Settings
{
    /// <summary>
    ///     An immutable host configuration object
    ///     describing the configuration needed to
    ///     access the
    ///     Diagnostics Azure Storage Account Service.
    /// </summary>
    public class AzureStorageAccountDiagnosticsConfiguration
        : AzureServiceClientConfigurationObjectBase,
        IStorageAccountConfigurationSettings
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AzureStorageAccountDefaultConfiguration" /> class.
        /// </summary>
        public AzureStorageAccountDiagnosticsConfiguration(
            AzureEnvironmentSettings azureEnvironmentSettings,
            IConfigurationService configurationService)
        {

            if (ResourceNameSuffix.IsNullOrEmpty())
            {
                ResourceNameSuffix = "di";
            }

            if (ResourceName.IsNullOrEmpty())
            {
                ResourceName = azureEnvironmentSettings.DefaultResourceName;
            }

            ResourceName += ResourceNameSuffix;
        }



        /// <summary>
        ///     Gets or sets (from AppSettings)
        ///     the ResourceName Suffix of this StorageAccount.
        ///     <para>
        ///         <para>
        ///             Default Value is 'di'.
        ///         </para>
        ///         <para>
        ///             The value is appended to <see cref="ResourceName" />.
        ///         </para>
        ///         <para>
        ///             Can be overridden (or cleared) using
        ///             <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDiagnosticsResourceNameSuffix" />,
        ///             in AppSettings.
        ///         </para>
        ///     </para>
        /// </summary>
        public string ResourceNameSuffix { get; set; }

    }
}