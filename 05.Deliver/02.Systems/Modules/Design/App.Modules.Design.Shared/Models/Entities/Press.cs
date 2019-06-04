using System;
using App.Modules.Core.Models;
using App.Modules.Core.Shared.Models;
using App.Modules.Design.Shared.Models.Entities;
using App.Modules.Models;

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
