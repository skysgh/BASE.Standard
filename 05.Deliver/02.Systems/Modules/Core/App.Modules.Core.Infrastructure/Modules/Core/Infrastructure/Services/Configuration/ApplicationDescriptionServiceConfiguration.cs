// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.DependencyResolution.Lifecycles;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services.Configuration
{
    /// <summary>
    ///     Configuration object to be injected into the
    ///     implementation of <see cref="IApplicationDescriptionService" />
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
    public class ApplicationDescriptionServiceConfiguration
        : ConfigurationObjectBase,
            IHasKey, IHasName, IHasDescription
    {

        public ApplicationDescriptionServiceConfiguration(IConfigurationService configurationService)
        {
            configurationService.Get(this);
        }

        public string Key
        {
            get { return "Description"; }
            set
            {
                // Do Nothing
            }
        }

        /// <summary>
        ///     Gets or sets the name of the Application
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description/byline of the Application.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the Application's creator information.
        /// </summary>
        public ApplicationProviderInformation
            Creator
        {
            get
            {
                return _creator
                       ?? (_creator =
                           new
                               ApplicationProviderInformation(
                                   "Creator")
                       );
            }
            set { _creator = value; }
        }

        private ApplicationProviderInformation
            _creator;

        /// <summary>
        /// Gets or sets the distributor of the software,
        /// if different from the <see cref="Creator"/>.
        /// </summary>
        public ApplicationProviderInformation
            Distributor
        {
            get
            {
                return _distributor ?? (_distributor =
                           new
                               ApplicationProviderInformation(
                                   "Distributor")
                       );
            }
            set { _distributor = value; }
        }

        ApplicationProviderInformation _distributor;
    }




    /// <summary>
    /// Creator or Distributor information.
    /// </summary>
    /// <seealso cref="IHasKey" />
    /// <seealso cref="IHasName" />
    /// <seealso cref="IHasDescription" />
    public class ApplicationProviderInformation :
        IHasKey,
        IHasName,
        IHasDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationProviderInformation"/> class.
        /// </summary>
        public ApplicationProviderInformation()
        {

        }
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationCreatorInformationConfigurationSettings" /> class.
        /// </summary>
        public ApplicationProviderInformation(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Note the difference with
        /// <see cref="T:App.Modules.All.Shared.Models.IHasKey" /> which is used to define
        /// which attribute of an object is used as the
        /// primary index key (and is not necessarily
        /// the same as it's <see cref="T:App.Modules.All.Shared.Models.IHasName" />)
        /// </para><para>
        /// Note <see cref="T:App.Modules.All.Shared.Models.IHasTitle" />, which is used
        /// for containing displayable information.
        /// </para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the site URL.
        /// </summary>
        /// <value>
        ///     The site URL.
        /// </value>
        public string SiteUrl { get; set; }

        /// <summary>
        ///     Gets or sets the contact URL.
        /// </summary>
        /// <value>
        ///     The contact URL.
        /// </value>
        public string ContactUrl { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// of the company
        /// <para>
        /// Note the difference with
        /// <see cref="T:App.Modules.All.Shared.Models.IHasName" /> which is used to
        /// the well-known name of an object, but is
        /// not necessarily it's <see cref="T:App.Modules.All.Shared.Models.IHasKey" />.
        /// </para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the optional displayed description.
        /// </summary>
        public string Description { get; set; }

    }

}