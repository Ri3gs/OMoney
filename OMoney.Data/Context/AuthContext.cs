using Microsoft.AspNet.Identity.EntityFramework;

namespace OMoney.Data.Context
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {
            
        }
    }
}
