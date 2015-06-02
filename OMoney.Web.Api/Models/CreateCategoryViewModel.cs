using System.Collections.Generic;
using OMoney.Domain.Core.Entities;

namespace OMoney.Web.Api.Models
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; }
        public decimal Planned { get; set; }
        public decimal Spent { get; set; }
        public Currency Currency { get; set; }

        public int PlanId { get; set; }
    }
}