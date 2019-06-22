﻿// Copyright MachineBrains, Inc. 2019

//namespace App.Modules.Core.Infrastructure.Factories
//{
//    using App.Modules.Core.Infrastructure.Integration.Azure.KeyVault;
//    using App.Modules.Core.Shared.Models.Configuration;
//    using App.Modules.Core.Shared.Models.ConfigurationSettings;
//    using Microsoft.IdentityModel.Clients.ActiveDirectory;

//    /// <summary>
//    /// A Factory to authenticate the Application, 
//    /// in order for the Application to retrieve 
//    /// values from the keystore.
//    /// <para>
//    /// Dependencies:
//    /// * Nuget:
//    ///    * Microsoft.IdentityModel.Clients.ActiveDirectory
//    ///      * NOTE: Which relieas on ADAL, as oposed to the newer MSAL...    /// </para>
//    /// </summary>
//    public class ClientCredentialFactory
//    {
//        /// <summary>
//        /// Build a new ClientCredential 
//        /// from the Azure Registered Application's
//        /// ClientId and ClientSecret.
//        /// </summary>
//        /// <param name="aaDClientInfo"></param>
//        /// <returns></returns>
//        public ClientCredential Build(AadApplicationRegistrationInformationConfigurationSettings aaDClientInfo)
//        {
//            //NOTE THAT CLIENT CREDENTIAL comes froms an a library that 
//            // is using the older ADAL approach, and will probably get updated to MSAL,
//            // hence dragging it out to a Factory:
//            var result = new ClientCredential(aaDClientInfo.ClientId, aaDClientInfo.ClientSecret);
//            return result;
//        }
//    }
//}

