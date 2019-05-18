//namespace App.Modules.Core.Infrastructure.Db.Schema
//{
//    using Microsoft.EntityFrameworkCore;
//    using App.Modules.Core.Infrastructure.Initialization;
//    using App.Modules.Core.Infrastructure.Initialization.Db;
//    using App.Modules.Core.Shared.Models.Entities;

//    public class AppModuleDbContextModelBuilderDefineTenantMember2Role : IHasAppModuleDbContextModelBuilderInitializer
//    {
//        public void Define(ModelBuilder modelBuilder)
//        {
//new DefaultTableAndSchemaNamingConvention().Define<TenantMember>(modelBuilder);
//            //var order = 1;

//            modelBuilder.Entity<TenantMember>()
//                .HasMany(s => s.Roles)
//                .WithMany()
//                .Map(j =>
//                {
//                    j.ToTable(typeof(TenantMember).Name + "2" + /*(typeof(SystemRole)).Name)*/ "Role");
//                    j.MapLeftKey(typeof(TenantMember).Name + "FK");
//                    j.MapRightKey(typeof(SystemRole).Name + "FK");
//                });
//        }
//    }
//}