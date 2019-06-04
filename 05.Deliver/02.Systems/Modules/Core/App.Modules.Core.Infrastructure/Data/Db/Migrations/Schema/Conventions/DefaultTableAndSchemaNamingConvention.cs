using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions
{
    public class DefaultTableAndSchemaNamingConvention
    {
        public void Define<T>(ModelBuilder modelBuilder, 
            string schema 
            )
            where T : class
        {
            string name = typeof(T).Name;

            if (name.EndsWith("y"))
            {
                name = name.Substring(0, name.Length - 1) + "ies";
            }
            else
            {
                name += "s";
            }

            modelBuilder.Entity<T>().ToTable(name, schema);

        }
    }

}