using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities.Security;

namespace OMoney.Data.Configuration
{
    public class RefreshTokenConfiguration : EntityTypeConfiguration<RefreshToken>
    {
        public RefreshTokenConfiguration()
        {
            ToTable("RefreshTokens");
            HasKey(t => t.Id);
            Property(t => t.Subject).IsRequired().HasColumnName("Subject").HasMaxLength(50);
            Property(t => t.ProtectedTicket).IsRequired().HasColumnName("ProtectedTicket");
            Property(t => t.IssuedUtc).IsRequired().HasColumnName("IssuedUtc");
            Property(t => t.ExpiresUtc).IsRequired().HasColumnName("ExpiresUtc");

            HasRequired(t => t.Client).WithMany(c => c.RefreshTokens).HasForeignKey(t => t.ClientId).WillCascadeOnDelete(true);
        }
    }
}
