﻿using App.Modules.Core.Infrastructure.Data.Db;

namespace App.Modules.Core.Infrastructure.Initialization.Db
{
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Shared.Contracts;

    // Contract for Seeders that are invoked at the end of 
    // a Db CodeFirst Migration process.
    // Invoked 
    public interface IHasModuleSpecificDbContextSeedInitializer : IHasModuleSpecificInitializer
    {
        void Seed(ModuleDbContextBase context);
    }
} 