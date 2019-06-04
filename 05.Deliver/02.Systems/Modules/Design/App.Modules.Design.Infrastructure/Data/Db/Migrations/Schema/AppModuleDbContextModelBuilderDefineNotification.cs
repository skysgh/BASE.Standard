using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Design.Infrastructure.Data.Db.Migrations.Schema.Notifications
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineNotification :
        App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Notifications
        .AppModuleDbContextModelBuilderDefineNotification
    {
        public AppModuleDbContextModelBuilderDefineNotification()
        {
            // Change it to point to Core.
            this.DefaultSchemaName = "Core";
        }
    }
}