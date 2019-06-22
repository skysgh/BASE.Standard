﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Contexts;

namespace App.Modules.Design.Infrastructure.Data.Db.Contexts
{
    /// <summary>
    ///     <para>
    ///         Note that each logical Module requires it's own ModuleDbContext.
    ///     </para>
    /// </summary>
    public class ModuleDbContextFactory : ModuleDbContextFactoryBase<ModuleDbContext>
    {
    }
}