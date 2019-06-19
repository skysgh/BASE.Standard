//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.MutableData.DemoData
//{
//    class Class1
//    {



//        protected override void SeedImmutableData(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Notification>().HasData(
//                    new Notification
//                    {
//                        Id = 1.ToGuid(),
//                        TenantFK = 1.ToGuid(),
//                        Type = NotificationType.Notification,
//                        Level = TraceLevel.Info,
//                        From = "System",
//                        Class = "xyz",
//                        ImageUrl = "...",
//                        Text = "Some Message about Foo.",
//                        DateTimeCreatedUtc = DateTimeOffset.UtcNow
//                    },
//                    new Notification
//                    {
//                        Id = 2.ToGuid(),
//                        TenantFK = 1.ToGuid(),
//                        Type = NotificationType.Message,
//                        Level = TraceLevel.Warn,
//                        From = "System",
//                        Class = "xyz",
//                        ImageUrl = "...",
//                        Text = "Another Message for you.",
//                        DateTimeCreatedUtc = DateTimeOffset.UtcNow
//                    },
//                    new Notification
//                    {
//                        Id = 3.ToGuid(),
//                        TenantFK = 1.ToGuid(),
//                        Type = NotificationType.Task,
//                        Level = TraceLevel.Info,
//                        From = "System",
//                        Class = "xyz",
//                        ImageUrl = "...",
//                        Text = "A Message you've read.",
//                        DateTimeCreatedUtc = DateTimeOffset.UtcNow,
//                        DateTimeReadUtc = DateTimeOffset.UtcNow
//                    });

//        }

//    }
//}
//}
