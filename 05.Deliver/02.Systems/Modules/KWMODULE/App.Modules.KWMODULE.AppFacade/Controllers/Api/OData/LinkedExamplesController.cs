using System;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.KWMODULE.Infrastructure.Data.Db.Contexts;
using App.Modules.KWMODULE.Shared.Models.Entities;
using App.Modules.KWMODULE.Shared.Models.Messages;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.KWMODULE.AppFacade.Controllers.Api.OData
{
    /// <summary>
    ///     Example of a Controller
    ///     using this Logical Module's <see cref="JoinedModuleDbContext" />,
    ///     and returning a simple <see cref="LinkedExample" /> entity,
    ///     that refers to an entity in the Core module (ie, it's linking
    ///     two schemas), and automatically converted to an <see cref="LinkedExampleDto" />
    ///     object.
    ///     <para>
    ///         Notice how this Controller uses a <see cref="ModuleDbContext" />
    ///         as opposed to using a <see cref="JoinedModuleDbContext" />
    ///         as other example controllers demonstrate.
    ///     </para>
    ///     <para>
    ///         Notice how the controller subclasses
    ///         <see cref="GuidIdCommonODataControllerBase{TDbContext,TEntity,TDto}" />
    ///     </para>
    ///     <para>
    ///         Notice how this Controller uses a <see cref="JoinedModuleDbContext" />
    ///         as opposed to using a simpler <see cref="ModuleDbContext" />
    ///         Notice how the <see cref="JoinedModuleDbContext" /> actually is invoking
    ///         <see cref="ModuleDbContext" /> and Core's ModuleDbContext *first*...
    ///         that's how it ensures the tables exist, even though
    ///         <see cref="JoinedModuleDbContext" /> has migrations/schema building turned off
    ///         (pretty slick...)
    ///     </para>
    ///     <para>
    ///         Notice how this method exposes public Actions, that in
    ///         term invoke protected InternalXXX actions. This is to
    ///         ensure that Controller designers associate appropriate
    ///         Permissions to each Action.
    ///     </para>
    ///     <para>
    ///         Notice the automatic conversion of Entites to Dtos
    ///         (pretty slick).
    ///     </para>
    /// </summary>
    /// <seealso
    ///     cref="App.Modules.All.AppFacade.Controllers.Api.OData.GuidIdCommonODataControllerBase{JoinedModuleDbContext, LinkedExample, LinkedExampleDto}" />
    public class LinkedExamplesController
        : GuidIdCommonODataControllerBase<
            JoinedModuleDbContext,
            LinkedExample,
            LinkedExampleDto>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LinkedExamplesController" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        public LinkedExamplesController(
            IControllerCommonServicesService controllerCommonServicesService,
            JoinedModuleDbContext dbContext)
            : base(controllerCommonServicesService, dbContext)
        {
        }

        /// <summary>
        ///     Gets a queryable set of items, limited to 100 items, max.
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        public override ActionResult<IQueryable<LinkedExampleDto>> Get()
        {
            return InternalGet(RecordPersistenceState.Active, x => x.DataClassification);
        }


        /// <summary>
        ///     Gets a single queryable item.
        /// </summary>
        //[ODataRoute("({key})")]
        [EnableQuery]
        public override ActionResult<LinkedExampleDto> Get([FromODataUri] Guid key)
        {
            return Ok(InternalGet(key, RecordPersistenceState.Active));
        }
    }
}