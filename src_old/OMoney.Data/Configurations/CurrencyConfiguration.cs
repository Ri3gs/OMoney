using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Configurations
{
    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            ToTable("Currencies");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
            Property(c => c.Code).IsRequired().HasColumnName("Code").HasMaxLength(10);

            HasRequired(c => c.User).WithMany(u => u.Currencies).HasForeignKey(c => c.UserId).WillCascadeOnDelete(true);
        }
    }
}
