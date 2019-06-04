using System;
using System.Collections.Generic;
using App.Modules.Core.Factories;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class SecurityProfileRoleGroupDto : IHasGuidId
    {
        public SecurityProfileRoleGroupDto()
        {
            this.Id = GuidFactory.NewGuid();

        }

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }


        public ICollection<SecurityProfileRoleGroupDto> Groups { get; set; }

        public ICollection<SecurityProfileRoleDto> Roles { get; set; }


    }
}
