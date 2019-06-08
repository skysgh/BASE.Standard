using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Design.Shared.Models.Entities
{
    // Press
    public class Press : IHasGuidId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Category Category { get; set; }
    }
}
