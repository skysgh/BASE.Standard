using System;
using App.Modules.Core.Factories;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class SecurityProfilePermissionDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public SecurityProfilePermissionDto()
        {
            this.Id = GuidFactory.NewGuid();

        }

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }


    }
}

