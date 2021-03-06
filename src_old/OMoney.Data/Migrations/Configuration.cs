using System.Data.Entity.Migrations;
using OMoney.Data.Contexts;
using OMoney.Domain.Core.Entities.Security;

namespace OMoney.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Clients.AddOrUpdate(c => c.Id,
                new Client { Id = "androidApp", Secret = "androidSecret", Name = "Android Native Application", ApplicationType = ApplicationTypes.NativeConfidential, Active = true, RefreshTokenLifeTime = 14400, AllowedOrigin = "*" },
                new Client { Id = "ngAuthApp", Secret = "ngappSecret", Name = "AngularJS front-end Application", ApplicationType = ApplicationTypes.JavaScript, Active = true, RefreshTokenLifeTime = 7200, AllowedOrigin = "*" });
        }
    }
}
