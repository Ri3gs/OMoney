using System.Collections.Generic;

namespace OMoney.Domain.Core.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
