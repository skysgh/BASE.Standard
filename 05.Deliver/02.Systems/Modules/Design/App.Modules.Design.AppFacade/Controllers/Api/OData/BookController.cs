// Copyright MachineBrains, Inc. 2019

//using System;
//using System.Linq;
//using App.Modules.Core.AppFacade.Controllers.Api.odata.Base;
//using App.Modules.Core.Infrastructure.Services;
//using App.Modules.Design.AppFacade.Controllers.api.odata;
//using App.Modules.Design.Infrastructure.Initialization.Data.Db;
//using Microsoft.AspNet.OData;
//using Microsoft.AspNet.OData.Routing;
//using Microsoft.AspNetCore.Mvc;


//namespace App.Modules.Design.AppFacade.Controllers
//{
//    public class BooksController : CommonODataControllerBase
//    {
//        private BookStoreContext _db;

//        public BooksController(IDiagnosticsTracingService diagnosticsTracingService, IPrincipalService principalService, BookStoreContext context):
//            base(diagnosticsTracingService, principalService)
//        {
//            _db = context;
//            if (context.Books.Count() == 0)
//            {
//                foreach (var b in BookDataSource.GetBooks())
//                {
//                    context.Books.Add(b);
//                    context.Presses.Add(b.Press);
//                }
//                context.SaveChanges();
//            }
//        }

//        [ODataRoute("")]
//        [EnableQuery]
//        public IActionResult Get()
//        {
//            return Ok(_db.Books);
//        }
//        [EnableQuery]
//        public IActionResult GetBook()
//        {
//            return Ok(_db.Books);
//        }


//        [EnableQuery]
//        //[ODataRoute("({key})")]
//        // As per https://blogs.msdn.microsoft.com/davidhardin/2014/12/17/web-api-odata-v4-lessons-learned/
//        public IActionResult GetBook([FromODataUri] Guid key)
//        {
//            return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
//        }


//    }
//}

