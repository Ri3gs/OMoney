using OMoney.Domain.Core.Entities;

namespace OMoney.Web.Api.Models
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        public AccountCurrency Currency { get; set; }
        public decimal Planned { get; set; }
        public decimal Spent { get; set; }
        public string Name { get; set; }
    }
}