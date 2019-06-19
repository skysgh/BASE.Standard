using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Design.Shared.Models.Entities
{
    // Press
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Press : IHasGuidId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Category Category { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
