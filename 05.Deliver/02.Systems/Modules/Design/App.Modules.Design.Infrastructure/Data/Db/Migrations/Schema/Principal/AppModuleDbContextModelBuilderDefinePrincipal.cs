//using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
//using Microsoft.EntityFrameworkCore;

//namespace App.Modules.Design.Infrastructure.Data.Db.Migrations.Schema.Principal
//{
//    public class AppModuleDbContextModelBuilderDefinePrincipal
//        : App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Principal.AppModuleDbContextModelBuilderDefinePrincipal
//    {
//        public void DefineSchema(ModelBuilder modelBuilder)
//        {
//            new DefaultTableAndSchemaNamingConvention()
//                .Define<Models.Entities.Principal>(
//                    modelBuilder,
//                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
//                    );
//        }
//    }
//}
