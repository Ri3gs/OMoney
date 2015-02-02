using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Users
{
    public interface IUserService
    {
        void Create(User user, string password, string confirmPassword);
        bool Activate(string userId, string code);
        void Update(User user);
        void Delete(User user);

        User FindUser(string email, string password);
    }
}
