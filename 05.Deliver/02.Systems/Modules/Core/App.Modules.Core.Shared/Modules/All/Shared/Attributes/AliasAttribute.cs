using System;

namespace App.Modules.All.Shared.Attributes
{
    public class AliasAttribute : Attribute
    {
        public AliasAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; set; }
    }
}