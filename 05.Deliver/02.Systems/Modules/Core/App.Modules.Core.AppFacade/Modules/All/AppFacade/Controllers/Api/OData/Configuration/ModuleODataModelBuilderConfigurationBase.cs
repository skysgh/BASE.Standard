// Copyright MachineBrains, Inc. 2019

using System;
using App.Extensions;
using App.Modules.All.AppFacade.DependencyResolution;
using App.Modules.All.Shared.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

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
    ///         This is the rock bottom base class, which doesn't make
    ///         any supposition about the DTO entity being exposed.
    ///         Meaning that one must override the <see cref="Define" />
    ///         method to at least define what is the <c>Key</c> property
    ///         of the entity.
    ///     </para>
    ///     <para>
    ///         Because 99% of entities will have a <see cref="Guid" /> based <c>Id</c>
    ///         (ie, implement <see cref="IHasGuidId" />) it is
    ///         recommended to instead use
    ///         <see cref="GuidIdCommonODataControllerBase{TDbContext,TEntity,TDto}" />
    ///         which derives from this class - but already takes
    ///         care of defining the Key as the Guid based Id property.
    ///     </para>
    ///     For entities that don't have an Id property (really?)
    ///     fall back to using this, but override <see cref="Define" />
    ///     to do the needed working.
    ///     <para>
    ///     </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModuleODataModelBuilderConfigurationBase<T> :
        IModuleOdataModelBuilderConfiguration
        where T : class, new()
    {
        private string _controllerName;


        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="ModuleODataModelBuilderConfigurationBase{T}" /> class.
        /// </summary>
        /// <param name="controllerName">
        ///     Optional Name of the controller. If none supplied the default will be the Plural of the
        ///     Type name..
        /// </param>
        protected ModuleODataModelBuilderConfigurationBase(
            string controllerName = null)
        {
            ControllerName = controllerName;
        }

        /// <summary>
        ///     Gets or sets the name of the Controller
        ///     associated to the controller's Entity.
        ///     <para>
        ///         For example, given "Principal", the Controller
        ///         name will be "PrincipalsController"
        ///     </para>
        /// </summary>
        protected string ControllerName
        {
            get => _controllerName ?? (_controllerName =
                       this.GetControllerNameByConvention(typeof(T)));
            set => _controllerName = value;
        }


        /// <summary>
        ///     override this when you have more versions of an object
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="apiVersion"></param>
        public virtual void Apply(ODataModelBuilder builder,
            ApiVersion apiVersion)
        {
            //if (apiVersion.MajorVersion == 1)
            //{
            //}
            //if (apiVersion.MajorVersion == 2)
            //{
            //}
            //Else, the general case:
            Define(builder);
        }

        /// <summary>
        ///     Defines the entity set for T.
        ///     <para>
        ///         Note that the Key is not set (it is up to a subclass to define which
        ///         property of the DTO is the Key).
        ///     </para>
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public virtual EntityTypeConfiguration<T> Define(
            ODataModelBuilder builder)
        {
            // Build and add the model definition
            // for this entity (ie, a Dto)
            // (whereas with EF, we would have added the definition of
            // an Entity, and not the Dto).
            EntityTypeConfiguration<T> entity =
                builder.EntitySet<T>(ControllerName).EntityType;

            return entity;
        }
    }
}