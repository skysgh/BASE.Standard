// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Settings
{
    /// <summary>
    ///     Azure subscription configuration information.
    /// </summary>
    /// <seealso cref="IConfigurationObject" />
    public class AzureEnvironmentSettings
        : ConfigurationObjectBase
    {

        public AzureEnvironmentSettings()
        {

        }

        public AzureEnvironmentSettings(
            IConfigurationService configurationService)
        {
            configurationService.Get(this);
        }

        private string _defaultResourceName;

        public string DefaultKeyVaultResourceName { get; set; }


        /// <summary>
        ///     Gets or sets the subscription identifier
        ///         (a string of the Guid).
        ///     <para>
        ///         For Security reasons, there should
        ///         always be more than one,
        ///         as Production Data environments
        ///         should always be separate from
        ///         all other Non-Production Data.
        ///     </para>
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        ///     Gets or sets the AAD tenant identifier
        /// (a string of the Guid).
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the resource group.
        ///     this system is deployed to.
        /// <value>
        /// eg: 'NZ-OrgA-ProjB-SysC[-0000]-UT'.
        /// </value>
        /// </summary>
        public string ResourceGroupName
        {
            get { return _resourceGroupName ?? ""; }
            set { _resourceGroupName = value; }
        }

        private string _resourceGroupName = "";


        /// <summary>
        /// Gets or sets the default name of resources
        /// instantiated within the Resource Group.
        /// <para>
        /// If none provided, it's most common to use the
        /// <see cref="ResourceGroupName"/> after having
        /// stripped out dashes, and converting it to lowercase.
        /// </para>
        /// </summary>
        /// <value>
        /// eg: 'nzorgaprojbsysc0000ut' (21 chars in this case).
        /// </value>
        public string DefaultResourceName
        {
            get => _defaultResourceName
                   ?? (_defaultResourceName
                       = ResourceGroupName
                           .Replace("-", "")
                           .Replace("_", ""))
                   .ToLower();
            set => _defaultResourceName = value;
        }

        /// <summary>
        ///     Gets or sets the resource group location
        /// (eg: "AustraliaEast")
        /// </summary>
        public string ResourceGroupLocation { get; set; }
    }
}