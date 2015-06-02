namespace OMoney.Domain.Core.Entities
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public int ShopingListId { get; set; }
    }
}
