using System;
using System.Collections.Generic;

namespace OMoney.Domain.Core.Entities
{
    public class ShopingList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<ShopItem> Items { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
