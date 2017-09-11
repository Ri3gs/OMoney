using System;

namespace OMoney.Domain.Core.Entities.Security
{
    public class RefreshToken
    {
        public string Id { get; set; }
        public string Subject { get; set; }
        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public string ProtectedTicket { get; set; }

        public Client Client { get; set; }
        public string ClientId { get; set; }
    }
}
