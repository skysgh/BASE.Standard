using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models;

namespace App.Modules.Design.Shared.Models.Entities
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Book : IHasGuidId
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public Address Location { get; set; }
        public Press Press { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
