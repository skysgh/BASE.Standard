// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.DependencyResolution;
using App.Modules.All.Shared.Models;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.All.AppFacade.Controllers.Api.OData.Configuration
{
    /// <summary>
    ///     Base class for defining an OData
    ///     (DTO) Model Definition, defining the shape of the DTO and
    ///     associating it to the name of the OData Controller
    ///     used to serve it.
    ///     <para>
    ///         Implements
    ///         <see cref="IModuleOdataModelBuilderConfiguration" />
    ///         so that it is automatically discovered at startup
    ///         (see <see cref="AllModulesAppFacadeServiceRegistry" />
    ///     </para>
    ///     <para>
    ///         Used to describes the specified DTO,
    ///         and the OData based Controller
    ///         from which to retrieve it.
    ///     </para>
    ///     <para>
    ///         Note: Does not configure the path by which the controller
    ///         is found (that is done elsewhere)
    ///     </para>
    ///     <para>
    ///         Tip: if the DTO does not have a Guid Id property,
    ///         derive from the base class and define your own Id
    ///         (all OData entities have to have one property designated
    ///         as the <c>Key</c> property).
    ///     </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso
    ///     cref="App.Modules.All.AppFacade.Controllers.Api.OData.Configuration.ModuleODataModelBuilderConfigurationBase{T}" />
    public abstract class ModuleGuidIdODataModelBuilderConfigurationBase<T> :
        ModuleODataModelBuilderConfigurationBase<T>
        where T : class, IHasGuidId, new()
    {
        /// <summary>
        ///     Defines the OData <see cref="EntityTypeConfiguration{T}" /> for
        ///     the given DTO Type.
        ///     <para>
        ///         Note that the OData model Key
        ///         is set to the property called Id.
        ///     </para>
        ///     <para>
        ///         Most overrides won't have to do anything at all
        ///         if their DTOs stick to OData based conventions
        ///         (which are really pretty straight forward)
        ///     </para>
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public override EntityTypeConfiguration<T> Define(
            ODataModelBuilder builder)
        {
            // Use the base class logic 
            // to build and add the model definition
            // for this entity (ie, a Dto)
            // (whereas with EF, we would have added the definition of
            // an Entity, and not the Dto).
            EntityTypeConfiguration<T> entity = base.Define(builder);

            // Whereas EF refers to Ids,
            // OData is about Keys,
            // so have to map relationship.
            // Same thing really.
            entity.HasKey(x => x.Id);

            // Return for overrides to add anything specific.
            // In 99% of cases, if one sticks to OData Conventions
            // there really isn't anything needed to be done 
            // in the override.
            return entity;
        }
    }
}