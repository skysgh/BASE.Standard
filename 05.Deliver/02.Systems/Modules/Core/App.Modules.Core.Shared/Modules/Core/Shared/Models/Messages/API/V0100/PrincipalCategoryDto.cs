﻿using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    public class PrincipalCategoryDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public virtual Guid Id { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual string Text { get; set; }

        public string Description { get; set; }

        public virtual int DisplayOrderHint { get; set; }

        public virtual string DisplayStyleHint { get; set; }

    }
}