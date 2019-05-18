// Copyright MachineBrains, Inc.

using App.Modules.Core.Shared.Models.Messages.Enums;
using System;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{


    public class RequirementDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public Guid Id { get; set; }

        public ISO25010 Quality { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}