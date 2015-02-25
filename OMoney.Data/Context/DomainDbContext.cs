using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OMoney.Data.Configuration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Context
{
    public class DomainDbContext : DbContext
    {
        public DomainDbContext() : base("name=DomainContext")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new {r.RoleId, r.UserId});
            base.OnModelCreating(modelBuilder);
        }
    }
}
