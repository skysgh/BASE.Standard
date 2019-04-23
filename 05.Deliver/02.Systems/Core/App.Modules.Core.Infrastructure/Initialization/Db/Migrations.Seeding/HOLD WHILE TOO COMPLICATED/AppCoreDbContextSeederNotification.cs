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
    public class CoreModuleDbContextSeederNotification : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederNotification(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(CoreModuleDbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }

        /// <summary>
        /// Seed records that are part of this Module, no matter what (Immutable).
        /// <para>
        /// NOT the right place for demo entries, or data that will be updated
        /// by end users.
        /// </para>
        /// </summary>
        /// <param name="context"></param>
        protected void SeedImmutableEntries(CoreModuleDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(CoreModuleDbContext context)
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

            context.Set<Notification>().AddOrUpdateBasedOnId(records);
            context.SaveChanges();
        }
    }
}