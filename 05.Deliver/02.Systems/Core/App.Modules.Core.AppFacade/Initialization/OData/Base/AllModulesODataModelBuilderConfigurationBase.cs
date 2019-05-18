using App.Modules.Core.Shared.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace App.Modules.Core.AppFacade.Initialization.OData.Base
{
    /// <summary>
    /// Module Specific
    /// OData Model Definition.
    /// Invoked by a Model Builder.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AllModulesODataModelBuilderConfigurationBase<T> : IAllModulesOdataModelBuilderConfiguration
        where T : class, IHasGuidId, new()
    {
        private readonly string _controllerName;

        protected AllModulesODataModelBuilderConfigurationBase()
        {
            _controllerName = this.GetControllerNameByConvention(typeof(T));
        }
        protected AllModulesODataModelBuilderConfigurationBase(string controllerName)
        {
            this._controllerName = controllerName;
        }

        public virtual void Define(ODataModelBuilder builder) 
        {
            var entity = builder.EntitySet<T>(this._controllerName).EntityType;
            entity.HasKey(x => x.Id);
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
    }
}