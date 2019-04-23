namespace App.Modules.Core.Infrastructure.Db.Schema.Conventions
{
    using Microsoft.EntityFrameworkCore;

    public class DefaultTableAndSchemaNamingConvention
    {
        public void Define<T>(ModelBuilder modelBuilder, string schema = Constants.Db.CoreModuleDbContextNames.Core)
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