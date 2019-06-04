using System;

namespace App.Modules.Core
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