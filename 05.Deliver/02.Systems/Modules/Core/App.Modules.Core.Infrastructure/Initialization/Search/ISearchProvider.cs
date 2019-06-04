
using App.Modules.Core.Models.Messages;

namespace App.Modules.Core.Infrastructure.Initialization.Search
{
    using System.Linq;

    public interface ISearchProvider
    {
        IQueryable<SearchResponseItem> Search(string searchTerm);
    }
}
