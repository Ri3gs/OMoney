using System;

namespace OMoney.Domain.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AccountType AccountType { get; set; }
        public AccountCurrency AccountCurrency { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
