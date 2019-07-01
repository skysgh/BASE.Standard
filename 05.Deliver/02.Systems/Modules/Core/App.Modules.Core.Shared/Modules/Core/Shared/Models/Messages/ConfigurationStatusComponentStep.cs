// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     A record of a configuration step that was undertaken.
    ///     For use by support personnel remotely reviewing configuration.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class ConfigurationStatusComponentStep :
        IHasGuidId,
        IHasDateTimeCreatedUtc
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }


        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public ConfigurationStatusComponentStepType Type { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        public ConfigurationStatusComponentStepStatusType Status { get; set; }

        /// <summary>
        ///     Gets or sets the date time.
        /// </summary>
        /// <value>
        ///     The date time.
        /// </value>
        public DateTimeOffset UtcDateTimeCreated { get; set; }


        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Task { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Outcome { get; set; }


        // Note than although this model is not persisted in 
        // a datastore, an Id is still required, as it is expressed
        // via OData.
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationStatusComponentStep" /> class.
        /// </summary>
        public ConfigurationStatusComponentStep()
        {
            Id = GuidFactory.NewGuid();

            UtcDateTimeCreated = DateTimeOffset.UtcNow;
        }

    }
}