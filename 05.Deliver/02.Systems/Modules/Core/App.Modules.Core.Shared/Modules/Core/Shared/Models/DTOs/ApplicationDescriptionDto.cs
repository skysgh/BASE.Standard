﻿// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO Message for ApplicationDescriptionConfigurationSettings
    ///     summarizing the Application's Name, Description, Creator, Distributor.
    ///     For use by any User Agent to render on their Header View.
    /// </summary>
    /// <seealso cref="IHasGuidId" />
    public class ApplicationDescriptionDto : IHasKey
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the creator.
        /// </summary>
        /// <value>
        ///     The creator.
        /// </value>
        public ApplicationProviderInformationDto Creator { get; set; }

        /// <summary>
        ///     Gets or sets the distributor.
        /// </summary>
        /// <value>
        ///     The distributor.
        /// </value>
        public ApplicationProviderInformationDto Distributor { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public string Key { get; set; }
    }
}