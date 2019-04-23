namespace App.Modules.Core.Infrastructure.Initialization.Db
{
    using App.Modules.Core.Shared.Contracts;
    using Microsoft.EntityFrameworkCore;

    public interface IHasAppModuleDbContextModelBuilderInitializer //: IHasInitialize
    {
        void Define(ModelBuilder modelBuilder);
    }
}