﻿namespace App.Modules.Core.Shared.Models.ConfigurationSettings
{
    using App.Modules.Core.Shared.Attributes;

    /// <summary>
    /// Information recorded after the Application was
    /// registered in Azure.
    /// <para>
    /// The process is more or less:
    /// * In Azure
    /// * Select App registrations
    /// * Add the App
    ///   * Give it a name, and a fake url to start
    ///   * Pick up the Application Id (that's the client Id)
    ///   * Create a new Key
    ///   * That's the Client Id
    /// </para>
    /// </summary>
    public class AadApplicationRegistrationInformationConfigurationSettings: IKeyVaultBasedConfigurationObject
    {
        /// <summary>
        /// Note that this is the ApplicationId that
        /// Azure generates for you when the app is 
        /// registered.
        /// <para>
        /// Behind the sceens, Azure will generate
        /// an SecurityPrincipalName (SPN) for your
        /// application. Acts sort of like a on-prem, 
        /// ServiceAccount. This SPN is then used
        /// to assign rights to the KeyStore.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias( Constants.ConfigurationKeys.AppCoreIDAAADClientId)]
        public string ClientId { get; set; }

        /// <summary>
        /// Note that this is one of the Keys you 
        /// generate for the app, just after you have
        /// registered the application as a client, 
        /// and have obtained an ApplicationId.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIDAAADClientSecret)]
        public string ClientSecret { get; set; }
    }
}

    
