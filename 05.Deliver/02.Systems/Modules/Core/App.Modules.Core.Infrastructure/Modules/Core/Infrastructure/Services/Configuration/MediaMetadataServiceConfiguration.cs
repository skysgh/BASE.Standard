// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    /// <summary>
    ///     Configuration object to be injected into the
    ///     implementation of <see cref="IMediaMetadataService" />
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
    public class MediaMetadataServiceConfiguration
        : ConfigurationObjectBase
    {

        public MediaMetadataServiceConfiguration(
            IConfigurationService configurationService)
        {
            configurationService.Get(this);
        }


        private string _hashType;

        /// <summary>
        ///     Gets or sets the type of the hash.
        /// </summary>
        public string HashType
        {
            get => _hashType ?? "SHA-256";
            set => _hashType = value;
        }

    }
}