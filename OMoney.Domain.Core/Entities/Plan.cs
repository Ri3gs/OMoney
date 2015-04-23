using System;
using System.Collections.Generic;

namespace OMoney.Domain.Core.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<ShopingList> ShopingLists { get; set; }
    }
}
