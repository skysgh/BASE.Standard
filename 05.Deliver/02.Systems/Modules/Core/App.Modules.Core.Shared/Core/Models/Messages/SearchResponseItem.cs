namespace App.Modules.Core.Models.Messages
{
    public class SearchResponseItem
    {
        public virtual string TypeKey { get; set; }
        public virtual string TypeId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImageUrl { get; set; }
    }
}