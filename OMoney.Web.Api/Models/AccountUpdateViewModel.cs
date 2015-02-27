namespace OMoney.Web.Api.Models
{
    public class AccountUpdateViewModel
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}