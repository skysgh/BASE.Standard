
//namespace App.Modules.Core.Infrastructure.Initialization.Search.Implementations
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using App.Modules.Core.Infrastructure.Services;
//    using App.Modules.Core.Shared.Attributes;
//    using App.Modules.Core.Shared.Models.Entities;
//    using App.Modules.Core.Shared.Models.Messages;

//    [Key("Example")]
//    public class ExampleSearchProvider : SearchProviderBase<Example>
//    {
//        public ExampleSearchProvider(IDiagnosticsTracingService diagnosticsTracingService,
//            IPrincipalService principalService, IRepositoryService repositoryService) : base(diagnosticsTracingService,
//            principalService, repositoryService)
//        {
            
//        }

//        public override IQueryable<SearchResponseItem> Search(string searchTerm)
//        {
//            var items =
//                    this._repositoryService.GetByFilter<Example>(AppModuleDbContextNames.Default,
//                        x => x.PublicText.Contains(searchTerm))
//                ;

//            //Do it in two steps to return an IQqueryable:
//            var results =
//                items.Select(x => new SearchResponseItem()
//                {
//                    TypeKey = "Example",
//                    TypeId = x.Id.ToString(),
//                    Title = x.PublicText,
//                    Description = "..."
//                });

//            return results;
//        }
//    }
//}
