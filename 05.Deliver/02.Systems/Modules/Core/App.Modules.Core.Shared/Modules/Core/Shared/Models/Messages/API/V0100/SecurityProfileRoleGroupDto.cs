﻿using System;
using System.Collections.Generic;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
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