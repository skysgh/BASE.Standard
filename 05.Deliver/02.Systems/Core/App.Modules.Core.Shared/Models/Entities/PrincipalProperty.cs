﻿namespace App.Modules.Core.Shared.Models.Entities
{
    using System;

    public class PrincipalProperty : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public virtual Guid PrincipalFK { get; set; }


        public Guid GetOwnerFk()
        {
            return PrincipalFK;
        }
    }
}