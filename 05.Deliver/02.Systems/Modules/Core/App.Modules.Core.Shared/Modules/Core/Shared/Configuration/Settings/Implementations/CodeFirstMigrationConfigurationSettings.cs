using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;

namespace App.Modules.Core.Shared.Configuration.Settings
{
    /// <summary>
    /// An immutable host configuration object 
    /// controlling behaviour of 
    /// EF CodeFirst.
    /// </summary>
    public class CodeFirstMigrationConfigurationSettings: IHostSettingsBasedConfigurationObject
    {
        /// <summary>
        /// Gets or sets a value indicating whether to attach the debugger
        /// to CodeFirst activity.
        /// <para>
        /// This can be useful when trying to track down unexpected behaviour
        /// that is occuring when invoking CodeFirst from the 'dotnet' commandline.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(Core.Shared.Constants.ConfigurationKeys.AppCoreCodeFirstAttachDebuggerToPSSeeding)]
        public bool CodeFirstAttachDebugger { get; set; }


    }
}