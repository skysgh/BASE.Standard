using System;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ApplicationProviderInformationDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id {
            get; set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the site URL.
        /// </summary>
        /// <value>
        /// The site URL.
        /// </value>
        public string SiteUrl { get; set; }
        /// <summary>
        /// Gets or sets the contact URL.
        /// </summary>
        /// <value>
        /// The contact URL.
        /// </value>
        public string ContactUrl
        {
            get; set;
        }
    }
}