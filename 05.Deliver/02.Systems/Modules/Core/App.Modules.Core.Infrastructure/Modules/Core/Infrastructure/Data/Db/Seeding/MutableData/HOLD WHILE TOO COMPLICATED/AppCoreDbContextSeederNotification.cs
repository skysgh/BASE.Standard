namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class CoreModuleDbContextSeederNotification : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederNotification(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {
            var records = new []{
                    new Notification
                    {
                        Id = 1.ToGuid(),
                        TenantFK = 1.ToGuid(),
                        Type = NotificationType.Notification,
                        Level = TraceLevel.Info,
                        From = "System",
                        Class = "xyz",
                        ImageUrl = "...",
                        Text = "Some Message about Foo.",
                        DateTimeCreatedUtc = DateTime.UtcNow
                    },
                    new Notification
                    {
                        Id = 2.ToGuid(),
                        TenantFK = 1.ToGuid(),
                        Type = NotificationType.Message,
                        Level = TraceLevel.Warn,
                        From = "System",
                        Class = "xyz",
                        ImageUrl = "...",
                        Text = "Another Message for you.",
                        DateTimeCreatedUtc = DateTime.UtcNow
                    },
                    new Notification
                    {
                        Id = 3.ToGuid(),
                        TenantFK = 1.ToGuid(),
                        Type = NotificationType.Task,
                        Level = TraceLevel.Info,
                        From = "System",
                        Class = "xyz",
                        ImageUrl = "...",
                        Text = "A Message you've read.",
                        DateTimeCreatedUtc = DateTime.UtcNow,
                        DateTimeReadUtc = DateTime.UtcNow
                    }
            };

            moduleDbContext.Set<Notification>().AddOrUpdateBasedOnId(records);
            moduleDbContext.SaveChanges();
        }
    }
}