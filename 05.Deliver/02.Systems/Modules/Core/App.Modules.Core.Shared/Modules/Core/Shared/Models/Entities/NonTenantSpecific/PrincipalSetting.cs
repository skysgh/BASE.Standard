// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A Setting that can be associated to a Principal.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Entities.SettingBase" />
    public class PrincipalSetting : SettingBase
    {
        /// <summary>
        ///     Gets or sets the Id of the Principal/User who this Setting is for.
        /// </summary>
        public virtual Guid UserFK { get; set; }
    }
}