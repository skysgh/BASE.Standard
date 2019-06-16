using App.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.All.AppFacade.Controllers.Api.OData.Configuration
{

    /// <summary>
    /// Module Specific
    /// OData Model Definition.
    /// Invoked by a Model Builder.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModuleODataModelBuilderConfigurationBase<T> :
        IModuleOdataModelBuilderConfiguration
        where T : class, new()
    {
        private string _controllerName;

        /// <summary>
        /// Gets or sets the name of the Controller
        /// associated to the T.
        /// <para>
        /// For example, given "Principal", the Controller
        /// name will be "PrincipalsController"
        /// </para>
        /// </summary>
        protected string ControllerName { get => _controllerName; set => _controllerName = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleODataModelBuilderConfigurationBase{T}" /> class.
        /// </summary>
        protected ModuleODataModelBuilderConfigurationBase()
        {
            _controllerName = this.GetControllerNameByConvention(typeof(T));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleODataModelBuilderConfigurationBase{T}"/> class.
        /// </summary>
        /// <param name="controllerName">Name of the controller.</param>
        protected ModuleODataModelBuilderConfigurationBase(string controllerName)
        {
            ControllerName = controllerName;
        }

        /// <summary>
        /// override this when you have more versions of an object 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="apiVersion"></param>
        public virtual void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            Define(builder);
        }
        /// <summary>
        /// Defines the entity set for T.
        /// <para>
        /// Note that the Key is not set (it is up to a subclass to define which
        /// property of the DTO is the Key).
        /// </para>
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public virtual EntityTypeConfiguration<T> Define(ODataModelBuilder builder)
        {
            EntityTypeConfiguration<T> entity =
                builder.EntitySet<T>(ControllerName).EntityType;

            return entity;

        }


    }
}