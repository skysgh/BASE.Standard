// Copyright MachineBrains, Inc.

using System;
using App.Modules.Core.Models;
using App.Modules.Core.Shared.Models.Messages.Enums;

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