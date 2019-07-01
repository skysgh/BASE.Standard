// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     A model to hold the results of a
    ///     self debasement of integration, etc.
    ///     Again, this is to provide to support
    ///     stakeholders a way of ensuring the system
    ///     is up and running.    ///
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class ConfigurationTestStepSummary : IHasGuidId
    {
        // Note than although this model is not persisted in 
        // a datastore, an Id is still required, as it is expressed
        // via OData.
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationTestStepSummary" /> class.
        /// </summary>
        public ConfigurationTestStepSummary()
        {
            Id = GuidFactory.NewGuid();
        }

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
        public DateTimeOffset? DateTime { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }
    }
}