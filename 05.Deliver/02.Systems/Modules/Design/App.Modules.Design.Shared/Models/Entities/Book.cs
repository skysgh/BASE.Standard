using System;
using App.Modules.Core.Models;

namespace App.Modules.Design.Shared.Models.Entities
{
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
}
