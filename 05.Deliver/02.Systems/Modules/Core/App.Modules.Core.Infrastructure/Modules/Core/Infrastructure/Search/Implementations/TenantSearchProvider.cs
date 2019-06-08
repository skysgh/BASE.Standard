using System;
using System.Linq;
using App.Modules.All.Infrastructure.Search;
using App.Modules.All.Shared.Attributes;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Search.Implementations
{
    [Key("Tenant")]
    public class TenantSearchProvider : SearchProviderBase<Tenant>
    {
        public TenantSearchProvider(IDiagnosticsTracingService diagnosticsTracingService,
            IPrincipalService principalService, ModuleDbContext repositoryService) : base(diagnosticsTracingService,
            principalService, repositoryService)
        {

        }

        public override IQueryable<SearchResponseItem> Search(string searchTerm)
        {
            throw new NotImplementedException();
            ;
            //var items =
            //    this._repositoryService.GetByFilter<Tenant>(Constants.Db.AppCoreDbContextNames.Core,
            //    x => x.DisplayName.Contains(searchTerm))
            //    .Include(x=>x.Claims)
            //    .Include(x=>x.Properties);

            ////Do it in two steps to return an IQqueryable:
            //var results =
            //    items.Select(x=>new SearchResponseItem()
            //        {
            //            TypeKey = "Tenant",
            //            TypeId = x.Id.ToString(),
            //            Title = x.DisplayName,
            //            Description = x.Properties.SingleOrDefault(y => y.Key == "Description").Value
            //        });

            //return results;
        }
    }
}
