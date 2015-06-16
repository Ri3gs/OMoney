using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("AspNetUsers");
            HasKey(x => x.Id);
            Property(x => x.UserName).IsRequired().HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.IsGold).IsRequired().IsRequired().HasColumnType("bit");
            Property(x => x.GoldExpirationTime).IsRequired().HasColumnName("GoldExpirationTime");
        }
    }
}
