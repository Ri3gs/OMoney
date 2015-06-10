using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities.Security;

namespace OMoney.Data.Configuration
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            ToTable("Clients");
            HasKey(c => c.Id);
            Property(c => c.Secret).IsRequired().HasColumnName("Secret");
            Property(c => c.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
            Property(c => c.Active).IsRequired().HasColumnName("Active");
            Property(c => c.RefreshTokenLifeTime).IsRequired().HasColumnName("RefreshTokenLifeTime");
            Property(c => c.AllowedOrigin).IsRequired().HasColumnName("AllowedOrigin").HasMaxLength(100);
        }
    }
}
