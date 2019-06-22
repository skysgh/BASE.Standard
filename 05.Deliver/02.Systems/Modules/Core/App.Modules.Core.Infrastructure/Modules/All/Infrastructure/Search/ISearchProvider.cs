// Copyright MachineBrains, Inc. 2019

using System.Linq;
using App.Modules.All.Infrastructure.Initialization;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.All.Infrastructure.Search
{
    public interface ISearchProvider :
        IModuleInitializer
    {
        IQueryable<SearchResponseItem> Search(string searchTerm);
    }
}