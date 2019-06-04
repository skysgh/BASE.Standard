using System;

namespace App.Modules.Core
{
    public class AliasAttribute : Attribute
    {
        public AliasAttribute(string displayName)
        {
            this.DisplayName = displayName;
        }

        public string DisplayName { get; set; }
    }
}