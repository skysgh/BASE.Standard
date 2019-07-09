// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.DependencyResolution.Lifecycles;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    /// <summary>
    ///     Configuration object to be injected into the
    ///     implementation of <see cref="ISmtpService" />
    ///     <para>
    ///         Inherits from <see cref="IConfigurationObject" />
    ///         which inherits from <see cref="IHasSingletonLifecycle" />
    ///         to hint at startup that the Configuration object should be
    ///         IoC registered for the duration of the application (not the thread).
    ///         as some configuration hits remote services (eg: Azure KeyVault)
    ///         which would be rather slow.
    ///     </para>
    /// </summary>
    /// <seealso cref="IConfigurationObject" />
    public class SMTPServiceConfiguration
        : ServiceClientConfigurationObjectBase
    {
        public SMTPServiceConfiguration(IConfigurationService configurationService)
        {
            configurationService.Get(this);
        }



        /// <summary>
        ///     Gets or sets the port.
        /// </summary>
        /// <value>
        ///     The port.
        /// </value>
        public int? Port { get; set; }

        /// <summary>
        ///     Gets or sets System Identity's From value used to connect.
        /// </summary>
        public string From { get; set; }


    }
}