
//namespace App.Modules.Core.AppFacade.Controllers.Api.odata.Base
//{
//    using App;
//    using System;
//    using System.Linq;
//    using System.Linq.Expressions;
//    using App.Modules.Core.Infrastructure.Services;
//    using App.Modules.Core.Shared.Models;
//    using AutoMapper.QueryableExtensions;
//    using Microsoft.AspNetCore.Mvc;
//    using Microsoft.AspNet.OData;
//    using App.Modules.Core.Shared.Models.Entities;
//    using Microsoft.EntityFrameworkCore;
//    using App.Modules.Core.AppFacade.Services;

//    /// <summary>
//    /// Just about every controller, whatever module,  
//    /// *should* inherit in one way or another
//    /// from this base controller.
//    /// <para>
//    /// The advantages include:
//    /// * has a built in concept of Logical Entity and exposed Dto Message equivalent 
//    ///   of that Entity, as well as the logic to leverage AutoMapper to pass the linq
//    ///   through the layers. ie, the Magic of ProjectTo.
//    /// * only one base class that needs to be updated to .NET Core when we get there.
//    /// * ensures that all classes are injected with an implementation of 
//    /// <see cref="IDiagnosticsTracingService"/> and <see cref="IPrincipalService"/>
//    /// so there is absolutely no excuse for poor diagnostics logs, or security...
//    /// (that said, still don't trust developers rushing to meet deadlines to take 
//    /// care of ISO-25010/Maintainability or ISO-25010/Security, so we handle 
//    /// Security and Logging as GLobal Filters anyway).
//    /// </para>
//    /// </summary>
//    /// <seealso cref="System.Web.OData.ODataController" />
//    public abstract class RecordStateCommonODataControllerBase<TDbContext,TEntity, TDto>
//        : MappedCommonODataControllerBase<TDbContext,TEntity,TDto>
//        where TDbContext : DbContext
//        where TEntity : class, IHasRecordState, new()
//        where TDto : class, new()
//    {
//        //protected /*readonly*/ string _dbContextIdentifier;


//        protected RecordStateCommonODataControllerBase(
//            IControllerCommonServicesService<TDbContext> controllerCommonServicesService
//            ) :

//            base(controllerCommonServicesService)
//        {
//        }








//    }
//}