using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OMoney.Domain.Core.Entities
{
    public class User : IdentityUser
    {
        public bool IsGold { get; set; }
        public DateTime GoldExpirationTime { get; set; } 
    }
}
