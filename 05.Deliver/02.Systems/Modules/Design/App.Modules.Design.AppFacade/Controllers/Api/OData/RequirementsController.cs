// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.AppFacade.Controllers.Api.OData;
using App.Modules.Core.AppFacade.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Design.Infrastructure.Data.Db.Contexts;
using App.Modules.Design.Shared.Models.Entities.NonTenantSpecific;
using App.Modules.Design.Shared.Models.Messages;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Design.AppFacade.Controllers.Api.OData
{
    /// <summary>
    ///     Controller to return
    ///     <see cref="RequirementDto" />s.
    /// </summary>
    /// <seealso cref="GuidIdCommonODataControllerBase{TDbContext,TEntity,TDto}" />
    public class RequirementsController
        : GuidIdCommonODataControllerBase<
            ModuleDbContext,
            Requirement,
            RequirementDto>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RequirementsController" /> class.
        /// </summary>
        /// <param name="controllerCommonServicesService">The controller common services service.</param>
        /// <param name="dbContext">The database context.</param>
        public RequirementsController(
            IControllerCommonServicesService controllerCommonServicesService,
            ModuleDbContext dbContext)
            : base(controllerCommonServicesService, dbContext)
        {
        }


        /// <summary>
        ///     Gets the requirements.
        /// </summary>
        /// <returns></returns>
        [EnableQuery(PageSize = 100)]
        public override ActionResult<IQueryable<RequirementDto>> Get()
        {
            return Ok(InternalGet(RecordPersistenceState.Active ));
        }


        //[ODataRoute("({key})")]
        /// <summary>
        ///     Gets the requirement.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        [EnableQuery]
        public override ActionResult<RequirementDto> Get([FromODataUri] Guid key)
        {
            return Ok();
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
        public override IActionResult Post(RequirementDto message)
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
        public override IActionResult Put(RequirementDto message)
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