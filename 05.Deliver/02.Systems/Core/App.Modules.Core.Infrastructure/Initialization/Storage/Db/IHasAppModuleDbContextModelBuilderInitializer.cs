namespace App.Modules.Core.Infrastructure.Initialization.Db
{
    using App.Modules.Core.Shared.Contracts;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Contract for Db ModelBuilders,
    /// common to all Modules.
    /// </summary>
    public interface IHasAppModuleDbContextModelBuilderInitializer : IHasAppModuleInitializer
    {
        void Define(ModelBuilder modelBuilder);
    }
}