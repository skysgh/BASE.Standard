using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Infrastructure.Constants.Users;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Seeding.ImmutableData
{
    /// <summary>
    /// Class for
    ///  seeding of immutable data
    /// as part of 
    /// DbContext Migrations.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData.ModuleSpecificDbContextModelBuilderImmutableDataSeederBase" />
    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederPrincipalCategory :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        /// <summary>
        /// Invoke to create immutable data
        /// as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrincipalCategory>().HasData(
                 new PrincipalCategory()
                 {
                     Id = ((int)PrincipalTypes.Unspecified).ToGuid(),
                     Enabled = true,
                     Title = "Unspecified",
                     Description = "An error state as Principal type is not defined."
                 },
                 new PrincipalCategory()
                 {
                     Id = ((int)PrincipalTypes.Unknown).ToGuid(),
                     Enabled = true,
                     Title = "Unknown",
                     Description = "An error state as Principal type is unclear."
                 },

                 new PrincipalCategory()
                 {
                     Id = ((int)PrincipalTypes.System).ToGuid(),
                     Enabled = true,
                     Title = "System",
                     Description = "This system."
                 },


                    new PrincipalCategory()
                    {
                        Id = ((int)PrincipalTypes.Default).ToGuid(),
                        Enabled = true,
                        Title = "Default",
                        Description = "A remote service or user."
                    },

                    new PrincipalCategory()
                    {
                        Id = ((int)PrincipalTypes.ServiceClient).ToGuid(),
                        Enabled = true,
                        Title = "Service",
                        Description = "A remote service (whether owned by organisation or other."
                    },

                    new PrincipalCategory()
                    {
                        Id = ((int)PrincipalTypes.User).ToGuid(),
                        Enabled = true,
                        Title = "User",
                        Description = "General users."
                    }
                );
        }
    }
}