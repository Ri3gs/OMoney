using System.Linq;
using OMoney.Domain.Core.Entities.Security;

namespace OMoney.Data.Repositories
{
    public interface ITokenRepository
    {
        Client FindClient(string clientId);
        RefreshToken AddRefreshToken(RefreshToken token);
        void RemoveRefreshToken(string refreshTokenId);
        void RemoveRefreshToken(RefreshToken token);
        RefreshToken FindRefreshToken(string refreshTokenId);
        IQueryable<RefreshToken> GetAllRefreshTokens();
    }
}
