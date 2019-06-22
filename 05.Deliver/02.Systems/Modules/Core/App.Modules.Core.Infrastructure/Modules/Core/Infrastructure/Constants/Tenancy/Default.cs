// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Constants.Tenancy
{
    public class Default
    {
        public static Tenant DefaultTenant = new Tenant
        {
            Id = 1.ToGuid(),
            IsDefault = true /*notice....*/,
            Enabled = true,
            DataClassificationFK = NZDataClassification.Unclassified,
            Key = "Default",
            DisplayName = "Default",
            HostName = "Default"
        };
    }
}