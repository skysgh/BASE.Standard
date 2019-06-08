﻿using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    public class PrincipalProperty : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
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