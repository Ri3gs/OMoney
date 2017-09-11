using System.Collections.Generic;

namespace OMoney.Domain.Core.Entities.Security
{
    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        public string AllowedOrigin { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
