using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(255);
            Property(c => c.Planned).IsRequired().HasColumnName("Planned");
            Property(c => c.Spent).IsRequired().HasColumnName("Spent");
            Property(c => c.PurchasesCost).IsRequired().HasColumnName("PurchasesCost");
            Property(c => c.CreatedAt).IsRequired().HasColumnName("CreatedAt");
            Property(c => c.UpdatedAt).IsRequired().HasColumnName("UpdatedAt");

            HasRequired(c => c.Plan).WithMany(p => p.Categories).HasForeignKey(c => c.PlanId).WillCascadeOnDelete(true);

        }
    }
}
