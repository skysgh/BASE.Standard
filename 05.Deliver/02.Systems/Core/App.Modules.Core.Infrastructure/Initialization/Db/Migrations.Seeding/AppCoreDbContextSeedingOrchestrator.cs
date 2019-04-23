using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;

namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Messages;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Services.Implementations;
    using App.Modules.Core.Infrastructure.Contracts;

    // Invoked from within AppCoreDbMigrationsConfiguration.Seed method, 
    public class CoreModuleDbContextSeedingOrchestrator
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IHostSettingsService _hostSettingsService;
        private readonly IConfigurationStepService _configurationStepService;

        public CoreModuleDbContextSeedingOrchestrator(
            IDiagnosticsTracingService diagnosticsTracingService, 
            IHostSettingsService hostSettingsService ,
            IConfigurationStepService configurationStepService)
        {
            this._diagnosticsTracingService = diagnosticsTracingService;
            this._hostSettingsService = hostSettingsService;
            this._configurationStepService = configurationStepService;
        }

        // This method will be called after migrating to the latest version.
        public void Initialize(CoreModuleDbContext context)
        {
            using (ElapsedTime elapsedTime = new ElapsedTime())
            {

                //if (!PowershellServiceLocatorConfig.Activated)
                //{
                //    //Actually, Seeding needs to be done in a specific order
                //    //so for now ByHand is preferable 
                    SeedByReflection(context);
                //}
                //else
                //{
                //    //Reflection does not work under Powershell, so:
                //SeedByHand(context);
                //}

                var color = ConfigurationStepStatus.White;
                if (elapsedTime.Elapsed.TotalMilliseconds >= 5000)
                {
                    color = ConfigurationStepStatus.Orange;
                }
                if (elapsedTime.Elapsed.TotalMilliseconds >= 1000)
                {
                    color = ConfigurationStepStatus.Red;
                }
                this._configurationStepService.Register(ConfigurationStepType.General, color, "Seeding",$"Core seeding completed. Took {elapsedTime.ElapsedText}.");
                

            }
        }

        // I spend ages on this...but it won't work. 
        // Even though Db Modeling can work via reflection
        // even when invoked from powershell (add-migration)
        // This approach will work from code, but not powershell (update-database)
        // You *have* to define Seed elements by hand.
        // In one way it's better. There's an order which must be followed
        // when seeding, that can be done via Attributes ([After/Before])
        // but for now this is ok.
        private void SeedByReflection(CoreModuleDbContext context)
        {
            DependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextSeedInitializer>()
                .ForEach(x => { if (!(typeof(IHasIgnoreThis).IsAssignableFrom(x.GetType()))) { x.Seed(context); } });
        }

        //private void SeedByHand(CoreModuleDbContext dbContext)
        //{
        //    AttachDebuggerWhenRunningUnderPowershell();

        //    // Ensure sequence is DataClassification, Tenant, Principal, Role, Session, then Etc.
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Exception Records. Start...");
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederExceptionRecord>().Seed(dbContext);
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding End. Start...");

        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Data Classifications. Start...");
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederDataClassification>().Seed(dbContext);
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Data Classifications. End.");

        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding System Roles. Start...");
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederSystemRole>().Seed(dbContext);
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding System Roles. End.");

        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Tenants. Start...");
        //    SeedTenants(dbContext);
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Tenants. End.");


        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Pricipals. Start...");
        //    SeedPrincipals(dbContext);
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Principals. End.");


        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Sessions. Start...");
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederSession>().Seed(dbContext);
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Sessions. End.");

        //    //After Tenant
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Notifications. Start...");
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederNotification>().Seed(dbContext);
        //    _diagnosticsTracingService.Trace(TraceLevel.Verbose, $"Seeding Notifications. End.");
        //}

        //private static void SeedTenants(CoreModuleDbContext dbContext)
        //{

        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederTenant>().Seed(dbContext);
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederTenantProperty>().Seed(dbContext);
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederTenantClaim>().Seed(dbContext);
        //}

        //private static void SeedPrincipals(CoreModuleDbContext dbContext)
        //{
            
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederPrincipalTag>().Seed(dbContext);
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederPrincipalCategory>().Seed(dbContext);
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederPrincipal>().Seed(dbContext);
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederPrincipalLogin>().Seed(dbContext);
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederPrincipalProperty>().Seed(dbContext);
        //    AppDependencyLocator.Current.GetInstance<CoreModuleDbContextSeederPrincipalClaim>().Seed(dbContext);
        //}

        //private void AttachDebuggerWhenRunningUnderPowershell()
        //{
        //    var debuggerConfiguration = this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();
        //    if (debuggerConfiguration.CodeFirstAttachDebugger)
        //    {
        //        // You'll *REALLY* like this piece of code if you are having trouble
        //        // with seeding:
        //        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //        if (System.Diagnostics.Debugger.IsAttached == false)
        //        {
        //           //System.Diagnostics.Debugger.Launch();
        //        }
        //    }
        //}
    }
}