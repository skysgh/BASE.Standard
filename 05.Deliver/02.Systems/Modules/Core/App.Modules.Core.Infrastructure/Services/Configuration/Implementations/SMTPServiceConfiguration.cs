using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.Core.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations
{
    using App.Modules.Core.Shared.Contracts;

    /// <summary>
    /// Configuration object to be injected into the 
    /// implementation of <see cref="ISmtpService"/>
    /// <para>
    /// Inherits from <see cref="ICoreServiceConfigurationObject"/>
    /// whic inherits from <see cref="IHasSingletonLifecycle"/>
    /// to hint at startup that the Configuration object should be 
    /// IoC registered for the duration of the application (not the thread).
    /// as some configuration hits remote services (eg: Azure KeyVault)
    /// which would be rather slow.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.Configuration.ICoreServiceConfigurationObject" />
    public class SMTPServiceConfiguration : ICoreServiceConfigurationObject
    {
        // TODO: 
        public SmtpServiceClientConfiguration Configuration { get; private set; }

        public SMTPServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {

            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();

            Configuration = keyVaultService.GetObject<SmtpServiceClientConfiguration>();


            
        }
    }
}
