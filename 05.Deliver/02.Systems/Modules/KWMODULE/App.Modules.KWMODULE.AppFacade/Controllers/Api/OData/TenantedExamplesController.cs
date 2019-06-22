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
using Remotion.Linq;

namespace App.Modules.KWMODULE.AppFacade.Controllers.Api.OData
{
    /// <summary>
    ///     Example of a Controller
    ///     using this Logical Module's <see cref="ModuleDbContext" />,
    ///     and returning a simple <see cref="Example" /> entity,
    ///     automatically converted to an <see cref="ExampleDto" />
    ///     object.
    ///     <para>
    ///         Notice how the controller subclasses
    ///         <see cref="GuidIdCommonODataControllerBase{TDbContext,TEntity,TDto}" />
    ///     </para>
    ///     <para>
    ///         Notice how this Controller uses a <see cref="ModuleDbContext" />
    ///         as opposed to using a <see cref="JoinedModuleDbContext" />
    ///         as other example controllers demonstrate.
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
    ///     <para>
    ///         Notice how the Dto's do not need to carry the TenancyFK
    ///         outside the system. That's because they are posted back
    ///         and the Message they are mapped back to, if the Tenancy
    ///         value is not there, it will be filled in using a Save
    ///         interception to do that, transparently.
    ///     </para>
    /// </summary>
    /// <seealso cref="GuidIdCommonODataControllerBase{ModuleDbContext, TenantedExample, TenantedExampleDto}" />
    public class TenantedExamplesController
        : GuidIdCommonODataControllerBase<
            ModuleDbContext,
            TenantedExample,
            TenantedExampleDto>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TenantedExamplesController" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        public TenantedExamplesController(
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
        public override ActionResult<IQueryable<TenantedExampleDto>> Get()
        {
            return Ok(InternalGet(RecordPersistenceState.Active));
        }


        /// <summary>
        ///     Gets a single queryable item.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        //[ODataRoute("({key})")]
        [EnableQuery]
        public override ActionResult<TenantedExampleDto> Get([FromODataUri] Guid key)
        {
            return Ok(InternalGet(key, RecordPersistenceState.Active));
        }
    }
}