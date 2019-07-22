using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{


    /// <summary>
    /// An in-memory, singleton, entity  
    /// summarizing whether a service have been
    /// configured correctly or not (or are still
    /// unknown).
    /// <para>
    /// Basically, applications need at the very
    /// least a database service (which is technically
    /// a remote service). And will also need a
    /// cache service,
    /// key vault service,
    /// email service, etc.
    /// before it can be used in production.
    /// </para><para>
    /// Each service that relies on configuration
    /// in turn references a singleton instance
    /// of a configuration object (an named
    /// instance of this object).
    /// </para><para>
    /// A service summarizes them and shows them
    /// up on a dashboard of some kind.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IConfigurationComponentStatus" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasTitleAndDescription" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasImageUrl" />
    public abstract class ConfigurationStatusComponentBase :
        IConfigurationComponentStatus
    {
        private string _configurationInstructions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationStatusComponentBase" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="configurationInstructions">The configuration instructions.</param>
        protected ConfigurationStatusComponentBase(string title, string description, string configurationInstructions)
        {
            Module = this.GetType().GetModuleIdentifier();
            Title = title;
            Description = description;
            ConfigurationInstructions = configurationInstructions;

        }

        /// <summary>
        /// Gets or sets the name of module.
        /// </summary>
        /// <value>
        /// The module.
        /// </value>
        public virtual string Module { get; private set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public virtual string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }


        /// <summary>
        /// Gets or sets the success count.
        /// </summary>
        /// <value>
        /// The success count.
        /// </value>
        public int SuccessCount { get; set; }

        /// <summary>
        /// Gets or sets the error count.
        /// </summary>
        /// <value>
        /// The error count.
        /// </value>
        public int ErrorCount { get; set; }

        /// <summary>
        /// Gets or sets basic (insecure) instructions
        /// on how to go about setting up the service.
        /// </summary>
        public virtual string ConfigurationInstructions
        {
            get
            {
                switch (Status)
                {
                    case ConfigurationStatusComponentStatusType.ConfigurationError:
                        return _configurationInstructions;
                    case ConfigurationStatusComponentStatusType.ConfigurationVerified:
                        return "Working.";
                    default:
                        return "";
                }
            }
            set => _configurationInstructions = value;
        }

        /// <summary>
        /// Gets or sets the status of the service.
        /// </summary>
        public virtual ConfigurationStatusComponentStatusType Status { get; set; }


        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        public virtual string ImageUrl { get; set; }
        /// <summary>
        /// A convention based hint as to display (could be a class name, or icon, CSV or both, DSL, etc.)
        /// </summary>
        public virtual string DisplayStyleHint { get; set; }
        /// <summary>
        /// A convention based hint as to the natural order in which to display this list item
        /// (note that the natural order can be superseded/influenced by MRU information, etc.)
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }


        /// <summary>
        /// Gets a list of steps that were undertaken
        /// to configure this functionality.
        /// </summary>
        /// <value>
        /// The steps.
        /// </value>
        public ICollection<ConfigurationStatusComponentStep> Steps
        {
            get
            {
                return _steps ??
                       (_steps = new Collection<ConfigurationStatusComponentStep>());
            }
            set => _steps = value;
        }
        private ICollection<ConfigurationStatusComponentStep> _steps;




        /// <summary>
        /// Adds a step to the <see cref="Steps"/> list.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        /// <param name="task">The task.</param>
        /// <param name="outcome">The outcome.</param>
        public void AddStep(
            ConfigurationStatusComponentStepType type,
            ConfigurationStatusComponentStepStatusType status,
            string task,
            string outcome)
        {
            var step = new ConfigurationStatusComponentStep()
            {
                Type = type,
                Outcome = outcome,
                Task = task,
                Status = status
            };
            Steps.Add(step);
        }


    }
}
