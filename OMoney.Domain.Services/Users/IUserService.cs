using OMoney.Domain.Entities.Entities;

namespace OMoney.Domain.Services.Users
{
    public interface IUserService
    {
        void Create(User user);
        void Activate(User user);
        void Update(User user);
        void Delete(User user);
    }
}
