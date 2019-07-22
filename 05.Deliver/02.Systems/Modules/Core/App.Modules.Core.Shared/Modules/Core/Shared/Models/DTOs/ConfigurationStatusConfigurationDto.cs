using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Shared.Models.DTOs
{

    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IConfigurationComponentStatus" />
    public class ConfigurationStatusComponentDto 
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
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ConfigurationStatusComponentStatusType Status { get; set; }
        /// <summary>
        /// Gets or sets the display order hint.
        /// </summary>
        /// <value>
        /// The display order hint.
        /// </value>
        public int DisplayOrderHint { get; set; }
        /// <summary>
        /// Gets or sets the display style hint.
        /// </summary>
        /// <value>
        /// The display style hint.
        /// </value>
        public string DisplayStyleHint { get; set; }

        /// <summary>
        /// Gets the steps.
        /// </summary>
        /// <value>
        /// The steps.
        /// </value>
        public ICollection<ConfigurationStatusStepDto> Steps
        {
            get
            {
                return _steps ??
                       (_steps = new Collection<ConfigurationStatusStepDto>());
            }
            set => _steps = value;
        }
        ICollection<ConfigurationStatusStepDto> _steps;
    }
}
