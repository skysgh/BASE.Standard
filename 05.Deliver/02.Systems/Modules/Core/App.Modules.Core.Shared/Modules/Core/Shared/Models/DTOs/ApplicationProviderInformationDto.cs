// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     TODO
    /// </summary>
    public class ApplicationProviderInformationDto
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

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
    }
}