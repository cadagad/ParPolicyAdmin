using BusinessLogic.Models;

namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BusinessLogic.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(BusinessLogic.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Sources.AddOrUpdate(
                new Source() { SourceId = 1, Code = "Undefined", Division = null, Region = null, IsActive = true },
                new Source() { SourceId = 2, Code = "C01", Division = "Canada", Region = "North America", IsActive = true },
                new Source() { SourceId = 3, Code = "C03", Division = "Canada", Region = "North America", IsActive = true },
                new Source() { SourceId = 4, Code = "C06", Division = "Canada", Region = "North America", IsActive = true },
                new Source() { SourceId = 5, Code = "C07", Division = "Canada", Region = "North America", IsActive = true },
                new Source() { SourceId = 6, Code = "C09", Division = "Canada", Region = "North America", IsActive = true },
                new Source() { SourceId = 7, Code = "C10", Division = "Canada", Region = "North America", IsActive = true },
                new Source() { SourceId = 8, Code = "U01", Division = "United States", Region = "North America", IsActive = true },
                new Source() { SourceId = 9, Code = "U04", Division = "United States", Region = "North America", IsActive = true },
                new Source() { SourceId = 10, Code = "U06", Division = "United States", Region = "North America", IsActive = true },
                new Source() { SourceId = 11, Code = "U07", Division = "United States", Region = "North America", IsActive = true },
                new Source() { SourceId = 12, Code = "HK1", Division = "Hong Kong", Region = "Asia", IsActive = true },
                new Source() { SourceId = 13, Code = "PH1", Division = "Philippines", Region = "Asia", IsActive = true },
                new Source() { SourceId = 14, Code = "U2V", Division = "United States", Region = "North America", IsActive = true },
                new Source() { SourceId = 15, Code = "UPV", Division = "United States", Region = "North America", IsActive = true }
                );
        }
    }
}
