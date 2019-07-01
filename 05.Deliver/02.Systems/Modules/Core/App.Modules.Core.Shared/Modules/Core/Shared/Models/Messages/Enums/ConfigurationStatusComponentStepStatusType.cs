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
        White = 1,

        /// <summary>
        ///     Green (Ok)
        /// </summary>
        Green = 2,

        /// <summary>
        ///     Orange (warning)
        /// </summary>
        Orange = 3,

        /// <summary>
        ///     Red (error)
        /// </summary>
        Red = 4
    }
}