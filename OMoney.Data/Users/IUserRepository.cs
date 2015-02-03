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
        User FindById(string userId);

        string GetId(string email);
        string GenerateEmailToken(string userId);
        string GeneratePwdToken(string email);
        bool ChangePassword(string email, string oldPassword, string newPassword);
        bool ResetPassword_(string userId, string code, string newPassword);
    }
}
