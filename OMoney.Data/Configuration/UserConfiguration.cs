using System.Data.Entity.ModelConfiguration;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("AspNetUsers");
            HasKey(x => x.Id);
            Property(x => x.UserName).IsRequired().HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(256);
            Ignore(x => x.Claims);
            Ignore(x => x.Logins);
            Ignore(x => x.Roles);
        }
    }
}
