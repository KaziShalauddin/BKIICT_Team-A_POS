namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BKIICT_POS_Management.DatabaseContext.PosManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BKIICT_POS_Management.DatabaseContext.PosManagementDbContext";
        }

        protected override void Seed(BKIICT_POS_Management.DatabaseContext.PosManagementDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
