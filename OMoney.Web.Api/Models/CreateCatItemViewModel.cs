namespace OMoney.Web.Api.Models
{
    public class CreateCatItemViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Buyed { get; set; }

        public int CategoryId { get; set; }
    }
}