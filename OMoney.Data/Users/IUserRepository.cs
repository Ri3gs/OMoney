using OMoney.Domain.Entities.Entities;

namespace OMoney.Data.Users
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
