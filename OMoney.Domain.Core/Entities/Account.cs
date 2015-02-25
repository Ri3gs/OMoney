namespace OMoney.Domain.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
