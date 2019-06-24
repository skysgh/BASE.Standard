﻿using System;
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
    /// </summary>
    /// <seealso
    ///     cref="App.Modules.All.AppFacade.Controllers.Api.OData.GuidIdCommonODataControllerBase{ModuleDbContext, Example, ExampleDto}" />
    public class ExamplesController
        : GuidIdCommonODataControllerBase<
            ModuleDbContext,
            Example,
            ExampleDto>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExamplesController" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        public ExamplesController(
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
        public override ActionResult<IQueryable<ExampleDto>> Get()
        {
            return InternalGet(RecordPersistenceState.Active);
        }

        /// <summary>
        ///     Gets a single queryable item.
        /// </summary>

        //[ODataRoute("({key})")]
        [EnableQuery]
        public override ActionResult<ExampleDto> Get([FromODataUri] Guid key)
        {
            return InternalGet(key, RecordPersistenceState.Active);
        }

        /// <summary>
        /// Creates the specified resource.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.IdCommonODataControllerBase`4.InternalPost(`2)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Post(ExampleDto message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified resource.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.Base.MappedCommonODataControllerBase`3.InternalPut(`2)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Put(ExampleDto message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Deletes the entity specified by the key.
        /// <para>
        /// Override, and optionally invoke
        /// <see cref="M:App.Modules.All.AppFacade.Controllers.Api.OData.IdCommonODataControllerBase`4.InternalDelete(`3)" /></para><para>
        /// If not desired,
        /// throw a <see cref="T:System.NotImplementedException" />.
        /// </para><para>
        /// Important:
        /// the method is abstract to force an override
        /// that is to be decorated by developers with
        /// a specification of the Permissions required.
        /// </para>
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override IActionResult Delete(Guid key)
        {
            throw new NotImplementedException();
        }
    }
}