namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema
{
    using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema;
    using App.Modules.Core.Shared.Constants.ModuleSpecific;
    using Microsoft.EntityFrameworkCore;

    public abstract class ModuleSpecificDbContextModelBuilderDefineBase : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public string DefaultSchemaName
        {
            get
            {
               return _defaultSchemaName??(_defaultSchemaName = Module.Id(this.GetType()));
            }
            set { _defaultSchemaName = value; }
        }

        private string _defaultSchemaName;
        public abstract void DefineSchema(ModelBuilder model);

    }
}