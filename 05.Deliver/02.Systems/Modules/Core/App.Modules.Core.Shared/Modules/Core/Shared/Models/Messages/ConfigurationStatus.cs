using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// Default Configuration Status
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    public class ConfigurationStatus : IHasTitleAndDescription
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }


        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ConfigurationStatusComponentStatusType Status
        {
            get
            {
                return
                    this.Components.Min(x => x.Status);
            }
        }

        /// <summary>
        /// Gets the individual status of
        /// individual components.
        /// </summary>
        public ICollection<ConfigurationStatusComponentBase> Components
        {
            get
            {
                return _components ?? (_components =
                           new Collection<ConfigurationStatusComponentBase>());
            }
            set { _components = value; }
        }

        private ICollection<ConfigurationStatusComponentBase> _components;
    }

}

