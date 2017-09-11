using OMoney.Domain.Core.Entities;

namespace OMoney.Web.Api.Models
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        public Currency Currency { get; set; }
        public decimal Planned { get; set; }
        public decimal Spent { get; set; }
        public decimal CatItemsTotalPrice { get; set; }
        public string Name { get; set; }
    }
}