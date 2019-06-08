using System;

namespace App.Modules.All.Shared.Attributes
{
    public class RoleSecuredDtoModelAttributeAttribute : Attribute
    {
        public RoleSecuredDtoModelAttributeAttribute(string roles)
        {
            this.Roles = roles;
        }

        public string Roles { get; set; }
    }
}