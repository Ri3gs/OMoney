using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Configurations
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            ToTable("Accounts");
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Name).IsRequired().HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(255);
            Property(a => a.Amount).IsRequired().HasColumnName("Amount");
            Property(a => a.Comments).IsOptional().HasColumnName("Comments");
            Property(a => a.CreatedAt).IsRequired().HasColumnName("CreatedAt");
            Property(a => a.UpdatedAt).IsRequired().HasColumnName("UpdatedAt");
            Property(a => a.AccountType).IsRequired().HasColumnName("AccountType");

            HasRequired(a => a.User).WithMany(u => u.Accounts).HasForeignKey(a => a.UserId).WillCascadeOnDelete(true);
            HasRequired(a => a.Currency).WithMany(c => c.Accounts).HasForeignKey(a => a.CurrencyId).WillCascadeOnDelete(false);
        }
    }
}
