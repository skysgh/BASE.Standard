using System;

namespace App.Modules.Core.Shared.Models.Entities
{
    public class PrincipalSetting : SettingBase
    {
        // Id of the Principal/User who this Setting is for.
        public virtual Guid UserFK { get; set; }
    }
}