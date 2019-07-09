// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;

namespace App.Modules.Core.Infrastructure.Configuration.Settings
{
    /// <summary>
    ///     An immutable host configuration object
    ///     controlling behaviour of
    ///     EF CodeFirst.
    /// </summary>
    public class CodeFirstMigrationConfigurationSettings
        : ConfigurationObjectBase
    {
        /// <summary>
        ///     Gets or sets a value indicating whether to attach the debugger
        ///     to CodeFirst activity.
        ///     <para>
        ///         This can be useful when trying to track down unexpected behaviour
        ///         that is occuring when invoking CodeFirst from the 'dotnet' commandline.
        ///     </para>
        /// </summary>
        public bool CodeFirstAttachDebugger { get; set; }
    }
}