using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Configuration
{
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            ToTable("Plans");
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Month).IsRequired();

            HasRequired(p => p.User).WithMany(a => a.Plans).HasForeignKey(p => p.UserId).WillCascadeOnDelete(true);
        }
    }
}
