using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Context
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext() : base("name=AuthContext")
        {
            
        }
    }
}
