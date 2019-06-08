using App.Modules.All.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema
{
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