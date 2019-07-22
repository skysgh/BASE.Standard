// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     TODO
    /// </summary>
    public enum ConfigurationStatusComponentStepStatusType
    {
        /// <summary>
        ///     Unidentified (Error state)
        /// </summary>
        Undefined = 0,

        /// <summary>
        ///     Step
        /// </summary>
        Info = 1,

        /// <summary>
        ///     Step
        /// </summary>
        Warn = 2,

        /// <summary>
        ///     Red (error)
        /// </summary>
        Fail = 3,

        /// <summary>
        ///     Green (Ok)
        /// </summary>
        Pass = 4

    }
}