using System;

namespace App.Modules.All.Shared.Attributes
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class KeyAttribute : Attribute
    {
        public KeyAttribute(string key)
        {
            this.Key = key;
        }

        public string Key { get; set; }

    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
