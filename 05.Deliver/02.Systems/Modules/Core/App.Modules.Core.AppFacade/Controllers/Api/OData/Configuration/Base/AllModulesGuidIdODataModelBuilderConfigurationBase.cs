using App.Modules.Core.Models;
using App.Modules.Models;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.AppFacade.Controllers.Api.OData.Configuration
{
    public abstract class AllModulesGuidIdODataModelBuilderConfigurationBase<T> : AllModulesODataModelBuilderConfigurationBase<T>
        where T : class, IHasGuidId, new()
    {

        public override EntityTypeConfiguration<T> Define(ODataModelBuilder builder)
        {
            var entity = base.Define(builder);

            entity.HasKey(x => x.Id);

            return entity;
        }

    }
}