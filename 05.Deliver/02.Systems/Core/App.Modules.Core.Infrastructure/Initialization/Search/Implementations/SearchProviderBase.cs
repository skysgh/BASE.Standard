using App.Modules.Core.Infrastructure.Data.Db;

namespace App.Modules.Core.Infrastructure.Initialization.Search.Implementations
{
    using System.Linq;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.Messages;

    public abstract class SearchProviderBase<TModel> : ISearchProvider 
        where TModel : class, new()
    {
        protected readonly IDiagnosticsTracingService _diagnosticsTracingService;
        protected readonly IPrincipalService _principalService;
        protected readonly AppModuleDbContextBase _repositoryService;

        protected SearchProviderBase(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, AppModuleDbContextBase repositoryService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._principalService = principalService;
            this._repositoryService = repositoryService;
        }

        public abstract IQueryable<SearchResponseItem> Search(string searchTerm);
    }
}