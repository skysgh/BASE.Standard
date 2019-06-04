using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Infrastructure.Constants.Tenancy
{
    public class Default
    {
        public static Tenant DefaultTenant = new Tenant
        {
            Id = 1.ToGuid(),
            IsDefault = true /*notice....*/,
            Enabled = true,
            Key = "Default",
            DisplayName = "Default",
            HostName = "Default",
        };
    }
}
