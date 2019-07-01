// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Infrastructure.Configuration.Settings
{

    /// <summary>
    /// Contract for the settings common to any Blob storage service
    /// (Diagnostics, Default).
    /// </summary>
    public interface IStorageAccountConfigurationSettings: 
        IHasServiceClientSecret
    {

        /// <summary>
        /// Gets or sets the name of the Azure ResourceName.
        /// <para>
        /// If not provided explicitly, will be filled with
        /// the default <c>ResourceName</c> that is within
        /// <see cref="AzureCommonConfigurationSettings"/>
        /// </para>
        /// </summary>
        string ResourceName { get; set; }
        /// <summary>
        /// If the name was derived from
        /// <see cref="AzureCommonConfigurationSettings"/> (see above)
        /// then this Suffix can be appended.
        /// <para>
        /// For example, one might append 'di' to differentiate
        /// the Diagnostics storage account from the Default/Media one
        /// (which might not require a suffix of any kind).
        /// </para>
        /// </summary>
        string ResourceNameSuffix { get; set; }

    }
}