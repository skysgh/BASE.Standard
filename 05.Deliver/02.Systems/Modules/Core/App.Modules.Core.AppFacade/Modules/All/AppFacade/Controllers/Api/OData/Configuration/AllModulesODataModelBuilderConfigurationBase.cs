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
    public abstract class AllModulesODataModelBuilderConfigurationBase<T> :
        IAllModulesOdataModelBuilderConfiguration
        where T : class, new()
    {
        private string _controllerName;

        protected string ControllerName { get => _controllerName; set => _controllerName = value; }

        protected AllModulesODataModelBuilderConfigurationBase()
        {
            _controllerName = this.GetControllerNameByConvention(typeof(T));
        }
        protected AllModulesODataModelBuilderConfigurationBase(string controllerName)
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
        public virtual EntityTypeConfiguration<T> Define(ODataModelBuilder builder)
        {
            EntityTypeConfiguration<T> entity =
                builder.EntitySet<T>(ControllerName).EntityType;

            return entity;

        }


    }
}