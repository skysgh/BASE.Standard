using System;

namespace App.Modules.Core.Shared.Attributes
{
    public class KeyAttribute : Attribute
    {
        public KeyAttribute(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

    }
}
