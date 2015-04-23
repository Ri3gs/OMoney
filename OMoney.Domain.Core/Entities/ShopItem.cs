namespace OMoney.Domain.Core.Entities
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public AccountCurrency Currency { get; set; }

        public int ShopingListId { get; set; }
    }
}
