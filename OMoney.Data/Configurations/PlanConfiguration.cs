using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Configurations
{
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            ToTable("Plans");
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Month).IsRequired().HasColumnName("Month");
            Property(p => p.CreatedAt).IsRequired().HasColumnName("CreatedAt");
            Property(p => p.UpdatedAt).IsRequired().HasColumnName("UpdatedAt");
            Property(p => p.TotalPlanned).IsOptional().HasColumnName("TotalPlanned");
            Property(p => p.TotalSpent).IsOptional().HasColumnName("TotalSpent");

            HasRequired(p => p.User).WithMany(a => a.Plans).HasForeignKey(p => p.UserId).WillCascadeOnDelete(true);
        }
    }
}
