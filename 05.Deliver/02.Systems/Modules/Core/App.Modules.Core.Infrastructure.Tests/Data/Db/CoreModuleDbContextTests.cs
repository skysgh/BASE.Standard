using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.Data.Db;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Data.Db
{
    public class CoreModuleDbContextTests : TestClassBase
    {
        [Fact]
        public void Get_DbContext_Dependencies_By_DI()
        {
            var r1 = DependencyLocator.Current.GetInstance<IAppDbContextManagementService>();
            Assert.NotNull(r1);

            var r2 = DependencyLocator.Current.GetInstance<IConfiguration>();
            Assert.NotNull(r2);

        }

        [Fact]
        public void Get_DbContext_By_Reflection()
        {
            var result = DependencyLocator.Current.GetInstance<ModuleDbContext>();

            Assert.NotNull(result);
        }

        [Fact]
        public void DbContext_Can_Be_Migrated()
        {
            var result = DependencyLocator.Current.GetInstance<ModuleDbContext>();

            result.Database.Migrate();

            Assert.True(true,"Migration did not throw an exception");
        }

    }
}
