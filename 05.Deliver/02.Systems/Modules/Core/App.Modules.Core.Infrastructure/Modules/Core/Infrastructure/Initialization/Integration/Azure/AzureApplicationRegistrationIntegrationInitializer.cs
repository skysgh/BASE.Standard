//namespace App.Modules.Core.Infrastructure.Initialization.Integration.Azure
//{
//    using System;
//    using App.Modules.Core.Infrastructure.Constants.Exceptions;
//    using App.Modules.Core.Infrastructure.Services;
//    using App.Modules.Core.Shared.Contracts;
//    using App.Modules.Core.Shared.Models.Configuration;
//    using App.Modules.Core.Shared.Models.ConfigurationSettings;

//    public class AzureApplicationRegistrationIntegrationInitializer : IHasAppCoreInitializer, IHasInitialize
//    {
//        private readonly IHostSettingsService _hostSettingsService;

//        public AzureApplicationRegistrationIntegrationInitializer(IHostSettingsService hostSettingsService)
//        {
//            this._hostSettingsService = hostSettingsService;
//        }
//        public void Initialize()
//        {
//            AadApplicationRegistrationInformationConfigurationSettings aadApplicationRegistration =
//                this._hostSettingsService.GetObject<AadApplicationRegistrationInformationConfigurationSettings>();

//            if (string.IsNullOrWhiteSpace(aadApplicationRegistration.ClientId))
//            {
//                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure ApplicationId/ClientId not correctly configured (empty).");
//            }
//            if (string.IsNullOrWhiteSpace(aadApplicationRegistration.ClientSecret))
//            {
//                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure ApplicationId/ClientId not correctly configured (empty).");
//            }
//            Guid tmp;
//            if (!Guid.TryParse(aadApplicationRegistration.ClientId, out tmp))
//            {
//                throw new ConfigurationException($"{ExceptionMessages.SystemConfigurationError}: Azure ApplicationId/ClientId not correctly configured (not a Guid).");
//            }
//        }

//    }
//}