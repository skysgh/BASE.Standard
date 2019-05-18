
namespace App.Modules.Core.Infrastructure.Initialization.Search
{
    using System.Linq;
    using App.Modules.Core.Shared.Models.Messages;

    public interface ISearchProvider
    {
        IQueryable<SearchResponseItem> Search(string searchTerm);
    }
}
