// Copyright MachineBrains, Inc. 2019

using System.Linq;
using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.All.Infrastructure.Search
{
    public abstract class SearchProviderBase<TModel> : ISearchProvider
        where TModel : class, new()
    {
        protected readonly IDiagnosticsTracingService _diagnosticsTracingService;
        protected readonly IPrincipalService _principalService;
        protected readonly ModuleDbContextBase _repositoryService;

        protected SearchProviderBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, ModuleDbContextBase repositoryService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _principalService = principalService;
            _repositoryService = repositoryService;
        }

        public abstract IQueryable<SearchResponseItem> Search(string searchTerm);
    }
}