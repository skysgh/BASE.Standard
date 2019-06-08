using App.Modules.All.Shared.Models;
using Microsoft.AspNet.OData.Builder;

namespace App.Modules.Core.Controllers.Api.OData.Configuration.Base
{
    public abstract class AllModulesGuidIdODataModelBuilderConfigurationBase<T> : 
        AllModulesODataModelBuilderConfigurationBase<T>
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