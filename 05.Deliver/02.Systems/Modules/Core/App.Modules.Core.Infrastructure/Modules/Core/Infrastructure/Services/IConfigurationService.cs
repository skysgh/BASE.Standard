using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for a service to 
    /// return 
    /// configuration objects.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets a new instance of <see cref="TConfigurationObject"/>,
        /// hydrated with values from the <c>appsettings.json</c>, keyvault, etc.
        /// </summary>
        /// <typeparam name="TConfigurationObject">The type of the configuration object.</typeparam>
        /// <returns></returns>
        TConfigurationObject Get<TConfigurationObject>();
        /// <summary>
        /// Hydrates the given<see cref="TConfigurationObject"/>,
        /// with values from the <c>appsettings.json</c>, keyvault, etc.
        /// <para>
        /// Often invoked within the Constructor of singleton
        /// configuration objects
        /// that derive from
        /// <c>IConfigurationObject"</c>.
        /// </para>
        /// </summary>
        /// <typeparam name="TConfigurationObject">The type of the configuration object.</typeparam>
        /// <param name="target">The target.</param>
        void Get<TConfigurationObject>(TConfigurationObject target);

    }
}