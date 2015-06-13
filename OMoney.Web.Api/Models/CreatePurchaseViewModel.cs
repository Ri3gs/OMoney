namespace OMoney.Web.Api.Models
{
    public class CreatePurchaseViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Buyed { get; set; }

        public int CategoryId { get; set; }
    }
}