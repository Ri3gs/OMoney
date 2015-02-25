using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OMoney.Domain.Core.Entities
{
    public class User : IdentityUser
    {
        public bool IsGold { get; set; }
        public DateTime GoldExpirationTime { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
