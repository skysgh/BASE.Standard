﻿namespace App.Modules.Core.Shared.Models.Entities
{
    using System;

    public class TenantProperty : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid TenantFK { get; set; }

        public Guid GetOwnerFk()
        {
            return TenantFK;
        }

    }
}