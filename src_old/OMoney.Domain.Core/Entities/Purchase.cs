using System;

namespace OMoney.Domain.Core.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Buyed { get; set; }
        public DateTime? BuyedTime { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
