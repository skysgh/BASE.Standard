namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    using System;
    using System.Collections.Generic;
    using App.Modules.Core.Shared.Factories;
    using App.Modules.Core.Shared.Models;

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

