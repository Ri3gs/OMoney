using OMoney.Domain.Core.Entities;

namespace OMoney.Domain.Services.Users
{
    public interface IUserService
    {
        void Create(User user, string password, string confirmPassword);
        void Activate(string userId, string code);
        void Update(User user);
        void Delete(User user);
        void ChangePassword(string email, string oldPassword, string newPassword, string confirmNewPassword);
        void ResetPassword(string userId, string code, string newPassword, string confirmNewPassword);
        void UpdateToGold(string email);
        void RemoveGold(string email);

        User FindUser(string email, string password);
        User GetByEmail(string email);
        User FindById(string id);

        bool CheckEmail(string email);
    }
}
