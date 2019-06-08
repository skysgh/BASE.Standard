// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models;
using App.Modules.Design.Shared.Models.Entities.Enums;

namespace App.Modules.Design.Shared.Models.Messages
{


    public class RequirementDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public Guid Id { get; set; }

        public ISO25010 Quality { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}