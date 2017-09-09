namespace OMoney.Web.Api.Models
{
    public class AccountViewModel
    {
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public int AccountType { get; set; }
        public int AccountCurrency { get; set; }

        public string Email { get; set; }
    }
}