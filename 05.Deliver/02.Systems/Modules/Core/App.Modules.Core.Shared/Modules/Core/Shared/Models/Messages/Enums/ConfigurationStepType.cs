// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// </summary>
    public enum ConfigurationStepType
    {
        /// <summary>
        ///     Step is for undefined
        /// </summary>
        Undefined = 0,

        /// <summary>
        ///     Step is for general
        /// </summary>
        General = 1,

        /// <summary>
        /// Step is for routing
        /// </summary>
        Routing = 2,

        /// <summary>
        ///     Step is for security
        /// </summary>
        Security = 3,

        /// <summary>
        ///     Step is for performance
        /// </summary>
        Performance = 4
    }
}