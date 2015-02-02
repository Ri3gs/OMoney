using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public interface IUserRepository
    {
        void Create(User user, string password);
        void Update(User user);
        void Delete(User user);
        bool ConfirmEmail(string userId, string code);

        User GetByEmail(string email);
        User FindUser(string email, string password);

        string GenerateEmailToken(string email);
    }
}
