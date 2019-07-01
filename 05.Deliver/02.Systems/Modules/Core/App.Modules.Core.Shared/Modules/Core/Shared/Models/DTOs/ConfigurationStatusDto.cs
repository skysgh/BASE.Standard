using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    public class ConfigurationStatusDto:IHasTitleAndDescription
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
        /// Gets or sets the status.
        /// </summary>
        public ConfigurationStatusComponentStatusType Status { get; set; }

        /// <summary>
        /// Gets the individual status of
        /// individual components.
        /// </summary>
        public ICollection<ConfigurationStatusComponentDto> Components
        {
            get { return _components ?? (_components = new Collection<ConfigurationStatusComponentDto>()); }
            set { _components = value; }
        }
        private ICollection<ConfigurationStatusComponentDto> _components;
    }
}
