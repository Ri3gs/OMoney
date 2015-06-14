using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OMoney.Data.Configuration;
using OMoney.Domain.Core.Entities;
using OMoney.Domain.Core.Entities.Security;

namespace OMoney.Data.Context
{
    public class DomainDbContext : DbContext
    {
        public DomainDbContext() : base("name=DomainContext")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopingList> ShopingLists { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<Purchase> PurchaseItems { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new PlanConfiguration());
            modelBuilder.Configurations.Add(new CategoriesConfiguration());
            modelBuilder.Configurations.Add(new PurchaseConfiguration());
            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new RefreshTokenConfiguration());
            modelBuilder.Ignore<IdentityUserClaim>();
            modelBuilder.Ignore<IdentityUserLogin>();
            modelBuilder.Ignore<IdentityUserRole>();
            modelBuilder.Ignore<IdentityRole>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
