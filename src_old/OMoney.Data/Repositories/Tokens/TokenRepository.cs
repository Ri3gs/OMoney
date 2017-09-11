using System;
using System.Linq;
using OMoney.Data.Contexts;
using OMoney.Domain.Core.Entities.Security;

namespace OMoney.Data.Repositories.Tokens
{
    public class TokenRepository : ITokenRepository, IDisposable
    {
        private readonly DomainDbContext _domainDbContext;

        public TokenRepository()
        {
            _domainDbContext = new DomainDbContext();
        }

        public Client FindClient(string clientId)
        {
            var client = _domainDbContext.Clients.Find(clientId);
            return client;
        }

        public RefreshToken AddRefreshToken(RefreshToken token)
        {
            var existingToken = _domainDbContext.RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

            if (existingToken != null)
            {
                RemoveRefreshToken(existingToken);
            }

            _domainDbContext.RefreshTokens.Add(token);
            _domainDbContext.SaveChanges();
            return token;
        }

        public void RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = _domainDbContext.RefreshTokens.Find(refreshTokenId);

            if (refreshToken != null)
            {
                _domainDbContext.RefreshTokens.Remove(refreshToken);
                _domainDbContext.SaveChanges();
            }
        }

        public void RemoveRefreshToken(RefreshToken token)
        {
            _domainDbContext.RefreshTokens.Remove(token);
            _domainDbContext.SaveChanges();
        }

        public RefreshToken FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = _domainDbContext.RefreshTokens.Find(refreshTokenId);
            return refreshToken;
        }

        public IQueryable<RefreshToken> GetAllRefreshTokens()
        {
            return _domainDbContext.RefreshTokens.AsQueryable();
        }

        public void Dispose()
        {
            _domainDbContext.Dispose();
        }
    }
}
