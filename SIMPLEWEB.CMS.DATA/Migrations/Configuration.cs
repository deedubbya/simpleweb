namespace SIMPLEWEB.CMS.DATA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SIMPLEWEB.CMS.DATA.SimpleWebDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SIMPLEWEB.CMS.DATA.SimpleWebDBContext";
        }

        protected override void Seed(SIMPLEWEB.CMS.DATA.SimpleWebDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
