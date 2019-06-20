using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.DependencyResolution;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Data.Db
{
    public class CoreModuleDbContextTests : TestClassBase
    {
        
            [SelfNamingFact]
        public void Get_DbContext_Dependencies_By_DI_SuchAs_HttpContextService()
        {
            var r1 = DependencyLocator.Current.GetInstance<IHttpContextService>();
            Assert.NotNull(r1);
        }

        [SelfNamingFact]
        public void Get_DbContext_Dependencies_By_DI_SuchAs_IOperationContextService()
        {
            var r1 = DependencyLocator.Current.GetInstance<IOperationContextService>();
            Assert.NotNull(r1);
        }

        [SelfNamingFact]
        public void Get_DbContext_Dependencies_By_DI_SuchAs_IDbContextPreCommitService()
        {
            var r1 = DependencyLocator.Current.GetInstance<IDbContextPreCommitService>();
            Assert.NotNull(r1);
        }


        [SelfNamingFact]
        public void Get_DbContext_Dependencies_By_DI_SuchAs_IAppDbContextManagementService()
        {
            var r1 = DependencyLocator.Current.GetInstance<IAppDbContextManagementService>();
            Assert.NotNull(r1);
        }
        [SelfNamingFact]
        public void Get_DbContext_Dependencies_By_DI_SuchAs_IConfig()
        {
            var r2 = DependencyLocator.Current.GetInstance<IConfiguration>();
            Assert.NotNull(r2);

        }
        [SelfNamingFact]
        public void Get_DbContext_Dependencies_By_DI_SuchAs_DbContextOptions()
        {
            var r2 = DependencyLocator.Current.GetInstance<DbContextOptions<ModuleDbContextBase>>();
            Assert.NotNull(r2);

        }




        [SelfNamingFact]
        public void Get_DbContext_By_Reflection()
        {
            var result = DependencyLocator.Current.GetInstance<ModuleDbContext>();

            Assert.NotNull(result);
        }

        [SelfNamingFact]
        public void DbContext_Can_Be_Migrated()
        {
            var result = DependencyLocator.Current.GetInstance<ModuleDbContext>();

            result.Database.Migrate();

            Assert.True(true, "Migration did not throw an exception");
        }

    }
}
