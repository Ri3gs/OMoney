using OMoney.Domain.Core.Entities;

namespace OMoney.Data.Users
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void Delete(User user);

        User GetByEmail(string email);
    }
}
